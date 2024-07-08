using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace DAL
{
    public class ServiceRepository
    {
        private readonly Database _database;
        public ServiceRepository(Database database)
        {
            _database = database;
        }
        public DataTable ViewAllServices()
        {
            string query = "SELECT *FROM services";
            return _database.ExecuteQuery(query, null);
        }
        public DataTable SearchServices(Service service)
        {
            string query = "SELECT service_id,service_name,price,stock_quantity FROM services WHERE service_name = @service_name";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@service_name", service.service_name)
            };
            return _database.ExecuteQuery(query, parameters);
        }
        public bool AddServices(Service service)
        {
            string query = "INSERT INTO services (service_name, price, stock_quantity) VALUES (@service_name, @price,@stock_quantity)";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@service_name", service.service_name),
                new MySqlParameter("@price", service.price),
                new MySqlParameter("@stock_quantity", service.stock_quantity)
            };
            return _database.ExecuteNonQuery(query, parameters) > 0;
        }
        public bool UpdateServices(Service service, string newService_Name)
        {
            string query = "UPDATE services SET service_name = @newService_Name, price = @price, stock_quantity = @stock_quantity WHERE service_name = @OldService_name";
            var parameters = new MySqlParameter[]
            {
            new MySqlParameter("@OldService_name", service.service_name),
            new MySqlParameter("@newService_name",newService_Name),
            new MySqlParameter("@price", service.price),
            new MySqlParameter("@stock_quantity", service.stock_quantity)
            };
            return _database.ExecuteNonQuery(query, parameters) > 0;
        }
        public bool deleteServices(Service service)
        {
            string query = "DELETE FROM services WHERE service_name = @service_name";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter ("service_name", service.service_name)
            };
            return _database.ExecuteNonQuery(query, parameters) > 0;
        }
        public DataTable GetServiceById(int service_id)
        {
            string query = "SELECT * FROM services WHERE service_id = @service_id";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@service_id", service_id)
            };

            return _database.ExecuteQuery(query, parameters);
        }
        public bool UpdateServiceBuy(Service service)
        {
            string query = "UPDATE services SET stock_quantity = @stock_quantity WHERE service_id = @service_id";
            var parameters = new MySqlParameter[]
            {
        new MySqlParameter("@stock_quantity", service.stock_quantity),
        new MySqlParameter("@service_id", service.service_id)
            };
            return _database.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
