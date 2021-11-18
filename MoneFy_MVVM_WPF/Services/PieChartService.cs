using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MoneFy_MVVM_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MoneFy_MVVM_WPF.Services
{
    public class PieChartService : IPieChartService
    {
        private void Set<T>(ref T obj, ref T value)
        {
            obj = value;
        }
        private SeriesCollection _collection;
        public SeriesCollection Collection { get; set; }
        public PieChartService()
        {



        }

        public void ChangeCollectonItem(string CategoryName, Transaction value)
        {
            SolidColorBrush color = new();
            if (CategoryName == "Transport")
                color = new SolidColorBrush(System.Windows.Media.Color.FromRgb(72, 61, 91));
            else if (CategoryName == "Sport")
                color = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
            else if (CategoryName == "Food")
                color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 214, 107, 1));
            else if (CategoryName == "Party")
                color = new SolidColorBrush(System.Windows.Media.Color.FromRgb(226, 25, 25));
            else if (CategoryName == "Aptek")
                color = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 193, 149));
            else if (CategoryName == "CellPhone")
                color = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 181, 199));
            else if (CategoryName == "Dress")
                color = new SolidColorBrush(System.Windows.Media.Color.FromRgb(202, 59, 255));
            else if(CategoryName == "Pets")
                color = new SolidColorBrush(System.Windows.Media.Color.FromRgb(22, 36, 83));

            if (Collection[0].Title == "Empty")
            {
                Collection.Clear();                
            }
            else
            {
                for (int i = 0; i < Collection.Count; i++)
                {
                    if (CategoryName == Collection[i].Title)
                    {
                        ObservableValue colValue = Collection[i].Values[0] as ObservableValue;
                        colValue.Value += value.Summ;
                        Collection[i].Values = new ChartValues<ObservableValue>() { colValue };
                        return;
                    }
                }
            }

            Collection.Add(new PieSeries()
            {
                Title = CategoryName,
                Fill = color,
                Values = new ChartValues<ObservableValue>() { new ObservableValue(value.Summ) }
            }); ;



        }


        public void InitCollection(string test)
        {
            if (test == "a")
            {
                Collection = new SeriesCollection() {
               new PieSeries()
               {
                   FontSize=15,
                   Title = "Empty",
                    Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255)),
                   Values = new ChartValues<ObservableValue>() { new ObservableValue(100) },
                   DataLabels = true
               } };
            }


            //new PieSeries()
            //{
            //    FontSize = 15,
            //    Title = "Transport",
            //    Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(72, 61, 91)),
            //    Values = new ChartValues<ObservableValue>() { new ObservableValue(50) },
            //    DataLabels = true
            //} ,
            //new PieSeries()
            //{
            //    FontSize=15,
            //    Title = "Sport",
            //     Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0)),
            //    Values = new ChartValues<ObservableValue>() { new ObservableValue(40) },
            //    DataLabels = true
            //},
            //new PieSeries()
            //{
            //    FontSize=15,
            //    Title = "Food",
            //     Fill= new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 214, 107, 1)),
            //    Values = new ChartValues<ObservableValue>() { new ObservableValue(70) },
            //    DataLabels = true
            //},
            //new PieSeries()
            //{
            //    FontSize=15,
            //    Title = "Hangout",
            //     Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(225,26,25)),
            //    Values = new ChartValues<ObservableValue>() { new ObservableValue(30) },
            //    DataLabels = true
            //},
            //new PieSeries()
            //{
            //    FontSize=15,
            //    Title = "Aptek",
            //     Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(0,193,149)),
            //    Values = new ChartValues<ObservableValue>() { new ObservableValue(30) },
            //    DataLabels = true
            //},
            //new PieSeries()
            //{
            //    FontSize=15,
            //     Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(0,181,199)),
            //    Title = "CellPhone",
            //    Values = new ChartValues<ObservableValue>() { new ObservableValue(30) },
            //    DataLabels = true
            //},
            //new PieSeries()
            //{
            //    FontSize=15,
            //     Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(202, 59, 255)),
            //    Title = "Dress",
            //    Values = new ChartValues<ObservableValue>() { new ObservableValue(90) },
            //    DataLabels = true
            //},
            //new PieSeries()
            //{
            //   FontSize=15,
            //     Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(22, 36, 83)),
            //   Title = "Pets",
            //   Values = new ChartValues<ObservableValue>() { new ObservableValue(101) },
            //   DataLabels = true
            //} };
        }

    }
}
