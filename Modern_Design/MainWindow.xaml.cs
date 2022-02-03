using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Modern_Design
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      public List<User> d { get; set; } = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            d.Add(new User() { Name = "John Doe", Age = 42, Sex = DateTime.Parse("12/12/2022") }) ;
            d.Add(new User() { Name = "Jane Doe", Age = 39, Sex = DateTime.Parse("12/12/2022") });
            d.Add(new User() { Name = "Sammy Doe", Age = 13, Sex = DateTime.Parse("12/12/2022") });
            d.Add(new User() { Name = "John Doe", Age = 42, Sex = DateTime.Parse("12/12/2024") }) ;
            d.Add(new User() { Name = "Jane Doe", Age = 39, Sex = DateTime.Parse("12/12/2021") });
            d.Add(new User() { Name = "Sammy Doe", Age = 13, Sex = DateTime.Parse("12/12/2021") });
           // lvUsers.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(d);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Sex");
            view.GroupDescriptions.Add(groupDescription);
        }
    }




    public class User
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }

        public DateTime Sex { get; set; }
    }
}
