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
    /// Логика взаимодействия для Software_RegistryCRUDView.xaml
    /// </summary>
    public partial class Software_RegistryCRUDView : Window
    {
        //public Software_RegistryCRUDView(Model.Software_Registry software_Registry, Model.Enums.CRUD crud)
        //{
        //    InitializeComponent();
        //    DataContext = new ViewModel.Software_Registry.Software_RegistryCRUDEntity(crud,software_Registry);
        //} 
        public Software_RegistryCRUDView()
        {
            InitializeComponent();
            DataContext = new ViewModel.Software_Registry.Software_RegistryCRUDEntity(Model.Enums.CRUD.Update,null);
        }
    }
}
