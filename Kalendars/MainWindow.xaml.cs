using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Kalendars
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(string), typeof(MainWindow));
        public static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register("IconSource", typeof(string), typeof(MainWindow));
        public string Date
        {
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public string IconSource
        {
            get { return (string)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        public ObservableCollection<DaySelection> Days { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
    }

    public class MainViewModel
    {
        public MainViewModel()
        {
             Days = new ObservableCollection<DaySelection>
        {
            new DaySelection(new DateTime(2022, 6, 15)),
            new DaySelection(new DateTime(2022, 6, 20)),
            new DaySelection(new DateTime(2022, 6, 25))
        };
        }
    }

    public class ItemSelection
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public bool IsSelected { get; set; }
    }

    public class DaySelection
    {
        public DateTime Date { get; set; }
        public ObservableCollection<ItemSelection> SelectedItems { get; set; }

        public DaySelection(DateTime date)
        {
            Date = date;
            SelectedItems = new ObservableCollection<ItemSelection>();
        }
    }

    public class ItemSelectionControl : Control
    {
        public static readonly DependencyProperty ItemNameProperty = DependencyProperty.Register("ItemName", typeof(string), typeof(ItemSelectionControl));
        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register("ImagePath", typeof(string), typeof(ItemSelectionControl));
    }

    public class DaySelectionControl : Control
    {
        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(DateTime), typeof(DaySelectionControl));
        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItems", typeof(ObservableCollection<ItemSelection>), typeof(DaySelectionControl));
    }
}
