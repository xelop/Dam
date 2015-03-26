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

namespace Dam.UI
{
    public partial class AddTurbine : Form, IObservable
    {

        private Action<IObservable> _NewTurbine;


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

        public void hide()
        {
            this.Hide();
        }

        public void show()
        {
            this.Show();
        }
    }
}
