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
        public DamRepresentation()
        {
            InitializeComponent();
            graphics = screen.CreateGraphics();
        }

        private void screen_Click(object sender, EventArgs e)
        {
            List<Point[]> pWater=Converter.waveDrawing(100,400,110,100);

            for (int element_counter = 0; element_counter < pWater.Count; element_counter++)
            graphics.FillClosedCurve(Brushes.Blue,pWater[element_counter]);
        }

        private void screen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
