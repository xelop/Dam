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
        private ulong _CurrentFlowRate, _CurrentTotalEnergyProduced;
        private List<Turbine> _Turbines = new List<Turbine>();
        private Container _Tank;
        private Container _River;
        private bool _WaterFlowing, _RealeasingWater;

        private static Dam _Instance = null;
        
        //Threads
        private Thread _FlowRate;
        private Thread _TurbineActivity;
        private Thread _ReleasingRate;
        

        //Actions
        private Action<IObservable> _ValuesChanged;

        public Dam()
        {
            _TurbineActivity = new Thread(turbineCheck);
            _ReleasingRate = new Thread(removeWaterToTank);
            _RealeasingWater = false;
        }

        public static Dam getInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Dam();
            }
            return _Instance;
        }

        public void initializeDam(ulong pMaxHeigth, ulong pMinHeight, ulong pWidth, ulong pLong, ulong pCurrentFlowRate)
        {
            _CurrentFlowRate = pCurrentFlowRate;
            _Tank = new Container(pMaxHeigth, pMinHeight, pWidth, pLong);
            _River = new Container(pMaxHeigth, pMinHeight, pWidth, pLong);
            _FlowRate = new Thread(addWaterToTank);
        }

        public void addTurbine(ulong pMaxFlowRate, ulong pMinFlowRate,
            ulong pMaxPressure, ulong pMinPressure, ulong pMaxEnergy, ulong pMinEnergy)
        {
            _Turbines.Add(new Turbine(pMinFlowRate, pMaxFlowRate, pMinPressure,
                                      pMaxPressure, pMinEnergy, pMaxEnergy));
        }

        public void addWaterToTank()
        {
            _WaterFlowing = true;
            while (_WaterFlowing)
            {
                _Tank.addWater(_CurrentFlowRate);
                Thread.Sleep(1000);
                if (_Tank.WaterOverflow)
                {
                    notifyObservers();//notify will occur when the current height of the tank changes in 1%
                    Thread.Sleep(10001);
                }
            }
        }

        public void removeWaterToTank()
        {   
            _RealeasingWater = true;
            while (_RealeasingWater)
            {   
                ulong quantityToRemove = 0;//method that recorre la lista y sume todas las salidas de agua de turbinas activas
                _Tank.removeWater(quantityToRemove);
                Thread.Sleep(1000);
                if (_Tank.LowCapacity)
                {
                    notifyObservers();
                    Thread.Sleep(10000);
                }
            }
        }

        public void setWaterOverflow()
        {
            Tank.WaterOverflow = !Tank.WaterOverflow;
        }

        public void setLowCapacity()
        {
            Tank.LowCapacity= !Tank.LowCapacity;
        }

        public String getCurrentTurbineId()
        {
            return _Turbines[_Turbines.Count-1].Identifier;
        }

        public void setTurbineStateForId(string pIndexToFind)
        {
            Turbine foundTurbine = turbineById(pIndexToFind);
            foundTurbine.TurnedOn = !foundTurbine.TurnedOn;
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


        public void turbineCheck()
        {

        }

        public Container River
        {
            get { return _River; }
            set {  _River = value; }
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
    }
}
