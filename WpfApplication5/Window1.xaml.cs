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
using System.Windows.Shapes;
using Eto.OxyPlot;
using System.Diagnostics;
using Microsoft.Win32;
using System.Data;
using System.Windows.Forms;

using System.ComponentModel;//Binding
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace WpfApplication5
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        


        public Window1()
        {
            InitializeComponent();


            List<tabela> lista = new List<tabela>();
            for (int i = 0; i < Global.procesy_nazwy.Count(); i++)
            {

                lista.Add(new tabela() { Id = Global.procesy[i], Lp = i + 1, Name = Global.procesy_nazwy[i].ProcessName.ToString(), Czas = Global.tab[i] / 1000 });

            }

            dgUsers.ItemsSource = lista;
            //W konstruktorze
            oxyPlotModel = new OxyPlotModel();
            //To pozwala połączyć kontrolki z polami klasy OxyPlotModel
            this.DataContext = oxyPlotModel;

            oxyPlotModel.PodajDaneDoWykresu2(Global.X, Global.Y, Global.procesy_nazwy);
            oxyPlotModel.SetUpLegend();
            oxyPlotModel.PlotModel.RefreshPlot(true);

            


        }


        public class tabela
        {
            public long Id { get; set; }

            public int Lp { get; set; }

            public string Name { get; set; }

            public double Czas { get; set; }
        }





        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = (Global.czas1 / 1000).ToString()+"[s] ";
            List<tabela> lista = new List<tabela>();
            for (int i = 0; i < Global.procesy_nazwy.Count(); i++)
            {

                lista.Add(new tabela() { Id = Global.procesy[i], Lp = i + 1, Name = Global.procesy_nazwy[i].ProcessName.ToString(), Czas = Global.tab[i] / 1000 });

            }

                dgUsers.ItemsSource = lista;
            //W konstruktorze
            oxyPlotModel = new OxyPlotModel();
            //To pozwala połączyć kontrolki z polami klasy OxyPlotModel
            this.DataContext = oxyPlotModel;

            oxyPlotModel.PodajDaneDoWykresu2(Global.X, Global.Y, Global.procesy_nazwy);
            oxyPlotModel.SetUpLegend();
            oxyPlotModel.PlotModel.RefreshPlot(true);
        }
    

        
    



    //Deklaracja obiektu
    private OxyPlotModel oxyPlotModel;

        public class OxyPlotModel : INotifyPropertyChanged
        {

            OxyPlot.Series.LineSeries[] punktySeriiTab;//deklaracja tablicy z seriami
            private OxyPlot.PlotModel plotModel;



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

            private readonly List<OxyPlot.OxyColor> koloryWykresow = new List<OxyPlot.OxyColor>
             {
             OxyPlot.OxyColors.Green,
             OxyPlot.OxyColors.IndianRed,
             OxyPlot.OxyColors.Coral,
             OxyPlot.OxyColors.Chartreuse,
             OxyPlot.OxyColors.Peru
             };
            private readonly List<OxyPlot.MarkerType> ksztaltPunktowWykresu = new
           List<OxyPlot.MarkerType>
             {
             OxyPlot.MarkerType.Plus,
             OxyPlot.MarkerType.Star,
             OxyPlot.MarkerType.Cross,
             OxyPlot.MarkerType.Diamond,
             OxyPlot.MarkerType.Square
             };

            public void PodajDaneDoWykresu2(List<double> X, List<List<double>> Y, List<Process> procesy)//Lista X i Y podana jako parametr metody
            {
                this.PlotModel = new OxyPlot.PlotModel();
                //Usunięcie ustawionych parametrów z poprzedniego uruchomienia metody
                plotModel.Series = new System.Collections.ObjectModel.Collection<OxyPlot.Series.Series> { };
                punktySeriiTab = new OxyPlot.Series.LineSeries[Y.Count()];//Ile jest List w zmiennej Y
                plotModel.Axes = new System.Collections.ObjectModel.Collection<OxyPlot.Axes.Axis> { };
                Random random = new Random();
                //Graficzne ustawienia wykresów
                for (int n = 0; n < Y.Count(); n++)
                {
                    punktySeriiTab[n] = new OxyPlot.Series.LineSeries
                    {
                        MarkerType = ksztaltPunktowWykresu[n % 5], //oznaczenie punktów
                        MarkerSize = 4, //wielkość punktów
                        MarkerStroke = OxyPlot.OxyColor.FromUInt32((uint)random.Next(0, 16777215) + 4278190080), //Kolor obramowania punktów wykresu / kolory losowane funkcją random
                        Title = procesy[n].ProcessName.ToString()   //tytuł serii
                    };
                }
                //Uzupełnianie danych
                for (int i = 0; i < Y.Count(); i++)
                {
                    for (int n = 0; n < Y[i].Count(); n++) //uzupełniam tylko dla włączonych
                        punktySeriiTab[i].Points.Add(new OxyPlot.DataPoint(X[n], Y[i][n]));//dodanie wszystkich serii do wykresu
                }
                for (int i = 0; i < Y.Count(); i++)
                    plotModel.Series.Add(punktySeriiTab[i]);
                //Opis i parametry osi wykresu
                var xAxis = new OxyPlot.Axes.LinearAxis(OxyPlot.Axes.AxisPosition.Bottom, "czas [s]")
                {
                    MajorGridlineStyle =
               OxyPlot.LineStyle.Solid,
                    MinorGridlineStyle = OxyPlot.LineStyle.Dot
                };
                plotModel.Axes.Add(xAxis);
                var yAxis = new OxyPlot.Axes.LinearAxis(OxyPlot.Axes.AxisPosition.Left, "% udziału czasu")
                {
                    MajorGridlineStyle =
               OxyPlot.LineStyle.Solid,
                    MinorGridlineStyle = OxyPlot.LineStyle.Dot
                };
                plotModel.Axes.Add(yAxis);
             
               
            }
            //Wypisane po to, by zmieniać kolor i kształt wraz z numerem klasy



            public void SetUpLegend()
            {
                
                plotModel.LegendTitle = "Legenda";//Tytuł legendy
                plotModel.LegendOrientation = OxyPlot.LegendOrientation.Horizontal; //Orientacja
                plotModel.LegendPlacement = OxyPlot.LegendPlacement.Outside; //Poza planszą wykresu
                plotModel.LegendPosition = OxyPlot.LegendPosition.TopRight; //Pozycja: góra, prawo
                plotModel.LegendBackground = OxyPlot.OxyColor.FromAColor(200,
                OxyPlot.OxyColors.GhostWhite);//Tło białe
                plotModel.LegendBorder = OxyPlot.OxyColors.Black; //Ramka okna czarna

            }
        }

        
    }

}
