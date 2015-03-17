using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam
{
    class Turbine
    {
        private ulong _MinFlowRate, _MaxFlowRate, _MinPressure, _MaxPressure, _MinEnergyProduced,
            _MaxEnergyProduced, _CurrentPressure, _CurrentFlowRate, _CurrentEnergyProduced;
        private Boolean _TurnedOn;
        private String _Identifier;
        private static int _Counter = 0;

        public Turbine(ulong pMinFlowRate, ulong pMaxFlowRate, ulong pMinPressure, 
            ulong pMaxPressure, ulong pMinEnergyProduced, ulong pMaxEnergyProduced)
        {
            _MinFlowRate = pMinFlowRate;
            _MaxFlowRate = pMaxFlowRate;
            _MinPressure = pMinPressure;
            _MaxPressure = pMaxPressure;
            _MinEnergyProduced = pMinEnergyProduced;
            _MaxEnergyProduced = pMaxEnergyProduced;
            _Identifier = "ID " + _Counter.ToString();
            _Counter++;
            _TurnedOn = true;
        }

        public ulong MinFlowRate
        {
            get { return _MinFlowRate; }
            set { _MinFlowRate = value; }
        }

        public ulong MaxFlowRate
        {
            get { return _MaxFlowRate; }
            set { _MaxFlowRate = value; }
        }

        public ulong MinPressure
        {
            get { return _MinPressure; }
            set { _MinPressure = value; }
        }

        public ulong MaxPressure
        {
            get { return _MaxPressure; }
            set { _MaxPressure = value; }
        }

        public ulong MinEnergyProduced
        {
            get { return _MinEnergyProduced; }
            set { _MinEnergyProduced = value; }
        }

        public ulong MaxEnergyProduced
        {
            get { return _MaxEnergyProduced; }
            set { _MaxEnergyProduced = value; }
        }

        public ulong CurrentEnergyProduced
        {
            get { return _CurrentEnergyProduced; }
            set { _CurrentEnergyProduced = value; }
        }

        public ulong CurrentPressure
        {
            get { return _CurrentPressure; }
            set { _CurrentPressure = value; }
        }

        public ulong CurrentFlowRate
        {
            get { return _CurrentFlowRate; }
            set { _CurrentFlowRate = value; }
        }

        public String Identifier
        {
            get { return _Identifier; }
            set { _Identifier = value; }
        }

        public Boolean TurnedOn
        {
            get { return _TurnedOn; }
            set { _TurnedOn = value; }
        }

    }
}
