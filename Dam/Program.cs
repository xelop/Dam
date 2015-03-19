using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
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

            /*Stopwatch s = new Stopwatch();
            s.Start();
            Converter.listToString(Converter.calculateVolume(15123123123123, 20987987987987, 25456456456456));
            s.Stop();
            TimeSpan d = s.Elapsed;
            
            System.Windows.Forms.MessageBox.Show(d.ToString());
            //System.Windows.Forms.MessageBox.Show(Converter.listToString(Converter.takeOutNonSignificantCeroes(lista)));
            
            //System.Windows.Forms.MessageBox.Show(Converter.listToString(lista2));
            */
            
        }
    }
}
