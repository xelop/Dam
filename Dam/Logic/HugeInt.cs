using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam.Logic
{
    class HugeInt
    {
        /* This class is designed to manage unsigned huge numbers. It includes basic operations of: adding, subtraction and multiplication. */ 

        public HugeInt(String pNumber)
        {
            int numberToSplit;
            int maximunDigitsInUlong = 9;//we will be making groups of 9
            _Number = new List<ulong>();
            if (pNumber.Length == 0)
            {
                _Number.Add(0);
            }
            else
            {
                while (pNumber.Length != 0)
                {
                    numberToSplit = pNumber.Length - maximunDigitsInUlong;
                    if (numberToSplit < 0)
                    {
                        numberToSplit = 0;
                    }
                    try
                    {
                        _Number.Insert(0, ulong.Parse(pNumber.Substring(numberToSplit)));
                    }
                    catch (FormatException notNumber)//in case the number contained in the string, wasnt a number
                    {
                        _Number.Clear();
                        _Number.Add(0);
                        System.Windows.Forms.MessageBox.Show("Converting: "+ pNumber +" to huge integer was impossible because"+
                            " it isn´t a number. The value of the number would be set to 0");
                        break;
                    }
                    pNumber = pNumber.Remove(numberToSplit);
                }
            }
            takeOutNonSignificantZeroes();//in case the string came like: 0000000000000000001
        }

        public List<ulong> Number
        {
            get { return _Number; }
            set { _Number = value; }
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
                    while (intermediaryString.Length < 9)
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

        public Boolean greaterOrEqual(HugeInt pNumber)
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

        public void add(HugeInt pNumber)//adds to _Number the number contained in pNumber
        {
            if (_Number.Count < pNumber._Number.Count)
            {
                addZeroesToLeft(pNumber._Number.Count - _Number.Count); //_Number is covered up with 0´s to the left, until they are the same size
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
                if (sum < Constants.OVERFLOW_NUMBER)
                {
                    _Number[firstIndex] = sum;
                }
                else
                {
                    _Number[firstIndex] = (sum - Constants.OVERFLOW_NUMBER);
                    carry = 1;
                }
            }
            takeOutNonSignificantZeroes();
        }

        public void subtract(HugeInt pNumber)
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
                    if (rest < Constants.OVERFLOW_NUMBER)
                    {
                        _Number[firstIndex] = rest;
                    }
                    else
                    {
                        carry = 1;//it borrows 1 to the numbers to the left
                        _Number[firstIndex] = (rest + Constants.OVERFLOW_NUMBER);
                    }
                }
                takeOutNonSignificantZeroes();
            }
        }

        public void multiply(HugeInt pNumber)
        {
            HugeInt finalProduct = new HugeInt("0");
            HugeInt intermidiaryNumber = new HugeInt("0"); ;//used as a repositiory for the little sums
            ulong productUlong = 0;
            ulong carry = 0;
            ulong unit = 0;
            int ZeroesToAdd = 0;//ceros added to the right to each little sum each iteration
            for (int firstIndex = _Number.Count - 1; firstIndex >= 0; firstIndex--)
            {
                carry = 0;
                intermidiaryNumber._Number.Clear();//refresh, to clean the last little sum
                for (int secondListIndex = pNumber._Number.Count - 1; secondListIndex >= 0; secondListIndex--)
                {
                    productUlong = (_Number[firstIndex] * pNumber._Number[secondListIndex]) + carry;
                    carry = productUlong / Constants.OVERFLOW_NUMBER;
                    unit = productUlong % Constants.OVERFLOW_NUMBER;
                    intermidiaryNumber._Number.Insert(0, (ulong)unit);
                }
                intermidiaryNumber.addZeroesToRight(ZeroesToAdd);
                if (carry != 0)//if one single carry remained to be added
                {
                    intermidiaryNumber._Number.Insert(0, (ulong)carry);
                }
                finalProduct.add(intermidiaryNumber);//each iteration, 1 little sum is added to the total of little sums
                ZeroesToAdd++;//each time 1 cero extra to the right is added
            }
            _Number = finalProduct._Number;
        }

        public void oneHundredDivision()
        {
            ulong numbersToAdd;
            if (_Number != null)
            {
                for (int firstIndex = _Number.Count - 1; firstIndex > 0; firstIndex--)
                {
                    numbersToAdd = (_Number[firstIndex - 1] % 100) * 10000000; //we are adding 8 0´s to the right
                    _Number[firstIndex] = _Number[firstIndex] / 100 + numbersToAdd;
                }
                _Number[0] = _Number[0] / 100;
                takeOutNonSignificantZeroes();
            }
        }

        private void addZeroesToRight(int pAmountOfZeroes)
        {
            while (pAmountOfZeroes != 0)
            {
                _Number.Add(0);
                pAmountOfZeroes--;
            }
        }

        private void addZeroesToLeft(int pAmountOfZeroes)
        {
            while (pAmountOfZeroes != 0)
            {
                _Number.Insert(0, 0);
                pAmountOfZeroes--;
            }
        }

        private void takeOutNonSignificantZeroes()
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

        private List<ulong> _Number;
    }
}
