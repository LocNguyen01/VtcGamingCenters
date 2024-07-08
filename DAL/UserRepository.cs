using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class UserRepository
    {
        private readonly Database _database;
        public UserRepository(Database database)
        {
            _database = database;
        }
        public DataTable LoginUsers(User user)
        {
            string query = "SELECT  COUNT(*) FROM users WHERE username = @username AND password = @password AND user_type = 'customer' AND balance_account > 0";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("username",user.username),
                new MySqlParameter("password",user.password)
            };
            return _database.ExecuteQuery(query, parameters);
        }
        public DataTable Logout(User user)
        {
            string query = "UPDATE users SET status = @status WHERE username = @username";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@username",user.username),
                new MySqlParameter("@status",user.status)
            };
            return _database.ExecuteQuery(query, parameters);
        }
        public DataTable LoginAdmin(User user) 
        { 
        
            string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password AND user_type = 'admin'";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("username",user.username),
                new MySqlParameter("password",user.password)
            };
            return _database.ExecuteQuery(query, parameters);
        }
        public DataTable GetAllUsers()
        {
            string query = "SELECT *FROM users";
            return _database.ExecuteQuery(query, null);
        }
        // Phương thức kiểm tra xem tên người dùng đã tồn tại hay chưa
        public bool IsUsernameExists(string username)
        {
            string query = "SELECT COUNT(*) FROM users WHERE username = @username";
            var parameter = new MySqlParameter("@username", username);

            try
            {
                // Thực hiện truy vấn và ép kiểu an toàn từ Int64 sang Int32
                object result = _database.ExecuteScalar(query, parameter);
                if (result != null)
                {
                    long countLong = (long)result;
                    int count = (int)countLong; // Ép kiểu từ Int64 (long) sang Int32
                    return count > 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kiểm tra tồn tại tên người dùng: " + ex.Message);
                return false;
            }
        }
        public bool AddUser(User user)
        {
            // Kiểm tra xem người dùng có tồn tại hay không
            if (IsUsernameExists(user.username))
            {
                Console.WriteLine("Tên người dùng đã tồn tại. Không thể thêm người dùng mới.");
                return false;
            }

            string query = "INSERT INTO users (username, password, full_name, user_type) VALUES (@username, @password, @full_name, @user_type)";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@username", user.username),
                new MySqlParameter("@password", user.password),
                new MySqlParameter("@full_name", user.full_name),
                new MySqlParameter("@user_type", user.user_type)
            };
            return _database.ExecuteNonQuery(query, parameters) > 0;
        }
        public bool UpdateUser(User user)
        {
            string query = "UPDATE users SET password = @password, full_name = @full_name, user_type = @user_type WHERE username = @username";
            var parameters = new MySqlParameter[]
            {
            new MySqlParameter("@username", user.username),
            new MySqlParameter("@password", user.password),
            new MySqlParameter("@full_name", user.full_name),
            new MySqlParameter("@user_type", user.user_type)
            };
            return _database.ExecuteNonQuery(query, parameters) > 0;
        }
        public bool AddMoney(User user,decimal amount)
        {
            string query = "UPDATE users SET balance_account = balance_account + @amount WHERE username = @username";
            var parameters = new MySqlParameter[]
            {
            new MySqlParameter("@username", user.username),
            new MySqlParameter("@amount", amount)
            
            };
            return _database.ExecuteNonQuery(query, parameters) > 0;
        }
        public bool DeleteUser(string username)
        {
            string query = "DELETE FROM users WHERE username = @username";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter ("username", username)
            };
            return _database.ExecuteNonQuery(query, parameters) > 0;
        }
        public DataTable SearchUsers(string username)
        {
            string query = "SELECT username,status,user_type,balance_account,total_usage_time FROM users WHERE username = @username";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@username", username)
            };
            return _database.ExecuteQuery(query, parameters);
        }
        public DataTable SearchUser(string username)
        {
            string query = "SELECT user_id, username,full_name,user_type,balance_account,login_time FROM users WHERE username = @username";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@username", username)
            };
            return _database.ExecuteQuery(query, parameters);
        } 
        public bool deduct(User user,decimal amount)
        {
            string query = "UPDATE users SET balance_account = balance_account - @amount WHERE username = @username";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@username", user.username),
                new MySqlParameter("@amount", amount)
            };
            return _database.ExecuteNonQuery (query, parameters) > 0;
            
        }
        public bool DoiMatKhauKhachHang(User user,string OldPassword)
        {
            string query = "UPDATE users SET password = @NewPassword WHERE username = @username AND password = @OldPassword";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@username",user.username),
                new MySqlParameter("@OldPassword",OldPassword),
                new MySqlParameter("@NewPassword",user.password)
            };
            return _database.ExecuteNonQuery (query,parameters) > 0;
        }
        
    }
}
