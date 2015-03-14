using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam
{
    class Turbine:Convertible
    {
        private Int16[] _MinFlowRate, _MaxFlowRate, _MinPressure, _MaxPressure, _MinEnergyProduced,
            _MaxEnergyProduced, _CurrentPressure, _CurrentFlowRate, _CurrentEnergyProduced;
        private Boolean TurnedOn;

        private String Identifier;

        public Turbine(String pMinFlowRate, String pMaxFlowRate, String pMinPressure, 
            String pMaxPressure, String pMinEnergyProduced, String pMaxEnergyProduced)
        {
            TurnedOn = true;
        }
    }
}
