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
            Application.Run(Simulator);*/

            //String caca  = "20000";
            //String caca2 = "300";
            /*List<Int16> lista = Converter.stringToList(caca);
            //System.Windows.Forms.MessageBox.Show(Converter.listToString(lista));
            List<Int16> lista2 = Converter.stringToList(caca2);
            //System.Windows.Forms.MessageBox.Show(Converter.listToString(Converter.addList(lista, lista2)));
            //System.Windows.Forms.MessageBox.Show(Converter.listToString(Converter.subtractList(lista, lista2)));
            System.Windows.Forms.MessageBox.Show(Converter.listToString(Converter.calculateVolume(15123123123123, 20987987987987, 25456456456456)));
            //System.Windows.Forms.MessageBox.Show(Converter.listToString(Converter.multiplyList(lista, lista2)));
            //System.Windows.Forms.MessageBox.Show(Converter.listToString(Converter.takeOutNonSignificantCeroes(lista)));

            //System.Windows.Forms.MessageBox.Show(Converter.listToString(lista2));*/

            Container tank = new Container(10000000000, 1000000000, 50000000000, 7500000000);
            List<Int16> debug1 = tank.MaxVolume; 
            List<Int16> debug2 = tank.MinVolume;
            //System.Windows.Forms.MessageBox.Show(Converter.listToString(tank.MaxVolume));
            //System.Windows.Forms.MessageBox.Show(Converter.listToString(tank.MinVolume));

            while (true)
            {
                try
                {
                    List<Int16> debug3 = tank.CurrentVolume;
                    //System.Windows.Forms.MessageBox.Show(Converter.listToString(tank.CurrentVolume));
                    tank.addWater(12345);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                    System.Windows.Forms.MessageBox.Show(Converter.listToString(tank.CurrentVolume));
                    break;
                }
            }
        }
    }
}
