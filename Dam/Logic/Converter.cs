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

        public static List<ulong> copyList(List<ulong> listToCopy)//make an exact copy of a list
        {
            List<ulong> newList = new List<ulong>();
            for (int numberIndex = 0; numberIndex < listToCopy.Count; numberIndex++)
            {
                newList.Add(listToCopy[numberIndex]);
            }
            return newList;
        }


        public static ulong threeRule(ulong pCurrentPorcentage , ulong pMaxValue) //Max value must be calculated by the substraction of the real Max value minus the Min value 
        {
            return pCurrentPorcentage* pMaxValue/100;
        }

        public static List<Point[]> waveDrawing(int pStartingX, int pEndingX, int pStartingY,int pWaveQuantity) //pStartingY designates where the wave originates 
        { 
            int waveLenght = (pEndingX - pStartingX) / pWaveQuantity; //pWaveQuantity would be an approximate
            List<Point[]> water=new List<Point[]>();
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
            HugeInt volume = new HugeInt(metersToCentimeters(pHeight));
            volume.multiply(new HugeInt(metersToCentimeters(pWidth)));
            volume.multiply(new HugeInt(metersToCentimeters(pLong)));
            return volume;
        }

        public static ulong kmToMeters(ulong pKilometers)
        {
            return pKilometers * 1000;
        }

        public static String metersToCentimeters(ulong pMeters)
        {
            return pMeters.ToString() + "00";
        }
    }
}
