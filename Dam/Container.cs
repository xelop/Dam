using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam
{
    class Container
    {
        private Int16[] _CurrentVolume; //arreglo para repesentar con exactitud numeros grandes
        ulong _MinHeigth, _MaxHeigth, _Width, _Long, _CurrentHeigth;


        public Container(String pHeigth, String pWidth, String pLong)
        {

        }

        public void calculateVolume()
        {
            
        }
        //public String getVolumeString(); //metodo para representarlo en la interfaz

        public void addWater(Int32 pWater)
        {

        }

        public Boolean checkMinimunCapacity()
        {
            return true;
        }

        public Int16[] currentVolume
        {
            get
            {
                return _CurrentVolume;
            }
            set
            {
                _CurrentVolume = value;
            }
        }

        public ulong currentHeigth
        {
            get { return _CurrentHeigth; }
            set { _CurrentHeigth = value; }
        }

        public ulong Long
        {
            get { return _Long; }
            set { _Long = value; }
        }

        public ulong width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        public ulong maxHeigth
        {
            get { return _MaxHeigth; }
            set { _MaxHeigth = value; }
        }

        public ulong minHeigth
        {
            get { return _MinHeigth; }
            set { _MinHeigth = value; }
        }

    }
}
