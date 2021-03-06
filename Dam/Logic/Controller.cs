﻿using Dam.Logic;
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
            _UIValuesChanger.IsBackground = true;//thread; all deleted on exit
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
            newView(); //generates the main interface

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
        {//receives an id, and changes it true/false
            _Dam.setTurbineStateForId(pIdTurbine);
            stateOfCurrentTurbine(pIdTurbine);//changes label ON/OFF
        }

        public void stateOfCurrentTurbine(string pIdTurbine)
        {//changes the label
            Turbine turbineFound = _Dam.turbineById(pIdTurbine);
            if (turbineFound.TurnedOn)
            {
                _View.statusLabelChanged("ON");
            }
            else
            {
                _View.statusLabelChanged("OFF");//current energy produced = 0
            }
            _View.singleEnergyLabelChanged(turbineFound.CurrentEnergyProduced);
        }

        public void waveAnimation()
        {
            try
            {
                bool image = true;
                while (_RunningThread)
                {
                    wavePainting(image);
                    image = !image;
                    Thread.Sleep(Constants.CHANGE_WAVES);
                }
            }
            catch (Exception ex)
            {
                FileManagement.addToFile(ex.Message);
            }
        }

        public void wavePainting(bool pImageOne)
        {      
            int waveQuantity;

            _View.VolumeChanged(_Dam.Tank.CurrentVolume.toString());

            if(pImageOne) //alternate quantity of waves to create a type of animation
                waveQuantity=Constants.MIN_WAVES;
            else waveQuantity=Constants.MAX_WAVES;

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
            else if (pOservable.GetType() == typeof(AddTurbine))//new turbines to create
            {
                String[] turbineValues=_NewTurbineCreator.getTurbineAttributes();

                createTurbine(turbineValues[0], turbineValues[1], turbineValues[2], turbineValues[3], turbineValues[4],
                    turbineValues[5], Convert.ToInt32(turbineValues[6]));
            }
            else if (pOservable.GetType() == typeof(DamAttributeSelection))//to create the dam. This only happen once.
            {
                String[] attributesValues = _TemporalView.getAttributes();

                createDam(attributesValues[0], attributesValues[1], attributesValues[2],
                    attributesValues[3], attributesValues[4], _TemporalView.kmChecked());
            }
        }

        public void damHandler()
        {//changes ALL labels in the interface.
            Dam dam = Dam.getInstance();

            if (dam.Tank.SignificanceVolumeChanged)
            {
                dam.Tank.SignificanceVolumeChanged = false;
                ////_View.volumeLabelChanged(dam.Tank.CurrentNoticeableVolume.toString());
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
                //System.Windows.Forms.MessageBox.Show("The dam is at its maximun capacity. Water entrance will be stopped for 10 seconds.");
            }
            if (_Dam.Tank.LowCapacity)
            {
                //System.Windows.Forms.MessageBox.Show("The dam is at its maximun capacity. All turbines will be set to OFF.");
                _View.statusLabelChanged("OFF");
            }
        }

        public void damVisualizationHandler()
        {

            if (_View.TurbineStatusRequested)
            {
                _View.TurbineStatusRequested = false;
                stateOfCurrentTurbine(_View.selectedTurbine());//changes true/false
            }
            if (_View.TurbineRequested) //en case of adding a new Turbine, a new interface is shown
            {
                _View.TurbineRequested = false;
                _NewTurbineCreator.Show();
            }
            if (_View.TurbineChanged)
            {
                _View.TurbineChanged = false;
                changeStateOfTurbine(_View.selectedTurbine());//another turbine was selected
            }
            if (_View.FlowRateRequest)
            {
                _View.FlowRateRequest = false;
                _Dam.CurrentFlowRate = Convert.ToUInt64(_View.currentFlowRate());
            }

            if (_View.SecondsRequested)
            {
                _View.SecondsRequested = false;
                if (Convert.ToInt32(_View.currentSeconds()) <= Constants.MAX_ITERATIONS_PER_SECONDS)
                {
                    _Dam.Seconds = 1000 / Convert.ToInt32(_View.currentSeconds());
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Solo se puede tiempos menores a 20.");
                }
            }

            if (_View.ProgramClosed)
            {
                //method to stop ALL the threasd. Security principles.
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
