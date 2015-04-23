using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Dam.Logic;

namespace Dam
{
    static class Converter
    {
    //Class that contains basic static methods used for conversions, to be called anywhere

        public static ulong threeRule(ulong pCurrentPorcentage , ulong pMaxValue) //Max value must be calculated by the substraction of the real Max value minus the Min value 
        {
            return pCurrentPorcentage* pMaxValue/100;
        }

        public static List<Point[]> waveDrawing(int pStartingX, int pEndingX, int pStartingY,int pWaveQuantity) //pStartingY designates where the wave originates 
        {
            List<Point[]> water = new List<Point[]>();
            int waveLenght = (pEndingX - pStartingX) / pWaveQuantity; //pWaveQuantity would be an approximate
            while(pStartingX < pEndingX)
            {
                    Point[] singleWave ={new Point(pStartingX, pStartingY),
                                         new Point(pStartingX + waveLenght / 2, pStartingY-Constants.INCREMENT_OF_WAVES),
                                         new Point(pStartingX + waveLenght, pStartingY)};
                    pStartingX += waveLenght;
                    water.Add(singleWave);
            }
            return water;
        }

        public static HugeInt calculateHugeVolume(ulong pHeight, ulong pWidth, ulong pLong)//parameters enter as m
        {
            HugeInt volume = new HugeInt(metersToCentimeters(pHeight));//1
            volume.multiply(new HugeInt(metersToCentimeters(pWidth)));//
            volume.multiply(new HugeInt(metersToCentimeters(pLong)));//
            return volume;//2
            //F(N) = 2 +
            //O(N) =
        }

        public static ulong kmToMeters(ulong pKilometers)
        {
            return pKilometers * 1000;
        }

        private static String metersToCentimeters(ulong pMeters)
        {
            return pMeters.ToString() + "00";// 2 + 2 + 2 + 1
            //F(N) = 7 y O(N) = C
        }
    }
}
