using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DamAttributeSelection Simulator= new DamAttributeSelection();
            Controller MainControl = new Controller(Simulator);
            Application.Run(Simulator);
            Dam DAM = new Dam("100", "100", "900", "887");
            Controller MainControl = new Controller(DAM, Simulator);
            Application.Run(Simulator);*/

            String caca  = "01000";
            String caca2 = "1";
            List<Int16> lista = Converter.stringToList(caca);
            //System.Windows.Forms.MessageBox.Show(Converter.listToString(lista));
            List<Int16> lista2 = Converter.stringToList(caca2);
            //System.Windows.Forms.MessageBox.Show(Converter.listToString(Converter.addList(lista, lista2)));
            System.Windows.Forms.MessageBox.Show(Converter.listToString(Converter.subtractList(lista, lista2)));
            
            //System.Windows.Forms.MessageBox.Show(Converter.listToString(Converter.takeOutNonSignificantCeroes(lista)));

            //System.Windows.Forms.MessageBox.Show(Converter.listToString(lista2));


        }
    }
}
