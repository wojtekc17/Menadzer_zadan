using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
//using System.Web.UI.DataVisualization.Charting;

using System.Timers;
//using System.Windows.Forms;
using Eto.OxyPlot;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Threading;




namespace WpfApplication5
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            timerr timerr = new timerr();
            timerr.timer();
            


        }

        





        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            Window1 okno2 = new Window1();
            okno2.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            Window2 okno3 = new Window2();
            okno3.Show();
            //;    okno3.Show();
          //   Thread watek = new Thread(okno3.Show);
          //  watek.Start();
        }
      

        public class timerr
        {
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll")]
            private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
            public static System.Timers.Timer aTimer;
           // public static Timer aTimer2;
            public void timer()
            {
                Global.Y.Clear();
                Global.YY.Clear();
                Global.X.Clear();
                Global.procesy.Clear();
                

                aTimer = new System.Timers.Timer(Global.interval);
                aTimer.Elapsed += new ElapsedEventHandler(ApplicationIsActivated);
                //aTimer.AutoReset = false;
                aTimer.Enabled = true;
                //aTimer.Start();
            }


            public static void ApplicationIsActivated(object source, ElapsedEventArgs e)
            {
                bool ook = false;
                //Global.czas = Global.czas + Global.interval;
                Global.czas1 = Global.czas1 + Global.interval;
               
                var activatedHandle = GetForegroundWindow();
                if (activatedHandle == IntPtr.Zero)
                {
                    ook = true;       // No window is currently activated
                    aTimer.Stop();
                }

                var procId = Process.GetCurrentProcess().Id;
                int activeProcId;
                GetWindowThreadProcessId(activatedHandle, out activeProcId);

                //long x = Convert.ToInt64(activatedHandle);
                Global.z = (long)activeProcId;


                for (int i = 0; i <= Global.procesy.Count() - 1; i++)
                {
                    if (Global.procesy[i] == Global.z)
                    {
                        ook = true;
                        break;
                    }
                    else
                    {

                        ook = false;   
                    }
                }

                if (ook == false)
                {
                    Global.procesy.Add(Global.z);
                    Global.procesy_nazwy.Add(Process.GetProcessById((int)Global.z));
                    Global.tab.Add(0);
                   
                    Global.Y.Add(new List<double>());
                    Global.YY.Add(new List<int>());

                    int g = (int)(Global.czas1 / Global.interval);

                    for (int ii = 1; ii < g; ii++)
                    {
                        Global.Y[Global.Y.Count()-1].Add(0);
                        Global.YY[Global.Y.Count() - 1].Add(0);

                    }
                    
                }

                Global.X.Add(Global.czas1/1000);

                for (int i = 0; i < Global.procesy.Count(); i++)
                {
                    if (Global.procesy[i] == Global.z)
                    {
                        Global.tab[i] = Global.tab[i] + Global.interval;
                        break;
                    }
                }

            

                for (int i = 0; i < Global.procesy.Count(); i++)
                {

                        Global.Y[i].Add(Global.tab[i]/Global.czas1*100);

                    if (Global.procesy[i] == Global.z)
                    {

                        Global.YY[i].Add(1);
                    }
                    else
                    {
                        Global.YY[i].Add(0);
                    }

                }

            }


        }

       
    }

}