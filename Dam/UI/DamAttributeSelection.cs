using System;
using Dam.Logic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* this class is the one running with the application.run() as it is the first one to appear, it remains hidden until the program exists
 * this aspect should be changed. The main purpose is to  get all the attributes the DAM needs.*/

namespace Dam.UI
{
    public partial class DamAttributeSelection : Form, IObservable
    {

        public Action<IObservable> startSimulation
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

        public String[] getAttributes()
        {
            String[] attributeValues= new String[5] {MaxHeightTextBox.Text, MinHeightTextBox.Text, 
                WidthTextBox.Text, LengthTextBox.Text, FlowRateTextBox.Text};
            return attributeValues;
        }

        public bool kmChecked()
        {
            return KmOption.Checked;
        }
        public DamAttributeSelection()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            notifyObservers();
        }

        public void register(IObserver pObserver)
        {
            _StartSimulation += pObserver.update;
        }

        public void unregister(IObserver pObserver)
        {
            _StartSimulation -= pObserver.update;
        }

        public void notifyObservers()
        {
            _StartSimulation(this);
        }

        public void exit()
        {
            this.Close();
        }
        private Action<IObservable> _StartSimulation;

        private void MaxHeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputNumbers(sender, e);
        }

        private void inputNumbers(object pSender, KeyPressEventArgs pEvent)
        {
            if (!char.IsControl(pEvent.KeyChar) && !char.IsDigit(pEvent.KeyChar) &&
                (pEvent.KeyChar != '.'))
            {
                pEvent.Handled = true;
            }

            // only allow one decimal point
            if ((pEvent.KeyChar == '.') && ((pSender as TextBox).Text.IndexOf('.') > -1))
            {
                pEvent.Handled = true;
            }
        }

        private void MinHeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputNumbers(sender, e);
        }

        private void WidthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputNumbers(sender, e);
        }

        private void LengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputNumbers(sender, e);
        }

        private void FlowRateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputNumbers(sender, e);
        }//IObservale is a parameter
    }
}
