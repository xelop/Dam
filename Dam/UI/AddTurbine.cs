using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dam.Logic;

/*this class is used to set the attributes of the turbines the user wants, it is hidden as the user can call it many times, at the end it closes
 * as the whole application closes*/

namespace Dam.UI
{
    public partial class AddTurbine : Form, IObservable
    {

        public Action<IObservable> newTurbine
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

        private void _btn_AddTurbine_Click(object sender, EventArgs e)
        {
            notifyObservers();
        }

        public String[] getTurbineAttributes()
        {
            String[] turbineValues = new String[] {_txt_MaxFlowRate.Text, _txt_MinFlowRate.Text, 
                _txt_MaxPressure.Text, _txt_MinFlowRate.Text, 
                _txt_MaxEnergy.Text, _txt_MinEnergy.Text, _txt_NumberofTurbines.Text};

            _txt_MaxEnergy.Text = "";
            _txt_MinEnergy.Text = "";
            _txt_MaxPressure.Text = "";
            _txt_MinPressure.Text = "";
            _txt_MaxFlowRate.Text = "";
            _txt_MinFlowRate.Text = "";
            _txt_NumberofTurbines.Text = "";

            this.Hide();
            return turbineValues;
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




        public void register(IObserver pObserver)
        {
            _NewTurbine += pObserver.update;
        }

        public void unregister(IObserver pObserver)
        {
            _NewTurbine -= pObserver.update;
        }

        public void notifyObservers()
        {
            _NewTurbine(this);
        }

        private Action<IObservable> _NewTurbine;

        private void _txt_MaxFlowRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputNumbers(sender, e);
        }

        private void _txt_MinFlowRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputNumbers(sender, e);
        }

        private void _txt_MaxPressure_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputNumbers(sender, e);
        }

        private void _txt_MinPressure_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputNumbers(sender, e);
        }

        private void _txt_MaxEnergy_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputNumbers(sender, e);
        }

        private void _txt_MinEnergy_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputNumbers(sender, e);
        }

        private void _txt_NumberofTurbines_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputNumbers(sender, e);
        }
    }
}
