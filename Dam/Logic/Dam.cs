using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam
{
    class Dam
    {
        private ulong _CurrentFlowRate, _CurrentTotalEnergyProduced;
        private List<Turbine> _Turbines = new List<Turbine>();
        private Container _Tank;
        private Container _River;

        public Dam(ulong pMaxHeigth, ulong pMinHeight, ulong pWidth, ulong pLong, ulong pCurrentFlowRate)
        {
            _CurrentFlowRate = pCurrentFlowRate;
            _Tank = new Container(pMaxHeigth, pMinHeight, pWidth, pLong);
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


    }
}
