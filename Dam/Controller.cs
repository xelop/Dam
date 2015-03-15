using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam
{
    class Controller
    {
        Dam _Dam;
        DamRepresentation _View;


        public Controller(Dam pDam, DamRepresentation pView)
        {
            _Dam = pDam;
            _View = pView;
            pView.clickked=pView.clickked+sendWaveValues;
        }
        public void sendWaveValues()
        {
            _View.paintWater(Converter.waveDrawing(100,300, 300));
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
