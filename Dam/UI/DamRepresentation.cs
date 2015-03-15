using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dam
{
    public partial class DamRepresentation : Form
    {
        Graphics graphics;
        private Action Clickked;

        public Action clickked
        {
            get { return Clickked; }
            set { Clickked = value; }
        }

        public DamRepresentation()
        {
            InitializeComponent();
            graphics = screen.CreateGraphics();
        }

        private void screen_Click(object sender, EventArgs e)
        {
            Clickked();
        }
        public void paintWater(List<Point[]> pWaterCoordenates)
        {
            for (int element_counter = 0; element_counter < pWaterCoordenates.Count; element_counter++)
                graphics.FillClosedCurve(Brushes.Blue, pWaterCoordenates[element_counter]);
        }

        private void screen_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
