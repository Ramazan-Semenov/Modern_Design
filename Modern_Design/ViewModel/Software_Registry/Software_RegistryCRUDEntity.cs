using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Design.ViewModel.Software_Registry
{
  
    class Software_RegistryCRUDEntity
    {

        private Model.Software_Registry _Software_Registry;
        public Model.Software_Registry Software_Registry { get=>_Software_Registry; set=>_Software_Registry=value; }
        public Software_RegistryCRUDEntity(Model.Enums.CRUD crud, Model.Software_Registry _Registry = null)
        {
            if (crud==Model.Enums.CRUD.Create)
            {
                _Software_Registry = new Model.Software_Registry();
            }
            else if((crud == Model.Enums.CRUD.Delete)|| (crud == Model.Enums.CRUD.Update))
            {
                if (_Registry != null)
                {
                    _Software_Registry = _Registry;
                }
                else
                {
                    throw new Exception("Null parameter");
                }
            }
          

        }
        #region Команды
        /// <summary>
        /// Команда для редактирования записи
        /// </summary>
        public RelayCommand Edite_Software_Registry
        {
            get
            {
                return new RelayCommand(async () => { });
            }
        }
        /// <summary>
        /// Команда для удаления записи
        /// </summary>
        public RelayCommand Delete_Software_Registry
        {
            get
            {
                return new RelayCommand(async () => { });
            }
        }
        /// <summary>
        /// Команда для создания записи
        /// </summary>
        public RelayCommand Create_Software_Registry
        {
            get
            {
                return new RelayCommand(async () => { });
            }
        }
        #endregion
    }
}