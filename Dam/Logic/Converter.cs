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

        public static List<Int16> copyList(List<Int16> listToCopy)//make an exact copy of a list
        {
            List<Int16> newList = new List<Int16>();
            for (int numberIndex = 0 ; numberIndex < listToCopy.Count; numberIndex++)
            {
                newList.Add(listToCopy[numberIndex]);
            }
            return newList;
        }

        public static List<Int16> multiplyList(List<Int16> pFirstList, List<Int16> pSecondList)
        {
            List<Int16> productList = new List<Int16>();
            productList.Add(0);
            List<Int16> intermidiaryList = new List<Int16>();//used as a repositiory for the little sums between pFirsList and PsecondList
            int productInt = 0;
            int carry = 0;
            int unit = 0;
            int cerosToAdd = 0;
            int cerosRemaining;
            for (int firstListIndex = pFirstList.Count - 1 ; firstListIndex  >= 0; firstListIndex--)
            {
                carry = 0;
                intermidiaryList.Clear();//refresh
                cerosRemaining = cerosToAdd;
                for (int secondListIndex = pSecondList.Count - 1; secondListIndex >= 0; secondListIndex--)
                {
                    if (pFirstList[firstListIndex] == 0)
                    {
                        break;
                    }
                    if (pFirstList[firstListIndex] == 1)
                    {
                        intermidiaryList = copyList(pSecondList);
                        secondListIndex = -1; //so it exits the next iteration
                    }
                    else
                    {
                        productInt = (pFirstList[firstListIndex] * pSecondList[secondListIndex]) + carry;
                        carry = productInt / 10;
                        unit = productInt % 10;
                        intermidiaryList.Insert(0, (Int16)unit);
                    }
                      while (cerosRemaining != 0)
                    {
                        intermidiaryList.Add(0);
                        cerosRemaining--;
                    }
                }
                if (carry != 0)
                {
                    intermidiaryList.Insert(0, (Int16)carry);
                }
                if (intermidiaryList.Count != 0)
                {
                    addList(productList, intermidiaryList);
                }
                cerosToAdd++;//each time 1 cero extra to the right is added
            }
            return productList;
        }

        public static List<Int16> addList(List<Int16> pFirstList, List<Int16> pSecondList)//the result is stored in pFirstList
        {
            while (pFirstList.Count < pSecondList.Count)//in case second list is bigger than first list, first least is covered up with 0´s to the right
            {
                pFirstList.Insert(0, 0);
            }
            Boolean consecutiveOverflow;
            int firstListIndex = pFirstList.Count;
            int firstListIndexCopy = firstListIndex;
            int secondListIndex = pSecondList.Count;
            int smallestCount = Math.Min(pSecondList.Count, pFirstList.Count);
            int sum;
            while (smallestCount > 0)
            {
                smallestCount--;
                firstListIndex--;
                secondListIndex--;
                firstListIndexCopy = firstListIndex;
                consecutiveOverflow = true;
                if (pSecondList[secondListIndex] == 0)
                {
                    continue;
                }
                else
                {
                    sum = pFirstList[firstListIndex] + pSecondList[secondListIndex];
                    if (sum < 10)
                    {
                        pFirstList[firstListIndex] = (Int16)sum;
                    }
                    else
                    {
                        pFirstList[firstListIndex] = (Int16)(sum - 10);
                        while (consecutiveOverflow)//in case we have a number like 99999  which if its added with one it more replace all 9´s with 0 and add a 1, so the result its 100000
                        {
                            if (firstListIndexCopy != 0)
                            {
                                if (pFirstList[firstListIndexCopy - 1] != 9)
                                {
                                    pFirstList[firstListIndexCopy - 1] += 1;
                                    consecutiveOverflow = false;
                                }
                                else
                                {
                                    pFirstList[firstListIndexCopy - 1] = 0;
                                }
                            }
                            else
                            {
                                pFirstList.Insert(0, 1);
                                consecutiveOverflow = false;
                                firstListIndex++; //the list has grown
                            }
                            firstListIndexCopy--;
                        }
                    }
                }
            }
            return pFirstList;
        }


        public static List<Int16> restList(List<Int16> pFirstList, List<Int16> pSecondList)//subtracts the number in the first list minus the numers of the secondlist
        {
            return null;
        }


        public static Boolean compareList(List<Int16> pFirstList, List<Int16> pSecondList)
         //Return true if the number contained in firstList is larger or equal than the number in second list
        {
            if (pFirstList.Count > pSecondList.Count)
            {
                return true;
            }
            else if (pFirstList.Count < pSecondList.Count)
            {
                return false;
            }
            else
            {
                for (int numberIndex = 0; numberIndex < pFirstList.Count; numberIndex++)
                {
                    if (pFirstList[numberIndex] > pSecondList[numberIndex])
                    {
                        return true;
                    }
                    if (pFirstList[numberIndex] < pSecondList[numberIndex])
                    {
                        return false;
                    }
                }
                return true;//in the case they are exactly the same

            }
        }


        public static int threeRule(int pMin, int pMax , int pRelation)// To paint the current heigth in the view proportionate to the screen
        {
            return 0;
        }

        public static List<Point[]> waveDrawing(int pStartingX, int pEndingX, int pStartingY,int pWaveQuantity) //pStartingY designates where the wave originates 
        { 
            int waveLenght = (pEndingX - pStartingX) / pWaveQuantity; //pWaveQuantity would be an approximate
            List<Point[]> water=new List<Point[]>();
            while(pStartingX < pEndingX)
            {
                    Point[] singleWave ={new Point(pStartingX, pStartingY),
                                         new Point(pStartingX + waveLenght / 2, pStartingY-Constants.INCREMENTOFWAVES),
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

        public static ulong kmtometers(ulong pKilometers)
        {
            return pKilometers * 1000;
        }

    }
}
