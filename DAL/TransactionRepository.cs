using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    
    public class TransactionRepository
    {
        private readonly Database _database;
        public TransactionRepository(Database database) 
        {
            _database = database;
        }
        public DataTable HoaDonThanhToan(Transactions transactions)
        {
            string query = "SELECT  *FROM transactions WHERE user_id = @user_id";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@user_id",transactions.user_id)
            };
            return _database.ExecuteQuery(query, parameters);
        }
        public bool ThemHoaDon(Transactions transactions)
        {
            string query = "INSERT INTO transactions(user_id,computer_name, service_id, quantity, total_price) VALUES (@user_id,@computer_name,@service_id,@quantity,@total_price) ";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@user_id",transactions.user_id),
                new MySqlParameter("@computer_name",transactions.computer_name),
                new MySqlParameter("@service_id",transactions.service_id),
                new MySqlParameter("@quantity",transactions.quantity),
                new MySqlParameter("@total_price",transactions.total_price)
            };
            return _database.ExecuteNonQuery(query, parameters) > 0;
        }
        public DataTable HienThiHoaDonChoDuyet()
        {
            string query = "SELECT *FROM transactions WHERE status = 'pending'";
            return _database.ExecuteQuery(query, null);
        }
        public DataTable HienThiHoaDonDone()
        {
            string query = "SELECT *FROM transactions WHERE status = 'done'";
            return _database.ExecuteQuery(query, null);
        }
        public bool HoanThanhDon(Transactions transactions)
        {
            string query = "UPDATE transactions SET status = @status WHERE transaction_id = @transaction_id";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@transaction_id",transactions.transaction_id),
                new MySqlParameter("@status",transactions.status)
            };
            return _database.ExecuteNonQuery(query,parameters) > 0;
        }
        public DataTable ThongKeHoaDon()
        {
            string query = "SELECT total_price FROM transactions ";
            return _database.ExecuteQuery(query, null);
        }
    }
}
