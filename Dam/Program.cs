using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Dam.Logic;
using Dam.UI;
namespace Dam
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DamAttributeSelection simulator= new DamAttributeSelection();
            Controller mainControl = Controller.getInstance();
            mainControl.setTemporalView(simulator);
            Application.Run(simulator);

            /*HugeInt number1 = new HugeInt("100");
            number1.subtract(new HugeInt("101"));
            System.Windows.Forms.MessageBox.Show(number1.toString());
            //number1.subtract(number2);
            //number1.add(number2);
            //number1.multiply(number2);
            number1.oneHundredDivision();
            System.Windows.Forms.MessageBox.Show((number1.toString().Length.ToString()));
            //s.Stop();
            //TimeSpan d = s.Elapsed;
            
            //System.Windows.Forms.MessageBox.Show(d.ToString());*/

            
            
        }
    }
}
