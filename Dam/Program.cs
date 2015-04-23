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
            //Converter.calculateHugeVolume(9, 1231234, 12314241);
           /* HugeInt number1 = new HugeInt("1");
            HugeInt number2 = new HugeInt("9999999999999999999");
            //number1.subtract(new HugeInt("101"));
            //System.Windows.Forms.MessageBox.Show(number1.toString());
            //number1.subtract(number2);
            //number1.add(number2);
            number1.multiply(number2);
            //number1.oneHundredDivision();
            System.Windows.Forms.MessageBox.Show((number1.toString()));
            //s.Stop();
            //TimeSpan d = s.Elapsed;
            
            //System.Windows.Forms.MessageBox.Show(d.ToString());*/

            
            
        }
    }
}
