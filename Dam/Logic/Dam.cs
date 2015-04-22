using Dam.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dam
{
    class Dam:IObservable
    {
        //Class that will be the center of the facility, which everyone will be observing.
        public Dam()
        {
            _ReleasingRate = new Thread(removeWaterToTank);
            _ReleasingRate.IsBackground = true;
            _RealeasingWater = false;
            _Turbines = new List<Turbine>();
            _FlowRate = new Thread(addWaterToTank);
            _FlowRate.IsBackground = true; //way to exit in case the whole application is closed
        }

        public Container River
        {
            get { return _River; }
            set { _River = value; }
        }
        public Container Tank
        {
            get { return _Tank; }
            set { _Tank = value; }
        }
        public ulong CurrentFlowRate
        {
            get { return _CurrentFlowRate; }
            set { _CurrentFlowRate = value; }
        }
        public ulong CurrentTotalEnergyProduced
        {
            get { return _CurrentTotalEnergyProduced; }
            set { _CurrentTotalEnergyProduced = value; }
        }
        public List<Turbine> Turbines
        {
            get { return _Turbines; }
            set { _Turbines = value; }
        }
        public Action<IObservable> ValuesChanged
        {
            get { return _ValuesChanged; }
            set { _ValuesChanged = value; }
        }
        public bool RealeasingWater
        {
            get { return _RealeasingWater; }
            set { _RealeasingWater = value; }
        }
        public Thread FlowRate
        {
            get { return _FlowRate; }
            set { _FlowRate = value; }
        }
        public Thread ReleasingRate
        {
            get { return _ReleasingRate; }
            set { _ReleasingRate = value; }
        }
        public bool VolumeChanged
        {
            get { return _VolumeChanged; }
            set { _VolumeChanged = value; }
        }
        public bool WaterFlowing
        {
            get { return _WaterFlowing; }
            set { _WaterFlowing = value; }
        }

        public static Dam getInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Dam();
            }
            return _Instance;
        }

        public void setWaterOverflow()
        {
            Tank.WaterOverflow = !Tank.WaterOverflow;
        }

        public void setLowCapacity()
        {
            Tank.LowCapacity = !Tank.LowCapacity;
        }

        public String getCurrentTurbineId()
        {
            return _Turbines[_Turbines.Count - 1].Identifier;
        }

        public void initializeDam(ulong pMaxHeigth, ulong pMinHeight, ulong pWidth, ulong pLong, ulong pCurrentFlowRate)
        {
            _CurrentFlowRate = pCurrentFlowRate;
            _Tank = new Container(pMaxHeigth, pMinHeight, pWidth, pLong);
            _River = new Container(200, 1, pWidth, pLong);
        }

        public void setTurbineStateForId(string pIndexToFind)
        {
            Turbine foundTurbine = turbineById(pIndexToFind);
            if (foundTurbine != null)
            {
                foundTurbine.TurnedOn = !foundTurbine.TurnedOn;
            }
        }

        public Turbine turbineById(string pIndexToFind)
        {
            for (int indexOfTurbines = 0; indexOfTurbines < _Turbines.Count; indexOfTurbines++)
            {
                if (_Turbines[indexOfTurbines].Identifier == pIndexToFind)
                    return _Turbines[indexOfTurbines];
            }
            return null;
        }

        public ulong selectedTurbineEnergy(string pIndexToFind)
        {
            Turbine foundTurbine = turbineById(pIndexToFind);
            if (foundTurbine != null)
            {
                return foundTurbine.CurrentEnergyProduced;
            }
            return 0;
        }

        public void addTurbine(ulong pMaxFlowRate, ulong pMinFlowRate,
            ulong pMaxPressure, ulong pMinPressure, ulong pMaxEnergy, ulong pMinEnergy)
        {
            Turbine turbineInstance = new Turbine(pMinFlowRate, pMaxFlowRate, pMinPressure,
                                      pMaxPressure, pMinEnergy, pMaxEnergy);
            register(turbineInstance);
            _Turbines.Add(turbineInstance);
        }

        public void addWaterToTank()
        {
            _WaterFlowing = true;
            while (_WaterFlowing)
            {
                _Tank.addWater(_CurrentFlowRate);
                Thread.Sleep(1000);
                if (_Tank.SignificanceVolumeChanged)
                {
                    notifyObservers();//notify will occur when the current height of the tank changes in 1%
                }
                if (_Tank.WaterOverflow)
                {
                    notifyObservers();
                    setWaterOverflow();
                    Thread.Sleep(1000);
                }
            }
        }

        public ulong currentWaterLoss()
        {
            if (_Turbines.Count != 0)
            {
                ulong allWaterLoss = 0;
                foreach (Turbine selectedTurbine in _Turbines)
                {
                    if (selectedTurbine.TurnedOn)
                        allWaterLoss += selectedTurbine.CurrentFlowRate;
                }
                return allWaterLoss;
            }
            return 0;
        }

        public void allTurbinesOFF()
        {
            foreach (Turbine selectedTurbine in _Turbines)
            {
                selectedTurbine.TurnedOn = !selectedTurbine.TurnedOn;
            }
        }

        public ulong currentEnergyProduced()
        {
            if (_Turbines.Count != 0)
            {
                ulong allEnergyProduced = 0;
                foreach (Turbine selectedTurbine in _Turbines)
                {
                    if (selectedTurbine.TurnedOn)
                        allEnergyProduced += selectedTurbine.CurrentEnergyProduced;
                }
                return allEnergyProduced;
            }
            return 0;
        }

        public void removeWaterToTank()
        {   
            _RealeasingWater = true;
            while (_RealeasingWater)
            {   
                ulong quantityToRemove = currentWaterLoss();//method that recorre la lista y sume todas las salidas de agua de turbinas activas
                _Tank.removeWater(quantityToRemove);
                Thread.Sleep(1000);
                if (_Tank.SignificanceVolumeChanged)
                {
                    _River.calculateHeight(currentWaterLoss(), CurrentFlowRate);
                    notifyObservers();

                }
                if (_Tank.LowCapacity)
                {
                    allTurbinesOFF();
                    notifyObservers();
                    setLowCapacity(); ;
                    Thread.Sleep(10000);
                }
            }
        }

        public void register(IObserver pObserver)
        {
            _ValuesChanged += pObserver.update;
        }

        public void unregister(IObserver pObserver)
        {
            _ValuesChanged -= pObserver.update;
        }

        public void notifyObservers()
        {
            _ValuesChanged(this);
        }

        private ulong _CurrentFlowRate, _CurrentTotalEnergyProduced;
        private List<Turbine> _Turbines;
        private Container _Tank;
        private Container _River;
        private bool _WaterFlowing, _RealeasingWater, _VolumeChanged;

        private static Dam _Instance = null;

        private Thread _FlowRate;
        private Thread _ReleasingRate;

        private Action<IObservable> _ValuesChanged;
    }
}
