using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dam
{
    class Controller
    {
        private Dam _Dam;
        private DamRepresentation _View;
        private DamAttributeSelection _TemporalView;
        private Thread _UIValuesChanger;
        private UI.AddTurbine _NewTurbineCreator;


        public Controller(DamAttributeSelection pTemporalView)
        {
            _TemporalView = pTemporalView;
            _TemporalView.startSimulation += createDam;
            _NewTurbineCreator = new UI.AddTurbine();
            _NewTurbineCreator.newTurbine += createTurbine;
        }
        public void createDam(string pMaxHeight, string pMinHeight, 
            string pWidth, string pLength, string pFlowRate, bool pKm)
        {
            if(pKm)
            {
                _Dam= new Dam(Converter.kmToMeters(ulong.Parse(pMaxHeight)), Converter.kmToMeters(ulong.Parse(pMinHeight)),
                    Converter.kmToMeters(ulong.Parse(pWidth)), Converter.kmToMeters(ulong.Parse(pLength)), ulong.Parse(pFlowRate));
            }
            else{

                _Dam = new Dam(ulong.Parse(pMaxHeight), ulong.Parse(pMinHeight),
                   ulong.Parse(pWidth), ulong.Parse(pLength), ulong.Parse(pFlowRate));
            }

            _Dam.MaxCapacityReached1 += waterOverflow;

            _TemporalView.Hide();
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
            _View.RequestForTurbine += showTurbineGenerator;
            _View.ChangeStateCurrentTurbine += changeStateOfTurbine;
            _View.StateCurrentTurbine += stateOfCurrentTurbine;
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
            bool stop = true;
            bool image1 = true;
            while (stop)
            {
                waveAnimation(image1);
                image1 = !image1;
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
                Thread.Sleep(200);
                _View.TankLabelChanged(_Dam.Tank.CurrentHeigth);
 
        }
        public void showTurbineGenerator()
        {
            _NewTurbineCreator.Show();
        }

        public String getFlowRate()
        {
            return "nada";
        }
        public String setValues()
        {
            return "nada";
        }        
    }
}
