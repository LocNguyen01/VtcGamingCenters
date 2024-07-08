using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ComputerRepository
    {
        private readonly Database _database;
        public ComputerRepository(Database database)
        {
            _database = database;
        }
        public DataTable GetAllComputers()
        {
            string query = "SELECT *FROM computers";
            return _database.ExecuteQuery(query, null);
        }
        public bool UpdateComputer(Computer computer)
        {
            string query = "UPDATE computers SET status = @status, username = @username WHERE computer_name = @computer_name";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@computer_name",computer.computer_name),
                new MySqlParameter("@status",computer.status),
                new MySqlParameter("@username",computer.username)
            };
            return _database.ExecuteNonQuery(query, parameters) > 0;
        }
        public DataTable ViewComputersMaintenance(Computer computer)
        {
            string query = "SELECT computer_name FROM computers WHERE status = 'maintenance'";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@status",computer.status)
            };
            return _database.ExecuteQuery(query,parameters);
        }
        public DataTable SearchComputer(Computer computer)
        {
            string query = "SELECT computer_name,status,username FROM computers WHERE computer_name = @computer_name";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@computer_name",computer.computer_name)
            };
            return _database.ExecuteQuery(query, parameters);
        }
        public string GetComputerStatus(string computerName)
        {
            string query = "SELECT status FROM computers WHERE computer_name = @computerName";
            var parameters = new MySqlParameter[]
            {
            new MySqlParameter("@computerName", computerName)
            };
            object status = _database.ExecuteScalar(query, parameters);
            return status != null ? status.ToString() : null;
        }
    }
}
