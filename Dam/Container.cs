using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam
{
    class Container
    {
        private Int16[] _CurrentVolume, Int16[] _MaxVolume; //arreglo para repesentar con exactitud numeros grandes
        private ulong _MinHeigth, _MaxHeigth, _Width, _Long, _CurrentHeigth;


        public Container(ulong pMaxHeigth, ulong pMinHeight,ulong pWidth, ulong pLong)
        {
            _MaxHeigth = pMaxHeigth;
            _MinHeigth = pMinHeight;
            _Width = pWidth;
            _Long = pLong;
            calculateVolume();

        }

        public void calculateVolume()
        {
            
        }
        //public String getVolumeString(); //metodo para representarlo en la interfaz

        public void addWater(Int32 pWater)
        {
            Converter.stringToArray(pWater.ToString());
        }

        public void removeWater(Int16 pWater)
        {
            
        }


        public Boolean checkMinCapacity()
        {
            return _MinHeigth > _CurrentHeigth;
        }
        public Boolean checkMaxCapacity()
        {
            return _CurrentHeigth > _MaxHeigth;
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
