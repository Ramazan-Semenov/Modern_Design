using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Design.Model.DialogService
{
  public abstract  class DialogViewModelBase<T>
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public T DialogResult { get; set; }

        public DialogViewModelBase() : this(string.Empty, string.Empty) { }
        public DialogViewModelBase(string Title) : this(Title, string.Empty) { }
        public DialogViewModelBase(string Title, string message) 
        {
            this.Title=Title;
            Message = message;

        }

        public void CloseDialogResult(IDialogWindow dialog, T result)
        {
            DialogResult = result;
            if (dialog!=null)
            {
                dialog.DialogResult = true;
            }
        }


    }
}
