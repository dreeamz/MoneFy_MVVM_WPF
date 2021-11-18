using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Color = System.Drawing.Color;
using System.Runtime.CompilerServices;

namespace wpfTest
{

    public partial class MainWindow
    {
        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value) || string.IsNullOrEmpty(propertyName))
            {
                return false;
            }

            storage = value;

            return true;
        }
        private SeriesCollection _seriesViews;
        public SeriesCollection seriesViews
        {
            get => _seriesViews;
            set
            {
                SetProperty(ref _seriesViews, value);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            seriesViews = new SeriesCollection()
            {
               new PieSeries()
               {
                   FontSize=15,
                   Title = "Transport",
                    Fill= new SolidColorBrush(System.Windows.Media.Color.FromRgb(72, 61, 91)),
                   Values = new ChartValues<ObservableValue>() { new ObservableValue(50) },
                   DataLabels = true
               },
            };
        }

    }

}
    

