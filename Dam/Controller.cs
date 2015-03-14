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
        Form1 _View;
        public String getFlowRate();
        public String setValues();
        public int kmToPixel();// To paint the current heigth in the view proportionate to the screen
    }
}
