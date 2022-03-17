using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
      public ObservableCollection<User> d { get; set; } = new ObservableCollection<User>();
        PropertyGroupDescription groupDescription;
        CollectionView view;
        string prop = "Name";
        public string Autobiography { get; set; } = "wlkdfnmvlkdsfmv\n asdfsrgsdg \r ";
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            d.Add(new User() { Name = "John Doe", Age = 42, Sex = DateTime.Parse("12/12/2022")  }) ;
            d.Add(new User() { Name = "Jane Doe", Age = 39, Sex = DateTime.Parse("12/12/2022") });
            d.Add(new User() { Name = "Sammy Doe", Age = 13, Sex = DateTime.Parse("12/12/2022") });
            d.Add(new User() { Name = "John Doe", Age = 42, Sex = DateTime.Parse("12/12/2024") }) ;
            d.Add(new User() { Name = "Jane Doe", Age = 39, Sex = DateTime.Parse("12/12/2021") });
            d.Add(new User() { Name = "Sammy Doe", Age = 13, Sex = DateTime.Parse("12/12/2021") });

            view = (CollectionView)CollectionViewSource.GetDefaultView(d);
            //PropertyGroupDescription pgd = new PropertyGroupDescription("Age"); //name
            //PropertyGroupDescription pgd1 = new PropertyGroupDescription("Sex"); //name
            groupDescription = new PropertyGroupDescription("group");
           
        
            view.GroupDescriptions.Add(groupDescription);
            //view.GroupDescriptions.Add(pgd);
            //view.GroupDescriptions.Add(pgd1);

        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            prop = "Name";

            view.GroupDescriptions.Clear();
            view = (CollectionView)CollectionViewSource.GetDefaultView(d);
            groupDescription = new PropertyGroupDescription(prop);
            view.GroupDescriptions.Add(groupDescription);
            view.Refresh();
            OnPropertyChanged(nameof(d)); ;

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            prop = "Sex";

            view.GroupDescriptions.Clear();
            view = (CollectionView)CollectionViewSource.GetDefaultView(d);
            groupDescription = new PropertyGroupDescription(prop);
            view.GroupDescriptions.Add(groupDescription);
            view.Refresh();
            OnPropertyChanged(nameof(d)); ;
        }
    }




    public class User
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }

        public DateTime Sex { get; set; }

        public bool group { get { return true; } }
    }
}
