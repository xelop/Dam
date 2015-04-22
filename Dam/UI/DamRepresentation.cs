using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Dam.Logic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Dam.UI
{
    public partial class DamRepresentation : Form, IObservable
    {
        private Action<IObservable> _DamStatusChanged;

        private List<Point[]> _WaterContainerCoordenates = new List<Point[]>();
        private List<Point[]> _WaterRiverCoordenates = new List<Point[]>();
        private BindingList<String> _IdTurbines = new BindingList<String>();
        private String _CurrentTankHeight, _CurrentVolume="0";
        private int selectedTurbineIndex;

        private bool _TurbineChanged, _TurbineRequested, _TurbineStatusRequested, _ProgramClosed, _TurbineExist, _FlowRateRequest = false;

        public DamRepresentation()
        {
            InitializeComponent();
            
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, WaterContainer, new object[] { true }); //forma abstracta de agregar una property a una clase que no la tiene

            /*typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, WaterRiver, new object[] { true });*/

            WaterContainer.Height = Constants.HEIGHT_TANK_LABEL;
            RiverWater.Height = Constants.HEIGHT_RIVER_LABEL;
            _cmb_Turbines.DataSource = _IdTurbines;

        }

        public void paintWater(List<Point[]> pContainerCoordenates, List<Point[]> pRiverCoordenates)
        {
            _WaterContainerCoordenates = pContainerCoordenates;
            WaterContainer.Invalidate();
            _WaterRiverCoordenates = pRiverCoordenates;
            RiverWater.Invalidate();
        }

        public void paintWaves(List<Point[]> pLiquidCoordinates, int pEndingX, int pHeightContainer, PaintEventArgs pEvent)
        {
            pEvent.Graphics.FillRectangle(Brushes.Blue, new Rectangle(Constants.STARTING_X_CONTAINER, pLiquidCoordinates[0][0].Y,
                                                                        pEndingX, pHeightContainer));
            for (int element_counter = 0; element_counter < pLiquidCoordinates.Count; element_counter++)
                pEvent.Graphics.FillClosedCurve(Brushes.Blue, pLiquidCoordinates[element_counter]);

            pLiquidCoordinates.Clear();
        }

        private void WaterContainer_Paint(object sender, PaintEventArgs e)
        {
            paintWaves(_WaterContainerCoordenates, Constants.ENDING_X_TANK, Constants.HEIGHT_TANK_LABEL, e);
        }

        private void RiverWater_Paint(object sender, PaintEventArgs e)
        {
            paintWaves(_WaterRiverCoordenates, Constants.ENDING_X_RIVER, Constants.HEIGHT_RIVER_LABEL, e);
        } 

        public void updateBox()
        {
            _cmb_Turbines.DataSource = _IdTurbines;
        }

        public void changeCurrentFlowText(ulong pQuantity)
        {
            _txt_CurrentFlow.Text = Convert.ToString(pQuantity);
        }

        public void tankLabelChanged(ulong pCurrentHeight)
        {
            _lbl_TankHeight.Invoke((MethodInvoker)(() => _lbl_TankHeight.Text = Convert.ToString(pCurrentHeight)));
        }

        public void volumeLabelChanged(string pCurrentVolume)
        {
            _lbl_TankVolume.Invoke((MethodInvoker)(() => _lbl_TankVolume.Text = pCurrentVolume));
        }

        public void singleEnergyLabelChanged(ulong pCurrentEnergy)
        {
            _lbl_SingleEnergy.Invoke((MethodInvoker)(() => _lbl_SingleEnergy.Text = "Selected Turbine's Energy: " + Convert.ToString(pCurrentEnergy)));
        }

        public void totalEnergyLabelChanged(string pCurrentTotalEnergy)
        {
            _lbl_TotalEnergy.Invoke((MethodInvoker)(() => _lbl_TotalEnergy.Text = "Total Energy Poduction: " + Convert.ToString(pCurrentTotalEnergy)));
        }

        public void statusLabelChanged(string pStatus)
        {
             _lbl_TurbineStatus.Text = "Current Turbine Status: "+ pStatus;
        }

        private void _btn_AddTrubine_Click(object sender, EventArgs e)
        {
            _TurbineRequested = true;
            notifyObservers();
        }

        private void _btn_OnorOff_Click(object sender, EventArgs e)
        {
            _TurbineChanged = true;
            notifyObservers();
        }

        private void _cmb_Turbines_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _TurbineStatusRequested = true;
            notifyObservers();
        }

        public string selectedTurbine()
        {
            _cmb_Turbines.Invoke((MethodInvoker)(() => selectedTurbineIndex = _cmb_Turbines.SelectedIndex));
            if (selectedTurbineIndex >= 0)
            {
                _TurbineExist = true;
                return _IdTurbines[selectedTurbineIndex];
            }
            else
            {
                _TurbineExist = false;
                return "0";
            }
        }

        public void register(IObserver pObserver)
        {
            _DamStatusChanged += pObserver.update;
        }

        public void unregister(IObserver pObserver)
        {
            _DamStatusChanged -= pObserver.update;
        }

        public void notifyObservers()
        {
            _DamStatusChanged(this);
        }

        private void _btn_ChangeFlow_Click(object sender, EventArgs e)
        {
            _FlowRateRequest = true;
            notifyObservers();
        }

        public string currentFlowRate()
        {
            return _txt_CurrentFlow.Text;
        }


        //Properties Methods

        public BindingList<String> IdTurbines
        {
            get { return _IdTurbines; }
            set { _IdTurbines = value; }
        }
        public Action<IObservable> DamStatusChanged
        {
            get { return _DamStatusChanged; }
            set { _DamStatusChanged = value; }
        }
        public bool TurbineChanged
        {
          get { return _TurbineChanged; }
          set { _TurbineChanged = value; }
        }    
        public bool TurbineRequested
        {
          get { return _TurbineRequested; }
          set { _TurbineRequested = value; }
        }
        public bool TurbineStatusRequested
        {
          get { return _TurbineStatusRequested; }
          set { _TurbineStatusRequested = value; }
        }
        public bool ProgramClosed
        {
            get { return _ProgramClosed; }
            set { _ProgramClosed = value; }
        }
        public bool FlowRateRequest
        {
            get { return _FlowRateRequest; }
            set { _FlowRateRequest = value; }
        }

        private void DamRepresentation_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProgramClosed = true;
            notifyObservers();
        }

        private void DamRepresentation_Load(object sender, EventArgs e)
        {

        }
        public bool TurbineExist
        {
            get { return _TurbineExist; }
            set { _TurbineExist = value; }
        }

        private void _lbl_TankHeight_Paint(object sender, PaintEventArgs e)
        {
            _lbl_TankHeight.Text = _CurrentTankHeight;
        }
    }
}
