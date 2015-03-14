using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam
{
    interface Convertible
    {
        public String arrayToString(Int16[] pArray);

        public Int16[] stringToArray(String pNumber);

        public Int16[] multiplyArray(Int16[] pFirstArray, Int16[] pSecondArray);

        public Int16[] addArray(Int16[] pFirstArray, Int16[] pSecondArray);
    }
}
