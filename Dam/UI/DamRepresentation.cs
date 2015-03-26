using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Dam
{
    public partial class DamRepresentation : Form
    {
        private Action Clickked, _RequestForTurbine;
        private Action<String> _ChangeStateCurrentTurbine, _StateCurrentTurbine; //sends the id of the current turbine
        private List<Point[]> WaterContainerCoordenates = new List<Point[]>();
        private List<Point[]> WaterRiverCoordenates = new List<Point[]>();
        private BindingList<String> _IdTurbines = new BindingList<String>();

        public Action clickked
        {
            get { return Clickked; }
            set { Clickked = value; }
        }

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
            WaterContainerCoordenates = pContainerCoordenates;
            WaterContainer.Invalidate();
            WaterRiverCoordenates = pRiverCoordenates;
            RiverWater.Invalidate();
        }


        private void WaterContainer_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.FillRectangle(Brushes.Blue, new Rectangle(Constants.STARTING_X_CONTAINER, WaterContainerCoordenates[0][0].Y,
                                                                            Constants.ENDING_X_TANK, Constants.HEIGHT_TANK_LABEL));

                for (int element_counter = 0; element_counter < WaterContainerCoordenates.Count; element_counter++)
                    e.Graphics.FillClosedCurve(Brushes.Blue, WaterContainerCoordenates[element_counter]);

                WaterContainerCoordenates.Clear();
            }
            catch { };
        }

        private void RiverWater_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.FillRectangle(Brushes.Blue, new Rectangle(Constants.STARTING_X_CONTAINER, WaterRiverCoordenates[0][0].Y,
                                                                        Constants.ENDING_X_RIVER, Constants.HEIGHT_RIVER_LABEL));
                for (int element_counter = 0; element_counter < WaterRiverCoordenates.Count; element_counter++)
                    e.Graphics.FillClosedCurve(Brushes.Blue, WaterRiverCoordenates[element_counter]);

                WaterRiverCoordenates.Clear();
            }
            catch { }
        }

        public void updateBox()
        {
            _cmb_Turbines.DataSource = _IdTurbines;
        }

        private void DamRepresentation_Click(object sender, EventArgs e)
        {
            
        }

        public void TankLabelChanged(ulong pCurrentHeight)
        {
            TankHeight.Invoke((MethodInvoker)(() => TankHeight.Text = Convert.ToString(pCurrentHeight)));
        }

        public void statusLabelChanged(string pStatus)
        {
            _lbl_TurbineStatus.Invoke((MethodInvoker)(() => _lbl_TurbineStatus.Text = "Current Turbine Status: "+ pStatus));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void StatusChanged()
        {

        }

        private void TankHeight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _btn_AddTrubine_Click(object sender, EventArgs e)
        {
            _RequestForTurbine();
        }

        private void _btn_OnorOff_Click(object sender, EventArgs e)
        {
            _ChangeStateCurrentTurbine(_IdTurbines[_cmb_Turbines.SelectedIndex]);
        }

        private void _cmb_Turbines_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _StateCurrentTurbine(_IdTurbines[_cmb_Turbines.SelectedIndex]);
        }


        public Action RequestForTurbine
        {
            get { return _RequestForTurbine; }
            set { _RequestForTurbine = value; }
        }

        public BindingList<String> IdTurbines
        {
            get { return _IdTurbines; }
            set { _IdTurbines = value; }
        }

        public Action<String> StateCurrentTurbine
        {
            get { return _StateCurrentTurbine; }
            set { _StateCurrentTurbine = value; }
        }

        public Action<String> ChangeStateCurrentTurbine
        {
            get { return _ChangeStateCurrentTurbine; }
            set { _ChangeStateCurrentTurbine = value; }
        }

    }
}
