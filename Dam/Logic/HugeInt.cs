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
        {// N = Amount of digits in pNumber / 9
            int numberToSplit;//it is an index within pNumber
            int maximunDigitsInUlong = 9;//we will be making groups of 9 //1
            _Number = new List<ulong>();//1 + 2 + 2 = 5
            if (pNumber.Length == 0)//1 //case : empty string 
            {
                _Number.Add(0);//2 + 2 + 1 = 5
            }
            else//<-- choosed
            {
                while (pNumber.Length != 0) //1
                {
                    numberToSplit = pNumber.Length - maximunDigitsInUlong;//1 + 1 = 2
                    if (numberToSplit < 0)//1
                    {
                        numberToSplit = 0;//1
                    }
                    try//nos quedamos con el try ya que dura mas
                    {
                        _Number.Insert(0, ulong.Parse(pNumber.Substring(numberToSplit)));//2 + 2 + 2 + 2 + 2 + 1 + 2 + 2 + 1 = 16
                    }
                    catch (FormatException notANumber)//in case the number contained in the string, wasnt a number
                    {
                        FileManagement.addToFile(notANumber.Message);
                        _Number.Clear();// 2 + 2 = 4
                        _Number.Add(0);// 2 + 2 + 1 = 5
                        //System.Windows.Forms.MessageBox.Show("Converting: "+ pNumber +" to huge integer was impossible because"+
                        //    " it isn´t a number. The value of the number would be set to 0.");// ?
                        break;// 1
                    }
                    pNumber = pNumber.Remove(numberToSplit);// 1 + 2 + 2 + 1 = 6
                }
            }
            takeOutNonSignificantZeroes();//in case the string came like: 0000000000000000001 // log9(N) + 2 + 2
        }//F(N) = 10 + N + [27(N)]
        //O(N) = N

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
        {//N = _Number´s size // M = pNumber size
            if (_Number.Count < pNumber._Number.Count)// 1
            {
                addZeroesToLeft(pNumber._Number.Count - _Number.Count); //_Number is covered up with 0´s to the left, until they are the same size // |(N - M)| + 2 + 2 + 1 + 1
            }
            int firstIndex = _Number.Count;//1
            int secondIndex = pNumber._Number.Count;//1
            ulong sum;
            ulong carry = 0;//1
            ulong operand2 = 0;//1
            while (secondIndex > 0 || carry == 1)//3
            {
                firstIndex--;//2
                secondIndex--;//2
                if (firstIndex < 0)//in case the _Number have to grow in size because of the carry //1
                {
                    firstIndex = 0;//1
                    _Number.Insert(0, 0);//2 + 2 + 2 = 6
                }
                if (secondIndex >= 0)//1
                {//the if statement is elected because it longers more
                    operand2 = pNumber._Number[secondIndex];//2
                }
                else
                {
                    operand2 = 0;//1
                }
                sum = _Number[firstIndex] + operand2 + carry;// 1 + 1 + 1 + 1 = 4
                carry = 0;//1
                if (sum < Constants.OVERFLOW_NUMBER)//1
                {
                    _Number[firstIndex] = sum;//2
                }
                else//<-- elected
                {
                    _Number[firstIndex] = (sum - Constants.OVERFLOW_NUMBER);//1 + 1 +1 = 3
                    carry = 1;//1
                }
            }
            takeOutNonSignificantZeroes();//N + 2 + 2
            //F(N) = 15 + |(N-M)| + 28N + N
            //O(N)= N
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
                takeOutNonSignificantZeroes();//100-1 = 099
            }
        }

        public void multiply(HugeInt pNumber)
        {//L = _Number size ; M = pNumber size // N = L * M
            HugeInt finalProduct = new HugeInt("0");//1 + 2 + 2 + 1 = 6
            HugeInt intermidiaryNumber = new HugeInt("0"); ;//1 + 2 + 2 + 1 = 6//used as a repositiory for the little sums
            ulong productUlong = 0;//1
            ulong carry = 0;//1
            ulong unit = 0;//1
            int ZeroesToAdd = 0;//ceros added to the right to each little sum each iteration //1
            for (int firstIndex = _Number.Count - 1; firstIndex >= 0; firstIndex--)//2 + 3 // iterates N
            {
                carry = 0;//1
                intermidiaryNumber._Number.Clear();//refresh, to clean the last little sum // 2 + 2 = 4
                for (int secondListIndex = pNumber._Number.Count - 1; secondListIndex >= 0; secondListIndex--)// 1 + 1 + 1 + 2 = 5 //iterates M
                {
                    productUlong = (_Number[firstIndex] * pNumber._Number[secondListIndex]) + carry;//1 + 1 + 1 + 1 + 1 = 5
                    carry = productUlong / Constants.OVERFLOW_NUMBER;// 1 + 2 = 3
                    unit = productUlong % Constants.OVERFLOW_NUMBER;// 1 + 2 = 3
                    intermidiaryNumber._Number.Insert(0, unit);//2 + 2 + 2 = 6
                }
                intermidiaryNumber.addZeroesToRight(ZeroesToAdd);// (L - 1) 2 + 2 + 1
                if (carry != 0)//if one single carry remained to be added  // 1
                {
                    intermidiaryNumber._Number.Insert(0, carry);//2 + 2 + 2 = 6
                }
                finalProduct.add(intermidiaryNumber);//each iteration, 1 little sum is added to the total of little sums // (L*M) + 2 + 2 + 1
                ZeroesToAdd++;//each time 1 cero extra to the right is added // 2
            }
            _Number = finalProduct._Number; // 1
        }//F(N) =  18 + [49*(L*M)(L*M)(L-1)] = 18 + 49(N^2(L-1)) = 18 + 49N^2L - 49N^2
        //O(N) = N^2

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
        {// N = Amount of zeroes
            while (pAmountOfZeroes != 0)//1
            {
                _Number.Add(0);//2 + 2 + 1 = 5
                pAmountOfZeroes--;// 2
            }//F(N) = 8N
            //O(N) = N
        }

        private void addZeroesToLeft(int pAmountOfZeroes)
        {// N = pAmountOfZeroes 
            while (pAmountOfZeroes != 0)//1
            {
                _Number.Insert(0, 0);// 2 + 2 + 2 = 6
                pAmountOfZeroes--;//2
            }//F(N) = 9N
            //O(N) = N
        }

        private void takeOutNonSignificantZeroes()
        {//N =  _Number 's size
            int listSize = _Number.Count;//1
            for (int numberIndex = 0; numberIndex < listSize; numberIndex++)// 1 + 3
            {
                if (_Number[0] == 0 && _Number.Count > 1)//1 + 1 + 1 + 1 = 4 ;//in the worst case the list will look like 00000000000000000000 and the whole list is iterated
                {
                    _Number.RemoveAt(0);//2 + 2 + 1 = 5
                }
                else
                {
                    break;//1
                }
            }
        }
        //F(N)= 2 + 12N
        //O(N)= N
        private List<ulong> _Number;
    }

}
