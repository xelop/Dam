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

        public static List<Point[]> waveDrawing(int pStartingX, int pEndingX, int pStartingY, int pWaveQuantity) //pStartingY designates where the wave originates 
        {                                                                                               // N seria el waveLenght 
            List<Point[]> water = new List<Point[]>();            // 1 de la asignacion, no se si el constructor cuenta                                             
            int waveLenght = (pEndingX - pStartingX) / pWaveQuantity; //pWaveQuantity would be an approximate  //3 = uno de la asignacion, uno de la resta y uno de la division
            while (pStartingX < pEndingX) // 1 tiempo de comparacion
            {
                Point[] singleWave ={new Point(pStartingX, pStartingY),
                                         new Point(pStartingX + waveLenght / 2, pStartingY-Constants.INCREMENT_OF_WAVES),
                                         new Point(pStartingX + waveLenght, pStartingY)};  //1 de la asignacion, 1 de suma, 2 de division, 1 de resta, 1 de suma , 18 de los tres cosntructores de los points y los dos parametros de ambos.
                pStartingX += waveLenght; //2 de asignacion o de suma
                water.Add(singleWave); // 4 tiempos de llamada y retorno y 1 de mandar un parametro
            } // en total= 31
            return water; //2 tiempos de retorno
            //en total 6+31(N)
        }//O(n)=N
   

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

        private static String metersToCentimeters(ulong pMeters)
        {
            return pMeters.ToString() + "00";
        }
    }
}
