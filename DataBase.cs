using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Bilet_12_Gambaryan
{
    public class DataBase : IDisposable
    {
        SqlConnection _connection;
        string _connectiontring = @"Data Source=GAMBARYAN\STP;Initial Catalog=Bilet_12;Integrated Security=True";
        public DataBase()
        {
            _connection = new SqlConnection(_connectiontring);
            OpenConnection();
        }

        private void OpenConnection()
        {
            _connection.Open();
        }

        private void CloseConnection()
        {
            _connection.Close();
        }

        public DataTable ExecuteSql(string sql)
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(sql, _connection);
            table.Load(command.ExecuteReader());

            return table;
        }

        public void ExecuteNonQuery(string sql)
        {
            SqlCommand command = new SqlCommand(sql, _connection);
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
