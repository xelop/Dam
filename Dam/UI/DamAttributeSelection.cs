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

namespace Dam.UI
{
    public partial class DamAttributeSelection : Form, IObservable
    {
        private Action<IObservable>_StartSimulation;

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
    }
}
