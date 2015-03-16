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

            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, WaterRiver, new object[] { true });
        }

        private void screen_Click(object sender, EventArgs e)
        {
            Clickked();
        }
        public void paintWater(List<Point[]> pContainerCoordenates, List<Point[]> pRiverCoordenates)
        {
            WaterContainerCoordenates = pContainerCoordenates;
            WaterContainer.Invalidate();
            WaterRiverCoordenates = pRiverCoordenates;
            WaterRiver.Invalidate();
        }


        private void WaterContainer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Blue, new Rectangle(0, 200, 104, WaterContainer.Height + WaterContainer.Location.Y - 200));
            
            for (int element_counter = 0; element_counter < WaterContainerCoordenates.Count; element_counter++)
                e.Graphics.FillClosedCurve(Brushes.Blue, WaterContainerCoordenates[element_counter]);

            WaterContainerCoordenates.Clear();
        }

        private void WaterRiver_Paint(object sender, PaintEventArgs e)
        {
           
            e.Graphics.DrawLine(new Pen(Brushes.Blue, 20), WaterRiver.Location, new Point(WaterRiver.Location.X + 100, WaterRiver.Location.Y + 100));
            /*e.Graphics.FillRectangle(Brushes.Blue, new Rectangle(696, 350, 163,50)); //WaterRiver.Height + WaterRiver.Location.Y - 400));
            System.Windows.Forms.MessageBox.Show("hello");
            for (int element_counter = 0; element_counter < WaterRiverCoordenates.Count; element_counter++)
                e.Graphics.FillClosedCurve(Brushes.Blue, WaterRiverCoordenates[element_counter]);

            WaterRiverCoordenates.Clear();*/
        }


    }
}
