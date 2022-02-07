using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Modern_Design.ViewModel.Software_Registry
{
  
    class Software_RegistryCRUDEntity:ViewModelBase
    {

        private string _textButtonOk;
        public string TextButtonOk { get=>_textButtonOk; set=>_textButtonOk=value; }

        private Model.Software_Registry _Software_Registry;
        public Model.Software_Registry Software_Registry { get=>_Software_Registry; set=>_Software_Registry=value; }
        public Software_RegistryCRUDEntity(Model.Enums.CRUD crud, Model.Software_Registry _Registry = null)
        {

            if (crud==Model.Enums.CRUD.Create)
            {
                _Software_Registry = new Model.Software_Registry();
                Excecute = new RelayCommand(()=> { Create_Software_Registry.Execute(null); });
                _textButtonOk = crud.ToString();

            }
            else if(crud == Model.Enums.CRUD.Delete)
            {
                if (_Registry != null)
                {
                    _Software_Registry = _Registry;
                    Excecute = new RelayCommand(() => { Delete_Software_Registry.Execute(null); });

                    _textButtonOk = crud.ToString();
                }
                else
                {
                    throw new Exception("Null parameter");
                }
            }
            else if(crud == Model.Enums.CRUD.Update)
            {
                if (_Registry != null)
                {
                    _Software_Registry = _Registry;
                    Excecute = new RelayCommand(() => { Edit_Software_Registry.Execute(null); });
                    _textButtonOk = crud.ToString();
                }
                else
                {
                    Excecute = new RelayCommand(() => { Edit_Software_Registry.Execute(null); });

                    // throw new Exception("Null parameter");
                }

            }
          

        }
        #region Команды
        /// <summary>
        /// Команда для редактирования записи
        /// </summary>
        public RelayCommand Edit_Software_Registry
        {
            get
            {
                return new RelayCommand(async () => { new Model.CRUDOP.CRUDSoftware_Registry().Update(_Software_Registry);
                    MessageBox.Show("Записть обновлена");
                });
            }
        }
        /// <summary>
        /// Команда для удаления записи
        /// </summary>
        public RelayCommand Delete_Software_Registry
        {
            get
            {
                return new RelayCommand(async () => { new Model.CRUDOP.CRUDSoftware_Registry().Delete(_Software_Registry);
                    MessageBox.Show("Запись удалена");
                });
            }
        }
        /// <summary>
        /// Команда для создания записи
        /// </summary>
        public RelayCommand Create_Software_Registry
        {
            get
            {
                return new RelayCommand(async () => { new Model.CRUDOP.CRUDSoftware_Registry().Create( _Software_Registry);

                    MessageBox.Show("Запись добавлена");
                });
            }
        }

        public RelayCommand<string> SearchStaff
        {
            get
            {
                return new RelayCommand<string>((string property)=> 
                {
                    try
                    {


                        List<Model.Software_Registry> list = new List<Model.Software_Registry>();
                        list.Add(new Model.Software_Registry { id = 1, customer = "df" });
                        list.Add(new Model.Software_Registry { id = 1, customer = "34" });
                        list.Add(new Model.Software_Registry { id = 1, customer = "dsfgsdf", owner = "fffffff" });

                        View.SearchObject.SearchObject searchObject = new View.SearchObject.SearchObject(list);
                        searchObject.ShowDialog();

                        var result = searchObject.Selected.GetType().GetProperty(property).GetValue(searchObject.Selected, null);

                        _Software_Registry.GetType().GetProperty(property).SetValue(_Software_Registry, result, null);
                        RaisePropertyChanged(nameof(Software_Registry));

                    }catch(Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                  
                });
            }
        }

        public RelayCommand Excecute { get; set; }

        #endregion
    }
}