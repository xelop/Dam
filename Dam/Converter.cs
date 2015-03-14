using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dam
{
    static class Converter
    {
        //public static String arrayToString(Int16[] pArray);

        //public static Int16[] stringToArray(String pNumber);

        //public static Int16[] multiplyArray(Int16[] pFirstArray, Int16[] pSecondArray);

        //public static Int16[] addArray(Int16[] pFirstArray, Int16[] pSecondArray);

        //public int threeRule(int pMin, int pMax , int pRelation);// To paint the current heigth in the view proportionate to the screen

        public static List<Point[]> waveDrawing(int pStartingX, int pEndingX, int pStartingY, int pEndingY) //pStartingY simbolizes where the wave originates and pEndingY where it reaches the max heigth
        { 

            int waveLenght=(pEndingX-pStartingX)/10;
            List<Point[]> water=new List<Point[]>();
            for(int waveQuantity=0; waveQuantity<10;waveQuantity++){
                Point[] singleWave ={new Point(pStartingX,pStartingY),new Point(pStartingX+waveLenght/2,pEndingY),new Point(pStartingX+waveLenght,pStartingY)};
                pStartingX+=waveLenght;
                water.Add(singleWave);
                }
            return water;
        }
    }
}
