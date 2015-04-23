using Dam.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using Dam.UI;
using System.Windows.Forms;

/*This class is in charge of communicating the UI for the user and the logics behind it. It is supposed to be the bridge between those
 * also, it is in charge of starting the threads of the program and closing them too*/

namespace Dam
{
    class Controller:IObserver
    {

        private Controller()
        {
            _Dam = Dam.getInstance();
            _UIValuesChanger = new Thread(waveAnimation);
            _UIValuesChanger.IsBackground = true;
        }

        public DamAttributeSelection TemporalView
        {
            get { return _TemporalView; }
            set { _TemporalView = value; }
        }

        public static Controller getInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Controller();
            }
            return _Instance;
        }

        public void setTemporalView(DamAttributeSelection pSelector) //method to stablish a temporal link of the first UI for the attributes.
        {
            _TemporalView = pSelector;
            _TemporalView.register(this);
            _NewTurbineCreator = new UI.AddTurbine();
            _NewTurbineCreator.register(this);
        }


        public void createDam(string pMaxHeight, string pMinHeight, 
            string pWidth, string pLength, string pFlowRate, bool pKm) //links a Dam with this controller, 
        {
            ulong[] attributes = new ulong[] { ulong.Parse(pMaxHeight), ulong.Parse(pMinHeight), ulong.Parse(pWidth), ulong.Parse(pLength), ulong.Parse(pFlowRate) };
            
            if(pKm)
            {
                for (int index = 0; index < attributes.Length; index++)
                {
                    attributes[index] = Converter.kmToMeters(attributes[index]);
                }
            }

            _Dam.initializeDam(attributes[0], attributes[1], attributes[2], attributes[3], attributes[4]);

            _Dam.register(this); //add observer
            _TemporalView.Hide(); //hides the first interface running in the back, because of the system.runapplication
            newView(); //generates de main interface

            _Dam.FlowRate.Start(); //starts each thread after the interface was created.
            _Dam.ReleasingRate.Start();
        }

        public void createTurbine(string pMaxFlowRate, string pMinFlowRate,
            string pMaxPressure, string pMinPressure, string pMaxEnergy, string pMinEnergy, int pNumberofTurbines)
        {
            for (int turbinesToCreate = 0; turbinesToCreate < pNumberofTurbines; turbinesToCreate++)
            {
                _Dam.addTurbine(Convert.ToUInt64(pMaxFlowRate), Convert.ToUInt64(pMinFlowRate), Convert.ToUInt64(pMaxPressure), Convert.ToUInt64(pMinPressure),
                    Convert.ToUInt64(pMaxEnergy), Convert.ToUInt64(pMinEnergy));
                _View.IdTurbines.Add(_Dam.getCurrentTurbineId());
            }

        }

        public void newView()
        {
            _View = new DamRepresentation();
            _View.Show();
            _View.register(this);
            _View.changeCurrentFlowText(_Dam.CurrentFlowRate);
            _UIValuesChanger.Start();
        }

        public void changeStateOfTurbine(string pIdTurbine)
        {
            _Dam.setTurbineStateForId(pIdTurbine);
            stateOfCurrentTurbine(pIdTurbine);
        }

        public void stateOfCurrentTurbine(string pIdTurbine)
        {
            Turbine turbineFound = _Dam.turbineById(pIdTurbine);
            if (turbineFound.TurnedOn)
            {
                _View.statusLabelChanged("ON");
            }
            else
            {
                _View.statusLabelChanged("OFF");
            }
            _View.singleEnergyLabelChanged(turbineFound.CurrentEnergyProduced);
        }

        public void waveAnimation()
        {
            bool image = true;
            while (_RunningThread)
            {
                wavePainting(image);
                image = !image;
                Thread.Sleep(200);
            }
        }

        public void wavePainting(bool pImageOne)
        {      
            int waveQuantity;

            if(pImageOne) //alternate quantity of waves to create a type of animation
                waveQuantity=10;
            else waveQuantity=12;

            int coordenateYTank = Constants.HEIGHT_TANK_LABEL+Constants.INCREMENT_OF_WAVES - (Int32)(_Dam.Tank.CurrentHeigth*Constants.HEIGHT_TANK_LABEL/_Dam.Tank.MaxHeigth);
            int coordenateYRiver = Constants.HEIGHT_RIVER_LABEL+Constants.INCREMENT_OF_WAVES - (Int32)(_Dam.River.CurrentHeigth*Constants.HEIGHT_RIVER_LABEL/_Dam.River.MaxHeigth);

            List<Point[]> tankCoordinates= Converter.waveDrawing(Constants.STARTING_X_CONTAINER, Constants.ENDING_X_TANK,
                coordenateYTank, waveQuantity);

            List<Point[]> riverCoordinates= Converter.waveDrawing(Constants.STARTING_X_CONTAINER, Constants.ENDING_X_RIVER,
                coordenateYRiver, waveQuantity);

            _View.paintWater(tankCoordinates, riverCoordinates);
        }
        
        public void update(IObservable pOservable)
        {
            if (pOservable.GetType() == typeof(Dam))
            {
                damHandler();
            }
            else if (pOservable.GetType() == typeof(DamRepresentation))
            {
                damVisualizationHandler();
            }
            else if (pOservable.GetType() == typeof(AddTurbine))
            {
                String[] turbineValues=_NewTurbineCreator.getTurbineAttributes();

                createTurbine(turbineValues[0], turbineValues[1], turbineValues[2], turbineValues[3], turbineValues[4],
                    turbineValues[5], Convert.ToInt32(turbineValues[6]));
            }
            else if (pOservable.GetType() == typeof(DamAttributeSelection))
            {
                String[] attributesValues = _TemporalView.getAttributes();

                createDam(attributesValues[0], attributesValues[1], attributesValues[2],
                    attributesValues[3], attributesValues[4], _TemporalView.kmChecked());
            }
        }

        public void damHandler()
        {
            Dam dam = Dam.getInstance();
            if (dam.Tank.SignificanceVolumeChanged)
            {
                dam.Tank.SignificanceVolumeChanged = false;
                _View.volumeLabelChanged(dam.Tank.CurrentNoticeableVolume.toString());
                _View.tankLabelChanged(dam.Tank.CurrentHeigth);
                _View.riverLabelChanged(dam.River.CurrentHeigth);

                Turbine currentSelection = dam.turbineById(_View.selectedTurbine());

                if (currentSelection != null)
                {
                    _View.singleEnergyLabelChanged(currentSelection.CurrentEnergyProduced);
                }
                else
                    _View.singleEnergyLabelChanged(0);

                _View.totalEnergyLabelChanged(Convert.ToString(dam.currentEnergyProduced()));
            }
            if (_Dam.Tank.WaterOverflow)
            {
                //message box
            }
            if (_Dam.Tank.LowCapacity)
            {
                //message box
                _View.statusLabelChanged("OFF");
            }
        }

        public void damVisualizationHandler()
        {
            if (_View.TurbineStatusRequested)
            {
                _View.TurbineStatusRequested = false;
                stateOfCurrentTurbine(_View.selectedTurbine());
            }
            if (_View.TurbineRequested) //en case of adding a new Turbine, a new interface is shown
            {
                _View.TurbineRequested = false;
                _NewTurbineCreator.Show();
            }
            if (_View.TurbineChanged)
            {
                _View.TurbineChanged = false;
                changeStateOfTurbine(_View.selectedTurbine());
            }
            if (_View.FlowRateRequest)
                _Dam.CurrentFlowRate=Convert.ToUInt64(_View.currentFlowRate());

            if (_View.ProgramClosed)
            {
                //metodo para parar todos los threads
                _RunningThread = false;
                _Dam.WaterFlowing = false;
                _Dam.RealeasingWater = false;
                _TemporalView.exit();
            }
        }

        private DamAttributeSelection _TemporalView;
        private Dam _Dam;
        private DamRepresentation _View;
        private Thread _UIValuesChanger;
        private AddTurbine _NewTurbineCreator;
        private static Controller _Instance = null;
        private bool _RunningThread = true;
    }
}
