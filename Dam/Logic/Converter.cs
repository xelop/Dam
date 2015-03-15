using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dam
{
    static class Converter
    {//Siempre poner try y catch??
        public static String listToString(List<Int16> pList)
        {
            String result = "";
            for (int numberPosition = 0; numberPosition < pList.Count; numberPosition++)
            {
                result += pList[numberPosition];
            }
            return result;
        }

        public static List<Int16> stringToList(String pNumber)
        {
            StringBuilder stringNumber = new StringBuilder(pNumber);
            List<Int16> listNumbers = new List<Int16>();
            for (int charNumber = 0; charNumber < pNumber.Length; charNumber++)
            {
                listNumbers.Add(Int16.Parse(stringNumber[charNumber].ToString()));
            }
            return listNumbers;
        }

        public static List<Int16> doubleList(List<Int16> listToDouble)
        {
            return null;
        }

        public static List<Int16> multiplyList(List<Int16> pFirstList, List<Int16> pSecondList)
        {
            return null;
        }

        public static List<Int16> addList(List<Int16> pFirstList, List<Int16> pSecondList)//subtracts the number in the first list minus the numers of the secondlist
        {
            return null;
        }


        public static List<Int16> restList(List<Int16> pFirstList, List<Int16> pSecondList)
        {
            return null;
        }


        public static Boolean compareList(List<Int16> pFirstList, List<Int16> pSecondList)
         //Return true if the number contained in firstList is larger than the number in second list
        {
            return true;
        }


        public static int threeRule(int pMin, int pMax , int pRelation)// To paint the current heigth in the view proportionate to the screen
        {
            return 0;
        }
        public static List<Point[]> waveDrawing(int pStartingX, int pEndingX, int pStartingY) //pStartingY simbolizes where the wave originates 
        { 
            int waveLenght = (pEndingX - pStartingX) / 10;
            List<Point[]> water=new List<Point[]>();
            for(int waveQuantity = 0; waveQuantity < 10; waveQuantity++){
                    Point[] singleWave ={new Point(pStartingX, pStartingY),
                                         new Point(pStartingX + waveLenght / 2, pStartingY-Constants._IncrementofWaves),
                                         new Point(pStartingX + waveLenght, pStartingY)};
                    pStartingX += waveLenght;
                    water.Add(singleWave);
                }
            return water;
        }

        public static List<Int16> calculateVolume(ulong pHeight, ulong pWidth, ulong pLong)
        {
            return null;
        }
    }
}
