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
    {//Siempre poner try y catch??
        public static String listToString(List<ulong> pList)
        {
            String result = "";
            String intermediaryString ="";
            for (int numberPosition = 0; numberPosition < pList.Count; numberPosition++)
            {
                if (numberPosition != 0)
                {
                    intermediaryString = pList[numberPosition].ToString(); //refresh
                    while (intermediaryString.Length != 9)
                    {
                        intermediaryString = intermediaryString.Insert(0, "0");
                    }
                    result += intermediaryString;
                }
                else
                {
                    result += pList[numberPosition].ToString();
                }
            }
            return result;
        }

        public static List<ulong> stringToList(String pNumber)
        {
            int numberToSplit;
            int maximunDigitsInUlong = 9;
            List<ulong> listOfNumbers = new List<ulong>();
            while (pNumber.Length != 0)
            {
                numberToSplit = pNumber.Length - maximunDigitsInUlong;
                if (numberToSplit < 0)
                {
                    numberToSplit = 0;
                }
                listOfNumbers.Insert(0, ulong.Parse(pNumber.Substring(numberToSplit)));
                pNumber = pNumber.Remove(numberToSplit);
            }
            
            return listOfNumbers;
        }

        public static List<ulong> copyList(List<ulong> listToCopy)//make an exact copy of a list
        {
            List<ulong> newList = new List<ulong>();
            for (int numberIndex = 0 ; numberIndex < listToCopy.Count; numberIndex++)
            {
                newList.Add(listToCopy[numberIndex]);
            }
            return newList;
        }

        public static List<ulong> multiplyList(List<ulong> pFirstList, List<ulong> pSecondList)
        {
            List<ulong> productList = new List<ulong>();
            productList.Add(0);
            List<ulong> intermidiaryList = new List<ulong>();//used as a repositiory for the little sums between pFirsList and PsecondList
            ulong productInt = 0;
            ulong carry = 0;
            ulong unit = 0;
            int cerosToAdd = 0;//ceros added to the right to each little sum each iteration
            int cerosRemaining;
            for (int firstListIndex = pFirstList.Count - 1 ; firstListIndex  >= 0; firstListIndex--)
            {
                carry = 0;
                intermidiaryList.Clear();//refresh, to clean the last little sum
                cerosRemaining = cerosToAdd;
                for (int secondListIndex = pSecondList.Count - 1; secondListIndex >= 0; secondListIndex--)
                {
                    productInt = (pFirstList[firstListIndex] * pSecondList[secondListIndex]) + carry;
                    carry = productInt / 1000000000;
                    unit = productInt % 1000000000;
                    intermidiaryList.Insert(0, (ulong)unit);
                    while (cerosRemaining != 0)
                    {
                        intermidiaryList.Add(0);
                        cerosRemaining--;
                    }
                }
                if (carry != 0)//if one single carry remained to be added
                {
                    intermidiaryList.Insert(0, (ulong)carry);
                }
                addList(productList, intermidiaryList);//each iteration, 1 little sum is added to the total of little sums
                cerosToAdd++;//each time 1 cero extra to the right is added
            }
            return productList;
        }

        public static List<ulong> addList(List<ulong> pFirstList, List<ulong> pSecondList)//the result is stored in pFirstList
        {
            while (pFirstList.Count < pSecondList.Count)//in case the second list is bigger than first list, firstList is covered up with 0´s to the left
            {
                pFirstList.Insert(0, 0);
            }
            int firstListIndex = pFirstList.Count;
            int secondListIndex = pSecondList.Count;
            ulong sum;
            ulong carry = 0;
            ulong operand2 = 0;
            while (secondListIndex > 0 || carry == 1)
            {
                firstListIndex--;
                secondListIndex--;
                if (firstListIndex < 0)//in case the list have to grow in size because the carry
                {
                    firstListIndex = 0;
                    pFirstList.Insert(0, 0);
                }
                if (secondListIndex >= 0)
                {
                    operand2 = pSecondList[secondListIndex];
                }
                else
                {
                    operand2 = 0;
                }
                sum = pFirstList[firstListIndex] + operand2 + carry;
                carry = 0;
                if (sum < Constants.OVERFLOW_NUMBER)
                {
                    pFirstList[firstListIndex] = sum;
                }
                else
                {
                    pFirstList[firstListIndex] = (sum - Constants.OVERFLOW_NUMBER);
                    carry = 1;
                }
            }
            return pFirstList;
        }


        public static List<ulong> subtractList(List<ulong> pFirstList, List<ulong> pSecondList)//subtracts the number in the first list minus the numers of the secondlist
        {
            if (compareList(pFirstList, pSecondList))//minuend must be greater than subtrahend
            {
                int firstListIndex = pFirstList.Count;
                int secondListIndex = pSecondList.Count;
                ulong rest;
                ulong carry = 0;
                ulong subtrahend;
                while (secondListIndex > 0 || carry == 1)
                {
                    firstListIndex--;
                    secondListIndex--;
                    if (secondListIndex >= 0)
                    {
                        subtrahend = pSecondList[secondListIndex];
                    }
                    else
                    {
                        subtrahend = 0;
                    }
                    rest = pFirstList[firstListIndex] - subtrahend - carry;
                    carry = 0;
                    if (rest >= 0)
                    {
                        pFirstList[firstListIndex] = rest;
                    }
                    else
                    {
                        carry = 1;//it borrows 1 to the numbers to the left
                        pFirstList[firstListIndex] = (rest + 10);
                    }
                }
                takeOutNonSignificantCeroes(pFirstList);
            }
            return pFirstList;
        }

        public static List<ulong> takeOutNonSignificantCeroes(List<ulong> pList)
        {
            int listSize = pList.Count;
            for (int numberIndex = 0; numberIndex < listSize; numberIndex++)
            {
                if (pList[0] == 0 && pList.Count > 1)
                {
                    pList.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }
            return pList;
        }


        public static Boolean compareList(List<ulong> pFirstList, List<ulong> pSecondList)
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


        public static ulong threeRule(ulong pMin, ulong pMax , ulong pMinRelation)// To paint the current heigth in the view proportionate to the screen
        {
            return pMinRelation*pMax/pMin;
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

        public static BigInt calculateHugeVolume(ulong pHeight, ulong pWidth, ulong pLong)//parameters enter as m
        {
            pHeight = metersToCentimeters(pHeight);
            pWidth = metersToCentimeters(pWidth);
            pLong = metersToCentimeters(pLong);
            BigInt volume = new BigInt(pHeight.ToString());
            volume.multiply(new BigInt(pWidth.ToString()));
            volume.multiply(new BigInt(pLong.ToString()));
            return volume;
        }

        public static ulong kmToMeters(ulong pKilometers)
        {
            return pKilometers * 1000;
        }

        public static ulong metersToCentimeters(ulong pMeters)
        {
            return pMeters * 100;
        }
    }
}
