using Dam.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam
{
    class Container
    {/*Class in charge to represent an container that can store matter, including its volume and its dimensions, that can change dynamically
        when adding or removig matter.*/

        public Container(ulong pMaxHeight, ulong pMinHeight, ulong pWidth, ulong pLong)
        {
            _MaxHeigth = pMaxHeight;
            _MinHeigth = pMinHeight;
            _Width = pWidth;
            _Long = pLong;
            _MaxVolume = Converter.calculateHugeVolume(pMaxHeight, pWidth, pLong);
            _MinVolume = Converter.calculateHugeVolume(pMinHeight, pWidth, pLong);
            calculateSignificantChange();
            _CurrentVolume = Converter.calculateHugeVolume(((pMaxHeight - pMinHeight) / 2) + pMinHeight, pWidth, pLong); //the half between max and min height
            _CurrentNoticeableVolume = new HugeInt(_CurrentVolume.toString());
            _CurrentHeigth = ((pMaxHeight - pMinHeight) / 2) +pMinHeight;
            _VolumePercentage = _CurrentHeigth * 100 / _MaxHeigth;
            _WaterOverflow = false;
            _lowCapacity = false;
            _SignificanceVolumeChanged = false; 
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

        public Boolean SignificanceVolumeChanged
        {
            get { return _SignificanceVolumeChanged; }
            set { _SignificanceVolumeChanged = value; }
        }

        public ulong VolumePercentage
        {
            get { return _VolumePercentage; }
            set { _VolumePercentage = value; }
        }

        public HugeInt CurrentNoticeableVolume
        {
            get { return _CurrentNoticeableVolume; }
            set { _CurrentNoticeableVolume = value; }
        }

        public void addWater(ulong pWater) //pWater enters method as meters^3
        {
            _CurrentVolume.add(new HugeInt(pWater.ToString()+ "000000"));//converted in cm3
            if (waterOverflow())
            {
                _CurrentVolume = new HugeInt(_MaxVolume.toString());
                _WaterOverflow = true;
                _VolumePercentage = 100;
                _CurrentHeigth = _MaxHeigth;
                _CurrentNoticeableVolume= new HugeInt(_MaxVolume.toString());
                _SignificanceVolumeChanged = true;
            }
            else
            {
                _CurrentNoticeableVolume.add(_SignificantDiference);
                while (_CurrentVolume.greaterOrEqual(_CurrentNoticeableVolume))
                {
                    _VolumePercentage++;
                    _CurrentHeigth = Converter.threeRule(_VolumePercentage, _MaxHeigth);
                    _SignificanceVolumeChanged = true;
                    _CurrentNoticeableVolume.add(_SignificantDiference);
                }
                _CurrentNoticeableVolume.subtract(_SignificantDiference);
            }
        }

        public void calculateHeight(ulong pWaterOut, ulong pWaterIn)
        {
            if (pWaterIn != 0)
            {
                if (pWaterIn > pWaterOut)
                    CurrentHeigth = (pWaterOut * 50 / pWaterIn)+10;
                else
                    CurrentHeigth = MaxHeigth;
            }
        }

        public void removeWater(ulong pWater)//pWater enters method as meters^3
        {
            _CurrentVolume.subtract(new HugeInt (pWater.ToString() + "000000"));//converted in cm3
            if (notEnoughWater())
            {
                _CurrentVolume = new HugeInt(_MinVolume.toString());
                _lowCapacity = true;
                _CurrentHeigth = _MinHeigth;
                _VolumePercentage = _MinHeigth * 100 / _MaxHeigth;
                _CurrentNoticeableVolume = new HugeInt(_MinVolume.toString());
                _SignificanceVolumeChanged = true;
            }
            else
            {
                _CurrentNoticeableVolume.subtract(_SignificantDiference);

                while (_CurrentNoticeableVolume.greaterOrEqual(_CurrentVolume))
                {
                    _VolumePercentage--;
                    _CurrentHeigth = Converter.threeRule(_VolumePercentage, _MaxHeigth);
                    _SignificanceVolumeChanged = true;
                    _CurrentNoticeableVolume.subtract(_SignificantDiference);
                }

                _CurrentNoticeableVolume.add(_SignificantDiference);
            }
        }

        private void calculateSignificantChange()
        {
            _SignificantDiference = new HugeInt(_MaxVolume.toString());
            _SignificantDiference.oneHundredDivision();
            System.Windows.Forms.MessageBox.Show(_SignificantDiference.toString());
        }

        private Boolean notEnoughWater()
        {
            return _MinVolume.greaterOrEqual(_CurrentVolume);
        }

        private Boolean waterOverflow()
        {
            return _CurrentVolume.greaterOrEqual(_MaxVolume);
        }

        private HugeInt _CurrentVolume;//changes every time its adds or subtracts water
        private HugeInt _CurrentNoticeableVolume;//changes only when there is a significant difference
        private HugeInt _MaxVolume;//volumes are in cm3
        private HugeInt _MinVolume;
        private ulong _MinHeigth, _MaxHeigth, _Width, _Long, _CurrentHeigth;//dimensions are in m
        private Boolean _WaterOverflow, _lowCapacity, _SignificanceVolumeChanged;
        private HugeInt _SignificantDiference;//represents an 1% of the whole volume
        private ulong _VolumePercentage;
    }
}
