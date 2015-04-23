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

/*main class of the UI it is in charge of every single detail that the user wants to see, most of its methods consist of values
 * changers depending on what the controller sends here. The controller is in charge of notifying that values changed but
 * this UI thread is the only one who can change them visualy*/

namespace Dam.UI
{
    public partial class DamRepresentation : Form, IObservable
    {

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
        public bool TurbineExist
        {
            get { return _TurbineExist; }
            set { _TurbineExist = value; }
        }
        public bool SecondsRequested
        {
            get { return _SecondsRequested; }
            set { _SecondsRequested = value; }
        }


        public DamRepresentation()
        {
            InitializeComponent();
            
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, WaterContainer, new object[] { true }); // we add a double buffer into the panel waterContainer to avoid flickering

            WaterContainer.Height = Constants.HEIGHT_TANK_LABEL;
            RiverWater.Height = Constants.HEIGHT_RIVER_LABEL;
            _cmb_Turbines.DataSource = _IdTurbines;

        }

        public void paintWater(List<Point[]> pContainerCoordenates, List<Point[]> pRiverCoordenates)
        {
            _WaterContainerCoordenates = pContainerCoordenates;
            WaterContainer.Invalidate(); //request the thread to repaint the given element.
            _WaterRiverCoordenates = pRiverCoordenates;
            RiverWater.Invalidate();
        }

        public void paintWaves(List<Point[]> pLiquidCoordinates, int pEndingX, int pHeightContainer, PaintEventArgs pEvent)
        { //N = List<Points> 
            try
            {
                pEvent.Graphics.FillRectangle(Brushes.Blue, new Rectangle(Constants.STARTING_X_CONTAINER, pLiquidCoordinates[0][0].Y,
                                                                            pEndingX, pHeightContainer)); //4+2+4+4+2
                for (int element_counter = 0; element_counter < pLiquidCoordinates.Count; element_counter++) //1 +(1+2+4+2+1)
                    pEvent.Graphics.FillClosedCurve(Brushes.Blue, pLiquidCoordinates[element_counter]);
            }
            catch (Exception ex)
            {
                FileManagement.addToFile(ex.Message);
            }


            //TOTAL= 17+ 10N

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
        }                           //casting         //tells the thread to execute this

        public void volumeLabelChanged(string pCurrentVolume)
        {
            _lbl_TankVolume.Invoke((MethodInvoker)(() => _lbl_TankVolume.Text = pCurrentVolume));
        }

        public void riverLabelChanged(ulong pCurrentHeight)
        {
            _lbl_riverHeight.Invoke((MethodInvoker)(() => _lbl_riverHeight.Text = Convert.ToString(pCurrentHeight)));
        }

        public void singleEnergyLabelChanged(ulong pCurrentEnergy)
        {
            _lbl_SingleEnergy.Invoke((MethodInvoker)(() => _lbl_SingleEnergy.Text = "Selected Turbine's Energy: " + Convert.ToString(pCurrentEnergy) + "000"));
        }

        public void totalEnergyLabelChanged(string pCurrentTotalEnergy)
        {
            _lbl_TotalEnergy.Invoke((MethodInvoker)(() => _lbl_TotalEnergy.Text = "Total Energy Poduction: " + Convert.ToString(pCurrentTotalEnergy)+"000"));
        }

        public void statusLabelChanged(string pStatus)
        {
             _lbl_TurbineStatus.Invoke((MethodInvoker)(() => _lbl_TurbineStatus.Text = "Current Turbine Status: "+ pStatus));
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
        {//returns the id of the selected Turbine
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
        public string currentSeconds()
        {
            return _txt_Seconds.Text;
        }


        //Properties Methods

        private void DamRepresentation_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProgramClosed = true;
            notifyObservers();
        }

        private Action<IObservable> _DamStatusChanged;

        private List<Point[]> _WaterContainerCoordenates = new List<Point[]>();
        private List<Point[]> _WaterRiverCoordenates = new List<Point[]>();
        private BindingList<String> _IdTurbines = new BindingList<String>();
        private String _CurrentTankHeight, _CurrentVolume = "0";
        private int selectedTurbineIndex;

        private bool _TurbineChanged, _TurbineRequested, _TurbineStatusRequested, _ProgramClosed, _TurbineExist, _FlowRateRequest, _SecondsRequested = false;

        private void DamRepresentation_Load(object sender, EventArgs e)
        {

        }

        private void _btn_seconds_Click(object sender, EventArgs e)
        {
            _SecondsRequested = true;
            notifyObservers();
        }
    }
}
