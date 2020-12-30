using System.Collections.Generic;
using System.Windows;
using System.Diagnostics;

using System.ComponentModel;//Binding
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using System;
using System.Linq;
using System.Windows.Controls;

using System.ComponentModel;//Binding
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace WpfApplication5
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window2 : Window
    {



        public Window2()
        {
            InitializeComponent();
          

        }


        public class tabela
        {
            public long Id { get; set; }

            public int Lp { get; set; }

            public string Name { get; set; }

            public double Czas { get; set; }

            public double Procent { get; set; }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = (Global.czas1 / 1000).ToString() + "[s]";
            try
         {
                
                Global.b = (Int32.Parse(TextBoxDo.Text));
            Global.b = Global.b / (Global.interval/1000);
                //  Global.a = (Int32.Parse(TextBoxOd.Text)) * 1000;
                if (Global.b != 0)
                {
                    List<tabela> lista = new List<tabela>();
                    for (int i = 0; i < Global.procesy.Count(); i++)
                    {
                        int suma = 0;
                        for (int ii = 0; ii < Global.b; ii++)
                        {
                            if (Global.YY[i][ii] == 1)
                            {
                                suma = suma + 1;
                            }
                            else
                            {
                                suma = suma;
                            }
                        }
                        double proc = (double)suma / (double)Global.b * 100;
                        if (proc != 0)
                        {
                            lista.Add(new tabela() { Id = Global.procesy[i], Lp = i + 1, Name = Global.procesy_nazwy[i].ProcessName.ToString(), Czas = suma, Procent = proc });
                        }
                    }
                    dgUsers.ItemsSource = lista;


                    //W konstruktorze
                    oxyPlotModel = new OxyPlotModel();
                    //To pozwala połączyć kontrolki z polami klasy OxyPlotModel
                    this.DataContext = oxyPlotModel;
                    oxyPlotModel.PodajDaneDoWykresu(lista);                    
                    oxyPlotModel.PlotModel.RefreshPlot(true);

                }
          }
           catch { MessageBox.Show("Wprowadz liczbe całkowita wieksza od zera lub odpowiednia ilość czasu dzialania apliakacji"); };
        }

        private void TextBoxOd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        //Deklaracja obiektu
        private OxyPlotModel oxyPlotModel;

        public class OxyPlotModel : INotifyPropertyChanged
        {
            private OxyPlot.PlotModel plotModel = new OxyPlot.PlotModel();
           // OxyPlot.Series.BarSeries[] punktySeriiTab;//deklaracja tablicy z seriami
    //        private OxyPlot.PlotModel plotModel;



            public OxyPlot.PlotModel PlotModel
            {
                get
                {
                    return plotModel;
                }
                set
                {
                    plotModel = value; OnPropertyChanged("PlotModel");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
            //OxyPlot.Series.LineSeries punktySerii;

            public void PodajDaneDoWykresu(List<tabela> list)
            {

                var baritems = new BarSeries
                {
                    Title = "",
                    StrokeColor = OxyColors.Yellow,
                    StrokeThickness = 1
                };
                
               foreach (var war in list) baritems.Items.Add(new BarItem { Value = war.Procent });


                var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
                foreach (var war in list) categoryAxis.Labels.Add(war.Name);

                var valueAxis = new LinearAxis
                {
                    Position = AxisPosition.Bottom,
                    MinimumPadding = 0,
                    MaximumPadding = 0.06,
                    AbsoluteMinimum = 0
                };
               plotModel.Series.Add(baritems);
               plotModel.Axes.Add(categoryAxis);
               plotModel.Axes.Add(valueAxis);

            }
            
            //Wypisane po to, by zmieniać kolor i kształt wraz z numerem klasy



            
        }

        
    }
}



