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

namespace Modern_Design.View.SearchObject
{
    /// <summary>
    /// Логика взаимодействия для SearchObject.xaml
    /// </summary>
    public partial class SearchObject : Window
    {
        public object Selected { get {return DG.SelectedItem; } } 

        public SearchObject(IEnumerable<object> obsoleteCollection)
        {
            InitializeComponent();
            DataContext = new ViewModel.SearchObject.SearchObjectViewModel(obsoleteCollection);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
