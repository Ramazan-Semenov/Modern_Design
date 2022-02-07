using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Design.Model.CRUDOP
{
    class CRUDSoftware_Registry
    {
        public string sqlConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\source\repos\Nikita\Nikita\AppData\Sch.mdf;Integrated Security=True";

        public void Create(Model.Software_Registry software_Registry)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Insert(software_Registry);
                connection.Close();
            }
        } 
        public void Update(Model.Software_Registry software_Registry)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Update(software_Registry);
                connection.Close();
            }
        } 
        public void Delete(Model.Software_Registry software_Registry)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Delete(software_Registry);
                connection.Close();
            }
        } 
        public IEnumerable<Model.Software_Registry> Read()
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.GetAll<Model.Software_Registry>();
                connection.Close();
                return affectedRows;

            }
        }



    }
}
