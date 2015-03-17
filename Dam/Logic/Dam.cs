﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dam
{
    class Dam
    {
        private ulong _CurrentFlowRate, _CurrentTotalEnergyProduced;
        private List<Turbine> _Turbines = new List<Turbine>();
        private Container _Tank;
        private Container _River;
        private bool _WaterFlowing;
        
        //Threads
        private Thread _FlowRate;
        private Thread _TurbineActivity;

        //Actions
        private Action _MaxCapacityReached;

        public Dam(ulong pMaxHeigth, ulong pMinHeight, ulong pWidth, ulong pLong, ulong pCurrentFlowRate)
        {
            _CurrentFlowRate = pCurrentFlowRate;
            _Tank = new Container(pMaxHeigth, pMinHeight, pWidth, pLong);
            _River = new Container(pMaxHeigth, pMinHeight, pWidth, pLong);
            _FlowRate = new Thread(addWaterToTank);
            _TurbineActivity = new Thread(turbineCheck);
        }

        public void addWaterToTank()
        {
            _WaterFlowing = true;
            while (_WaterFlowing)
            {
                try
                {
                    _Tank.addWater(Convert.ToInt32(_CurrentFlowRate));
                    Thread.Sleep(1000);
                }
                catch (Exception WaterOverFlow)
                {
                    _MaxCapacityReached();
                    Thread.Sleep(10000);
                }
            }

        }

        public void turbineCheck()
        {

        }

        public Container River
        {
            get
            {
                return _River;
            }
            set
            {
                _River = value;
            }
        }
        public Container Tank
        {
            get
            {
                return _Tank;
            }
            set
            {
                _Tank = value;
            }
        }

        public Action MaxCapacityReached1
        {
            get { return _MaxCapacityReached; }
            set { _MaxCapacityReached = value; }
        }
    }
}
