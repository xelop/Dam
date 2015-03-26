using Dam.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam
{
    class Container:IObserver
    {
        private HugeInt _CurrentVolume; 
        private HugeInt _MaxVolume;//volumes are in cm3
        private HugeInt _MinVolume;
        private ulong _MinHeigth, _MaxHeigth, _Width, _Long, _CurrentHeigth;//dimensions are in m
        private Boolean _WaterOverflow, _lowCapacity;

        public Container(ulong pMaxHeight, ulong pMinHeight, ulong pWidth, ulong pLong)
        {
            _MaxHeigth = pMaxHeight;
            _MinHeigth = pMinHeight;
            _Width = pWidth;
            _Long = pLong;
            _MaxVolume = Converter.calculateHugeVolume(pMaxHeight, pWidth, pLong);
            _MinVolume = Converter.calculateHugeVolume(pMinHeight, pWidth, pLong);
            _CurrentVolume = Converter.calculateHugeVolume(pMinHeight + ((pMaxHeight - pMinHeight) / 2), pWidth, pLong);//container starts filled up above the minimun half by half the diference of the min and max height
            _CurrentHeigth = pMinHeight + (pMaxHeight - pMinHeight) / 2;
            _WaterOverflow = false;
            _lowCapacity = false;
        }



        public void addWater(ulong pWater) //pWater enters method as meters^3
        {
            _CurrentVolume.add(new HugeInt(pWater.ToString()+ "000000"));//converted in cm3
            if (waterOverflow())
            {
                _CurrentVolume = _MaxVolume;
                _WaterOverflow = true;
            }
        }

        public void removeWater(ulong pWater)//pWater enters method as meters^3
        {
            _CurrentVolume.subtract(new HugeInt (pWater.ToString() + "000000"));//converted in cm3
            if (notEnoughWater())
            {
                _CurrentVolume = _MinVolume;
                _lowCapacity = true;
                throw new Exception("The dam´s water level is at its minimum capacity. Dam´s operation will be paused for a moment");
            }
        }

        public void update(IObservable pOservable)
        {

        }

        public Boolean notEnoughWater()
        {
            return _MinVolume.greaterOrEqual(_CurrentVolume);
        }

        public Boolean waterOverflow()
        {
            return _CurrentVolume.greaterOrEqual(_MaxVolume);
        }

        public HugeInt CurrentVolume
        {
            get { return _CurrentVolume; }
            set { _CurrentVolume = value; }
        }

        public HugeInt MaxVolume
        {
            get { return _MaxVolume; }
            set { _MaxVolume = value; }
        }

        public HugeInt MinVolume
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

        public Boolean LowCapacity
        {
            get { return _lowCapacity; }
            set { _lowCapacity = value; }
        }

        public Boolean WaterOverflow
        {
            get { return _WaterOverflow; }
            set { _WaterOverflow = value; }
        }
    }
}
