using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Dam.Logic;
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
            DamAttributeSelection Simulator= new DamAttributeSelection();
            Controller MainControl = new Controller(Simulator);
            Application.Run(Simulator);
            /*
            HugeInt number1 = new HugeInt("999999999999999999");
            HugeInt number2 = new HugeInt("999999999999999999");
            //System.Windows.Forms.MessageBox.Show(number1.greaterOrEqual(number2).ToString());
            //number1.subtract(number2);
            //number1.add(number2);
            number1.multiply(number2);
            System.Windows.Forms.MessageBox.Show((number1.toString()).Length.ToString());
            //s.Stop();
            //TimeSpan d = s.Elapsed;
            
            //System.Windows.Forms.MessageBox.Show(d.ToString());*/

            
            
        }
    }
}
