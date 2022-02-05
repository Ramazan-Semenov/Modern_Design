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

namespace Modern_Design.View.Software_Registry
{
    /// <summary>
    /// Логика взаимодействия для Software_Registry.xaml
    /// </summary>
    public partial class Software_Registry : Window
    {
        public Software_Registry()
        {
            InitializeComponent();
            DataContext = new ViewModel.Software_Registry.Software_RegistryViewModel();
        }
    }
}
