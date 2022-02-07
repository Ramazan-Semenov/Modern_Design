using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Design.Model.DialogService
{
    public class DialogService : IDialogService
    {
        public T OpenDialog<T>(DialogViewModelBase<T> viewModel)
        {
            IDialogWindow window = new DialogWindowCustom();
            window.DataContext = viewModel;
            window.ShowDialog();

            return viewModel.DialogResult;
        }
    }
}
