using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dam.UI
{
    public partial class AddTurbine : Form
    {

        private Action<String, String, String, String, String, String, int> _NewTurbine;

        //Sends in the following order: MaxCurrentFlow, MinCurrentFlow, MaxPressure, MinPressure, MaxEnergy, MinEergy and #ofTurbines.

        public Action<String, String, String, String, String, String, int> newTurbine
        {
            get
            {
                return _NewTurbine;
            }
            set
            {
                _NewTurbine = value;
            }
        }

        public AddTurbine()
        {
            InitializeComponent();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddTurbine_Load(object sender, EventArgs e)
        {

        }

        private void _btn_AddTurbine_Click(object sender, EventArgs e)
        {

            _NewTurbine(_txt_MaxFlowRate.Text, _txt_MinFlowRate.Text, 
                _txt_MaxPressure.Text, _txt_MinFlowRate.Text, 
                _txt_MaxEnergy.Text, _txt_MinEnergy.Text, Convert.ToInt32(_txt_NumberofTurbines.Text));

            _txt_MaxEnergy.Text = "";
            _txt_MinEnergy.Text = "";
            _txt_MaxPressure.Text = "";
            _txt_MinPressure.Text = "";
            _txt_MaxFlowRate.Text = "";
            _txt_MinFlowRate.Text = "";

            this.Hide();

        }
    }
}
