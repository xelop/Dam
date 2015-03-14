using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam
{
    class Converter
    {
        public static String arrayToString(Int16[] pArray);

        public static Int16[] stringToArray(String pNumber);

        public static Int16[] multiplyArray(Int16[] pFirstArray, Int16[] pSecondArray);

        public static Int16[] addArray(Int16[] pFirstArray, Int16[] pSecondArray);

        public int threeRule(int pMin, int pMax , int pRelation);// To paint the current heigth in the view proportionate to the screen
    }
}
