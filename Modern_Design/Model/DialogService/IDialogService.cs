using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Design.Model.DialogService
{
   public interface IDialogService
    {
        T OpenDialog<T>(DialogViewModelBase<T> viewModel);


    }
}
