using Dam.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Dam.UI;
using System.Windows.Forms;

namespace Dam
{
    class Controller:IObserver
    {
        private Dam _Dam;
        private DamRepresentation _View;
        private DamAttributeSelection _TemporalView;
        private Thread _UIValuesChanger;
        private AddTurbine _NewTurbineCreator;
        private static Controller _Instance = null;
        private bool _RunningThread = true;


        private Controller(){
            _Dam = Dam.getInstance();
        }

        public static Controller getInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Controller();
            }
            return _Instance;
        }

        public void setTemporalView(DamAttributeSelection pSelector)
        {
            _TemporalView = pSelector;
            _TemporalView.register(this);
            _NewTurbineCreator = new UI.AddTurbine();
            _NewTurbineCreator.register(this);
        }


        public void createDam(string pMaxHeight, string pMinHeight, 
            string pWidth, string pLength, string pFlowRate, bool pKm)
        {
            if(pKm)
            {
                _Dam.initializeDam(Converter.kmToMeters(ulong.Parse(pMaxHeight)), Converter.kmToMeters(ulong.Parse(pMinHeight)),
                    Converter.kmToMeters(ulong.Parse(pWidth)), Converter.kmToMeters(ulong.Parse(pLength)), ulong.Parse(pFlowRate));
            }
            else{
                _Dam.initializeDam(ulong.Parse(pMaxHeight), ulong.Parse(pMinHeight),
                   ulong.Parse(pWidth), ulong.Parse(pLength), ulong.Parse(pFlowRate));
            }

            //_TemporalView.Hide();
            newView();
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

        public void waterOverflow()
        {
            System.Windows.Forms.MessageBox.Show("Water exceeded the capacity. Water entrance will be stopped.");
        }

        public void newView()
        {
            _View = new DamRepresentation();
            _View.Show();
            _View.register(this);
            _UIValuesChanger = new Thread(runThread);
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
        }

        /*public void sendWaveValues()
        {
            //x.Start();
           //_View.paintWater(Converter.waveDrawing(0,104,200,10));
        }*/

        public void runThread()
        {
            bool image1 = true;
            while (_RunningThread)
            {
                try
                {
                    waveAnimation(image1);
                    image1 = !image1;
                    Thread.Sleep(200);
                }
                catch { _RunningThread = false;
                _TemporalView.exit();
                }
            }
        }

        public void waveAnimation(bool pImageOne)
        {      
            int waveQuantity;
                if(pImageOne)
                    waveQuantity=10;
                else waveQuantity=12;

                _View.paintWater(Converter.waveDrawing(Constants.STARTING_X_CONTAINER, Constants.ENDING_X_TANK,
                                                        Constants.HEIGHT_TANK_LABEL - (Int32)Converter.threeRule(_Dam.Tank.MaxHeigth, Constants.HEIGHT_TANK_LABEL, _Dam.Tank.CurrentHeigth), waveQuantity),
                                                        Converter.waveDrawing(Constants.STARTING_X_CONTAINER, Constants.ENDING_X_RIVER,
                                                        100, waveQuantity));
        }

        public void damNotificationHnadler()
        {
            if (_View.TurbineStatusRequested)
            {
                _View.TurbineStatusRequested = false;
                stateOfCurrentTurbine(_View.selectedTurbine());
            }
            if (_View.TurbineRequested) //en caso de agregar una nueva turbina, se enseña la nueva ventana
            {
                _View.TurbineRequested = false;
                _NewTurbineCreator.Show();
            }
            if (_View.TurbineChanged)
            {
                _View.TurbineChanged = false;
                changeStateOfTurbine(_View.selectedTurbine());
            }
            if (_View.ProgramClosed)
            {
                //metodo para parar todos los threads
                _RunningThread = false;
                _TemporalView.exit();
            }
        }
        public String getFlowRate()
        {
            return "nada";
        }
        public String setValues()
        {
            return "nada";
        }
        
        public void update(IObservable pOservable)
        {
            if (pOservable.GetType() == typeof(Dam))
            {
                Dam dam = Dam.getInstance();
                if (_Dam.Tank.WaterOverflow)
                {
                    //message box
                    _Dam.setWaterOverflow();
                }
                if (_Dam.Tank.LowCapacity)
                {
                    //message box
                    _Dam.setLowCapacity(); ;
                }
            }
            else if (pOservable.GetType() == typeof(DamRepresentation))
            {
                damNotificationHnadler();
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
            //draw shits in the interface
        }

        public DamAttributeSelection TemporalView
        {
            get { return _TemporalView; }
            set { _TemporalView = value; }
        }

    }
}
