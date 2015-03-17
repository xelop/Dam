using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam
{
    class Container
    {
        private List<Int16> _CurrentVolume; 
        private List<Int16> _MaxVolume;//volumes are in cm3
        private List<Int16> _MinVolume;//arrays used to display huge numbers
        private ulong _MinHeigth, _MaxHeigth, _Width, _Long, _CurrentHeigth;//dimensions are in m3


        public Container(ulong pMaxHeight, ulong pMinHeight, ulong pWidth, ulong pLong)
        {
            _MaxHeigth = pMaxHeight;
            _MinHeigth = pMinHeight;
            _Width = pWidth;
            _Long = pLong;
            _MaxVolume = Converter.calculateVolume(pMaxHeight, pWidth, pLong);
            _MinVolume = Converter.calculateVolume(pMinHeight, pWidth, pLong);
            _CurrentVolume = Converter.calculateVolume(pMinHeight + ((pMaxHeight - pMinHeight) / 2), pWidth, pLong);//container starts filled up above the minimun half by half the diference of the min and max height
            _CurrentHeigth = pMinHeight + (pMaxHeight - pMinHeight) / 2;

        }



        public void addWater(Int32 pWater) //pWater enters method as meters^3
        {
            Converter.addList(_CurrentVolume, Converter.stringToList(pWater.ToString()+ "000000"));//converted in cm3
            if (waterOverflow())
            {
                _CurrentVolume = Converter.copyList(_MaxVolume);
                throw new Exception("The water overflowed the maximun capacity of the tank. Dam´s water entrance will be paused for a moment.");
            }

        }

        public void removeWater(Int32 pWater)//pWater enters method as meters^3
        {
            Converter.subtractList(_CurrentVolume, Converter.stringToList(pWater.ToString() + "000000"));//converted in cm3
            if (minCapacity())
            {
                _CurrentVolume = Converter.copyList(_MinVolume);
                throw new Exception("The dam´s water level is at its minimum capacity. Dam´s operation will be paused for a moment");
            }
        }


        public Boolean minCapacity()
        {
            return Converter.compareList(_MinVolume , _CurrentVolume);
        }
        public Boolean waterOverflow()
        {
            return Converter.compareList(_CurrentVolume, _MaxVolume);
        }

        public List<Int16> CurrentVolume
        {
            get { return _CurrentVolume; }
            set { _CurrentVolume = value; }
        }

        public List<Int16> MaxVolume
        {
            get { return _MaxVolume; }
            set { _MaxVolume = value; }
        }

        public List<Int16> MinVolume
        {
            get { return _MinVolume; }
            set { _MinVolume = value; }
        }

        public ulong CurrentHeigth
        {
            get { return _CurrentHeigth; }
            set { _CurrentHeigth = value; }
        }

        public ulong Long
        {
            get { return _Long; }
            set { _Long = value; }
        }

        public ulong Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        public ulong MaxHeigth
        {
            get { return _MaxHeigth; }
            set { _MaxHeigth = value; }
        }

        public ulong MinHeigth
        {
            get { return _MinHeigth; }
            set { _MinHeigth = value; }
        }

    }
}
