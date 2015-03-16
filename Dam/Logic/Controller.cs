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
        private Thread x;


        public Controller(DamAttributeSelection pTemporalView)
        {
            _TemporalView = pTemporalView;
            _TemporalView.startSimulation=createDam+_TemporalView.startSimulation;
        }
        public void createDam(string pMaxHeight, string pMinHeight, string pWidth, string pLength, string pFlowRate, bool pKm)
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
            _TemporalView.Hide();
            newView();
        }

        public void newView()
        {
            _View = new DamRepresentation();
            _View.clickked = _View.clickked + sendWaveValues;
            _View.Show();
            x = new Thread(waveAnimation);
        }

        public void sendWaveValues()
        {
            x.Start();
           //_View.paintWater(Converter.waveDrawing(0,104,200,10));
        }

        public void waveAnimation()
        {
           
            bool stop=true;
            while (stop)
            {

                _View.paintWater(Converter.waveDrawing(0, 104, 200, 10), Converter.waveDrawing(696, 859, 430, 10));
                Thread.Sleep(200);

                _View.paintWater(Converter.waveDrawing(0, 104, 200, 12), Converter.waveDrawing(696, 859, 430, 10));
                Thread.Sleep(200);
             
                
               
            }
        } //Metodo de animacion del agua, debo implimentarlo de mejor manera

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
