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
    public partial class DamAttributeSelection : Form
    {
        private Action<String, String, String, String, String, bool> _StartSimulation;
        
        //Sends in the following order: MaxHeigth, MinHeight Width, Length, waterflowrate and bool for kilometers

        public Action<String, String, String, String, String, bool> startSimulation
        {
            get
            {
                return _StartSimulation;
            }
            set
            {
                _StartSimulation = value;
            }
        }

 
        public DamAttributeSelection()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            _StartSimulation(MaxHeightTextBox.Text, MinHeightTextBox.Text, 
                WidthTextBox.Text, LengthTextBox.Text, FlowRateTextBox.Text, KmOption.Checked);
        }
    }
}
