using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Design.Model
{
  public  class Software_Registry
    {
        /// <summary>
        /// Id 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Приоритет (Высокий, средний, низкий)
        /// </summary>
       public string priority { get; set; }
        /// <summary>
        /// Вид продукции (ВНутренний, внешний)
        /// </summary>
        public string product_type { get; set; }
        /// <summary>
        /// Имя продукта
        /// </summary>
       public string product_name { get; set; }
        /// <summary>
        /// Краткое описание
        /// </summary>
       public string short_description { get; set; }
        /// <summary>
        /// тип продукта(с#, vba, sql...)
        /// </summary>
        public string type_of_product { get; set; }
        /// <summary>
        /// Заказчик
        /// </summary>
       public string customer { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
       public string owner { get; set; }
        /// <summary>
        /// главный разработчик 
        /// </summary>
        public string main_developer { get; set; }
        /// <summary>
        /// количество пользователей
        /// </summary>
        public string number_of_users { get; set; }
        /// <summary>
        /// этап
        /// </summary>
       public string stage { get; set; }
        /// <summary>
        /// сопровождение
        /// </summary>
        public string maintenance { get; set; }
        /// <summary>
        /// ссылка на проект
        /// </summary>
       public string link_repository { get; set; }
        /// <summary>
        /// ссылка на описание 
        /// </summary>
        public string link_description { get; set; }
        /// <summary>
        /// комментарии
        /// </summary>
        public string comments { get; set; }

    }
}
