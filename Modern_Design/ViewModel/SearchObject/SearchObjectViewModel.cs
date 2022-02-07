using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Modern_Design.ViewModel.SearchObject
{
    public class  SearchObjectViewModel :ViewModelBase
    {

        
        public object Result { get; set; }
        private ObservableCollection<object> resert;
        private ObservableCollection<object> _listResultObject;
       public ObservableCollection<object> ListResultObject { get=>_listResultObject; set=>_listResultObject=value; }
        private object _selectedItemResult;
        public object SelectedItemResult { get=>_selectedItemResult; set { _selectedItemResult = value;  }  }

    private string _paramSearch;
        public string ParamSearch { 
            get 
            {
                if (string.IsNullOrWhiteSpace(_paramSearch?.ToString()))
                {
                    _listResultObject = resert;
                    RaisePropertyChanged(nameof(ListResultObject));

                }
                return _paramSearch;
            }
            set
            {
                _paramSearch = value;


            }
        }

        private string _selected_by;
       public string Selected_by { get { 
                
               
                
                return _selected_by; } set {
                _selected_by = value;
                RaisePropertyChanged(nameof(Selected_by));
            }
        }


        public List<string> list_search_by { get {

                return ListResultObject[0].GetType().GetProperties().Select(x=>x.Name).ToList();
            } }

        public SearchObjectViewModel(IEnumerable<object> ListResultObject)
        {
            _listResultObject =new ObservableCollection<object>( ListResultObject);
            resert= new ObservableCollection<object>(ListResultObject);
            _selected_by = list_search_by[0];


        }

        public RelayCommand SearchCommand { get

            {
                return new RelayCommand(() =>
                {
                    {
                        try
                        {
                            if ((_selected_by != null) & (_paramSearch != null) & (!string.IsNullOrWhiteSpace(_paramSearch?.ToString())))
                            {

                                if (_listResultObject[0].GetType().GetProperty(_selected_by).PropertyType == typeof(DateTime))
                                {
                                    _listResultObject = new ObservableCollection<object>(_listResultObject.Where(x => DateTime.Parse(x.GetType().GetProperty(_selected_by).GetValue(x, null)?.ToString()).ToString("dd.MM.yyyy") == DateTime.Parse(_paramSearch.ToString()).ToString("dd.MM.yyyy")));

                                }
                                else
                                {
                                    _listResultObject = new ObservableCollection<object>(_listResultObject.Where(x => x.GetType().GetProperty(_selected_by).GetValue(x, null)?.ToString() == _paramSearch.ToString()));

                                }
                                RaisePropertyChanged(nameof(ListResultObject));

                                _listResultObject = resert;


                            }
                        }
                        catch(Exception exp)
                        {
                            MessageBox.Show(exp.Message);
                        }







                    }
                });
            }
        }

        public RelayCommand SendResult
        {
            get
            {
                return new RelayCommand(() => { Result = _selectedItemResult;});
            }
        }

    }
}
