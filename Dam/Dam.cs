using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam
{
    class Dam
    {
        private Int16[] _CurrentFlowRate, _CurrentTotalEnergyProduced;
        private List<Turbine> _Turbines = new List<Turbine>();
        private Container _Tank;
        private Container _River;

        public Dam(String pHeigth, String pWidth, String pLong, String pCurrentFlowRate)
        {
            //_Tank = new Container(pHeigth, pWidth, pLong);
        }

    }
}
