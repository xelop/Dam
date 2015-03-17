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
        private Action Clickked;
        private List<Point[]> WaterContainerCoordenates = new List<Point[]>();
        private List<Point[]> WaterRiverCoordenates = new List<Point[]>();


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
            e.Graphics.FillRectangle(Brushes.Blue, new Rectangle(0, 200, 104, WaterContainer.Height + WaterContainer.Location.Y - 200));
            
            for (int element_counter = 0; element_counter < WaterContainerCoordenates.Count; element_counter++)
                e.Graphics.FillClosedCurve(Brushes.Blue, WaterContainerCoordenates[element_counter]);

            WaterContainerCoordenates.Clear();
        }

        private void RiverWater_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Blue, new Rectangle(0, 100, 164, RiverWater.Height + RiverWater.Location.Y - 100));
            for (int element_counter = 0; element_counter < WaterRiverCoordenates.Count; element_counter++)
                e.Graphics.FillClosedCurve(Brushes.Blue, WaterRiverCoordenates[element_counter]);

            WaterRiverCoordenates.Clear();
        }

        private void DamRepresentation_Click(object sender, EventArgs e)
        {
            Clickked();
        }

        public void TankLabelChanged(ulong pCurrentHeight)
        {
            TankHeight.Invoke((MethodInvoker)(() => TankHeight.Text = Convert.ToString(pCurrentHeight)));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TankHeight_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
