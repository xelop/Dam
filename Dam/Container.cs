using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam
{
    class Container:Convertible
    {
        private Int16[] _CurrentVolume; //arreglo para repesentar con exactitud numeros grandes
        ulong _MinHeigth, _MaxHeigth, _Width, _Long, _CurrentHeigth;

        public Container(String pHeigth, String pWidth, String pLong)
        {

        }

        public void calculateVolume()
        {
            
        }
        public String getVolumeString(); //metodo para representarlo en la interfaz

        public void addWater(Int32 pWater)
        {

        }

        public Boolean checkMinimunCapacity()
        {
            return true;
        }

    }
}
