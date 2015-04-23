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
            List<Point[]> water = new List<Point[]>();            // 1 + 4                                             
            int waveLenght = (pEndingX - pStartingX) / pWaveQuantity; //pWaveQuantity would be an approximate  //3 
            while (pStartingX < pEndingX) // 1 tiempo de comparacion
            {
                Point[] singleWave ={new Point(pStartingX, pStartingY),
                                         new Point(pStartingX + waveLenght / 2, pStartingY-Constants.INCREMENT_OF_WAVES),
                                         new Point(pStartingX + waveLenght, pStartingY)};  //1 de la asignacion, 1 de suma, 2 de division, 1 de resta, 1 de suma , 18 de los tres cosntructores de los points y los dos parametros de ambos.
                pStartingX += waveLenght; //2 de asignacion o de suma
                water.Add(singleWave); // 4 tiempos de llamada y retorno y 1 de mandar un parametro
            } // en total= 31
            return water; //2 tiempos de retorno
            //en total 10+31(N)
        }//O(n)=N
   

        public static HugeInt calculateHugeVolume(ulong pHeight, ulong pWidth, ulong pLong)//parameters enter as m
        {// pHeight digits = L , pLong digits = M , pWidth digits = O . N = LMO 
            HugeInt volume = new HugeInt(metersToCentimeters(pHeight));//1 + 2 + 2 + 1 + 2 + 2 + 1 + L
            volume.multiply(new HugeInt(metersToCentimeters(pWidth)));// 2 + 2 + 1 + 2 + 2 + 1 + 2 + 2 + 1 + O + (L*O)
            volume.multiply(new HugeInt(metersToCentimeters(pLong)));//2 + 2 + 1 + 2 + 2 + 1 + 2 + 2 + 1 + M + (L*O*M)
            return volume;//2
            //F(N) = 2 + 11 + L + 15 + (L*O) + 15 + (L*O*M) + L + O + M =  2 + 11 + L + 15 + (L*O) + 15 + (N) + L + O + M
            //O(N) = N
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
