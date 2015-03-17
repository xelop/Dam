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
            int cerosToAdd = 0;//ceros added to the right to each little sum each iteration
            int cerosRemaining;
            for (int firstListIndex = pFirstList.Count - 1 ; firstListIndex  >= 0; firstListIndex--)
            {
                carry = 0;
                intermidiaryList.Clear();//refresh, to clean the last little sum
                cerosRemaining = cerosToAdd;
                for (int secondListIndex = pSecondList.Count - 1; secondListIndex >= 0; secondListIndex--)
                {
                    if (pFirstList[firstListIndex] == 0)//multiply by 0, no little sum need to do
                    {
                        break;
                    }
                    if (pFirstList[firstListIndex] == 1)//multiply by 1, just copy the list and add it
                    {
                        intermidiaryList = copyList(pSecondList);
                        secondListIndex = -1; //so it exits the next iteration, yet it need to add ceros to the right
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
                if (carry != 0)//if one single carry remained to be added
                {
                    intermidiaryList.Insert(0, (Int16)carry);
                }
                if (intermidiaryList.Count != 0)
                {
                    addList(productList, intermidiaryList);//each iteration, 1 little sum is added to the total of little sums
                }
                cerosToAdd++;//each time 1 cero extra to the right is added
            }
            return productList;
        }

        public static List<Int16> addList(List<Int16> pFirstList, List<Int16> pSecondList)//the result is stored in pFirstList
        {
            while (pFirstList.Count < pSecondList.Count)//in case the second list is bigger than first list, firstList is covered up with 0´s to the right
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
                if (pSecondList[secondListIndex] == 0)//adding a 0
                {
                    continue;//no need to add it :)
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
                        while (consecutiveOverflow)//in case we have a number like 99999;  which if its added with 1 it replace all 9´s with 0 and add a 1, so the result its 100000
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


        public static List<Int16> subtractList(List<Int16> pFirstList, List<Int16> pSecondList)//subtracts the number in the first list minus the numers of the secondlist
        {
            if (compareList(pFirstList, pSecondList))//minuend must be greater than subtrahend
            {
                int firstListIndex = pFirstList.Count;
                int secondListIndex = pSecondList.Count;
                int smallestCount = secondListIndex;
                int rest;
                int carry = 0;
                int subtrahend;
                while (smallestCount > 0 || carry == 1)
                {
                    smallestCount--;
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
                    if (subtrahend == 0 && carry == 0)
                    {
                        continue;
                    }
                    else
                    {
                        rest = pFirstList[firstListIndex] - subtrahend - carry;
                        carry = 0;
                        if (rest >= 0)
                        {
                            pFirstList[firstListIndex] = (Int16)rest;
                        }
                        else
                        {
                            carry = 1;//it borrows 1 to the numbers to the left
                            pFirstList[firstListIndex] = (Int16)(rest + 10);
                        }
                    }
                }
                takeOutNonSignificantCeroes(pFirstList);
            }
            return pFirstList;
        }

        public static List<Int16> takeOutNonSignificantCeroes(List<Int16> pList)
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


        public static int threeRule(int pMin, int pMax , int pMinRelation)// To paint the current heigth in the view proportionate to the screen
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

        public static List<Int16> calculateVolume(ulong pHeight, ulong pWidth, ulong pLong)//parameters enter as m
        {
            pHeight = pHeight * 100;
            pWidth = pWidth * 100;
            pLong = pLong * 100;//meters are converted into cm
            List<Int16> volume = new List<Int16>();
            volume.Add(1);
            List<ulong> dimensions = new List<ulong>();
            dimensions.Add(pHeight);
            dimensions.Add(pWidth);
            dimensions.Add(pLong);
            ulong dimension1 = 0;
            ulong dimension2 = 0;
            int counter = dimensions.Count - 1;
            while (counter > 0)
            {
                dimension1 = (dimensions.Min());
                dimensions.Remove(dimension1);
                if (dimensions.Count > 0)
                {
                    dimension2 = (dimensions.Min());
                    dimensions.Remove(dimension2);//this way we get the minimun dimensions
                }
                else
                {
                    dimension2 = 1;
                }
                try
                {
                    checked
                    {

                        volume = multiplyList(volume , stringToList((dimension1 * dimension2).ToString()));
                    }
                }
                catch (OverflowException e)//the number is huge, we will require to multiply them using lists
                {
                    volume = multiplyList(volume , multiplyList(stringToList(dimension1.ToString()) , stringToList(dimension2.ToString())));
                }
                counter--;
            }
            
 
            return volume;
        }

        public static ulong kmToMeters(ulong pKilometers)
        {
            return pKilometers * 1000;
        }
    }
}
