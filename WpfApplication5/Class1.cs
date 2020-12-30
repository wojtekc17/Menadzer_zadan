using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;

namespace WpfApplication5
{
    static  class Global
    {
        
        public static List<double> X = new List<double>();                //lista z czasem co 1500ms
        public static List<double> tab = new List<double>();             //lista z czasami każdego z procesów ile był włączony ogólnie
        public static List<long> procesy = new List<long>();                //lista z Id procesów 
        public static List<Process> procesy_nazwy = new List<Process>();   //lista z obiektami process nazwami procesów

        public static List<List<double>> Y = new List<List<double>>();     // lista z listami czasów w co każde 1500ms
        public static List<List<int>> YY = new List<List<int>>();          // lista z listami czasów w co każde 1500ms dla określonego czasu
        public static long z = 0;       // Id procesu aktywnego
        public static double czas1 = 0;  //ogólny czas działania programu
        public static double interval = 1500;  //czas odświeżania wykresu
        public static DataTable przedzial = new DataTable();
        public static long a = 0;
      
        public static double b;
        public static double czas = 0;

        //  public static bool ok = true;


        //  public static int x = 0;
        // public static int h = 0;

         

        // public static double czas3 = 0;

    }
    
}
