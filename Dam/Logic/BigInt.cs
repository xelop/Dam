using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam.Logic
{
    class BigInt
    {
        private List<ulong> _Number;

        public BigInt(String pNumber)
        {
            int numberToSplit;
            int maximunDigitsInUlong = 9;//we will be making groups of 9
            _Number = new List<ulong>();
            while (pNumber.Length != 0)
            {
                numberToSplit = pNumber.Length - maximunDigitsInUlong;
                if (numberToSplit < 0)
                {
                    numberToSplit = 0;
                }
                _Number.Insert(0, ulong.Parse(pNumber.Substring(numberToSplit)));
                pNumber = pNumber.Remove(numberToSplit);
            }
        }    
        
        public string toString()
        {
            String result = "";
            String intermediaryString = "";
            for (int numberPosition = 0; numberPosition < _Number.Count; numberPosition++)
            {
                if (numberPosition != 0)
                {
                    intermediaryString = _Number[numberPosition].ToString(); //refresh
                    while (intermediaryString.Length != 9)
                    {
                        intermediaryString = intermediaryString.Insert(0, "0");//if we have a 1 , but the real is 000000001, so the representation is correct
                    }
                    result += intermediaryString;
                }
                else
                {
                    result += _Number[numberPosition].ToString();
                }
            }
            return result;
        }

        public void takeOutNonSignificantCeroes()
        {
            int listSize = _Number.Count;
            for (int numberIndex = 0; numberIndex < listSize; numberIndex++)
            {
                if (_Number[0] == 0 && _Number.Count > 1)
                {
                    _Number.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }
        }

        public Boolean greaterOrEqual(BigInt pNumber)
        {
            if (_Number.Count > pNumber._Number.Count)
            {
                return true;
            }
            else if (_Number.Count < pNumber._Number.Count)
            {
                return false;
            }
            else
            {
                for (int numberIndex = 0; numberIndex < _Number.Count; numberIndex++)//both are the same size
                {
                    if (_Number[numberIndex] > pNumber._Number[numberIndex])
                    {
                        return true;
                    }
                    if (_Number[numberIndex] < pNumber._Number[numberIndex])
                    {
                        return false;
                    }
                }
                return true;//in the case they are exactly the same number

            }
        }

        public void add(BigInt pNumber)//adds to _Number the number contained in pNumber
        {
            while (_Number.Count < pNumber._Number.Count)//_Number is covered up with 0´s to the left, until they are the same size
            {
                _Number.Insert(0, 0);
            }
            int firstIndex = _Number.Count;
            int secondIndex = pNumber._Number.Count;
            ulong sum;
            ulong carry = 0;
            ulong operand2 = 0;
            while (secondIndex > 0 || carry == 1)
            {
                firstIndex--;
                secondIndex--;
                if (firstIndex < 0)//in case the _Number have to grow in size because of the carry
                {
                    firstIndex = 0;
                    _Number.Insert(0, 0);
                }
                if (secondIndex >= 0)
                {
                    operand2 = pNumber._Number[secondIndex];
                }
                else
                {
                    operand2 = 0;
                }
                sum = _Number[firstIndex] + operand2 + carry;
                carry = 0;
                if (sum < 1000000000)
                {
                    _Number[firstIndex] = sum;
                }
                else
                {
                    _Number[firstIndex] = (sum - 1000000000);
                    carry = 1;
                }
            }
        }

        public void multiply(BigInt pNumber)
        {
            BigInt finalProduct = new BigInt("0");
            BigInt intermidiaryNumber = new BigInt("0"); ;//used as a repositiory for the little sums
            ulong productUlong = 0;
            ulong carry = 0;
            ulong unit = 0;
            int cerosToAdd = 0;//ceros added to the right to each little sum each iteration
            int cerosRemaining;
            for (int firstIndex = _Number.Count - 1; firstIndex >= 0; firstIndex--)
            {
                carry = 0;
                intermidiaryNumber._Number.Clear();//refresh, to clean the last little sum
                cerosRemaining = cerosToAdd;
                for (int secondListIndex = pNumber._Number.Count - 1; secondListIndex >= 0; secondListIndex--)
                {
                    productUlong = (_Number[firstIndex] * pNumber._Number[secondListIndex]) + carry;
                    carry = productUlong / Constants.OVERFLOW_NUMBER;
                    unit = productUlong % Constants.OVERFLOW_NUMBER;
                    intermidiaryNumber._Number.Insert(0, (ulong)unit);
                }

                while (cerosRemaining != 0)
                {
                    intermidiaryNumber._Number.Add(0);
                    cerosRemaining--;
                }

                if (carry != 0)//if one single carry remained to be added
                {
                    intermidiaryNumber._Number.Insert(0, (ulong)carry);
                }
                finalProduct.add(intermidiaryNumber);//each iteration, 1 little sum is added to the total of little sums
                cerosToAdd++;//each time 1 cero extra to the right is added
            }
            _Number = finalProduct._Number;
        }


        public void subtract(BigInt pNumber )
        {
            if (this.greaterOrEqual(pNumber))//minuend must be greater than subtrahend
            {
                int firstIndex = _Number.Count;
                int secondIndex = pNumber.Number.Count;
                ulong rest;
                ulong carry = 0;
                ulong subtrahend;
                while (secondIndex > 0 || carry == 1)
                {
                    firstIndex--;
                    secondIndex--;
                    if (secondIndex >= 0)
                    {
                        subtrahend = pNumber.Number[secondIndex];
                    }
                    else
                    {
                        subtrahend = 0;
                    }
                    rest = _Number[firstIndex] - subtrahend - carry;
                    carry = 0;
                    if (rest >= 0)
                    {
                        _Number[firstIndex] = rest;
                    }
                    else
                    {
                        carry = 1;//it borrows 1 to the numbers to the left
                        _Number[firstIndex] = (rest + 10);
                    }
                }
                this.takeOutNonSignificantCeroes();
            }
        }

        public List<ulong> Number
        {
            get { return _Number; }
            set { _Number = value; }
        }


    }
}
