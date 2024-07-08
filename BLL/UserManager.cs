using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserManager
    {
        private readonly UserRepository _userRepository;
        public UserManager(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool LogOut(User user)
        {
            DataTable result = _userRepository.Logout(user);
            return result != null ;

        }
        public DataTable LoginUsers(User user)
        {
            return _userRepository.LoginUsers(user);
        }
        public DataTable LoginAdmin(User user)
        {
            return _userRepository.LoginAdmin(user);
        }
        public DataTable GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public bool AddUsers(User user)
        {
            return _userRepository.AddUser(user);
        }
        public bool IsUsernameExists(string username)
        {
            try
            {
                return _userRepository.IsUsernameExists(username);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kiểm tra tồn tại tên người dùng trong BLL: " + ex.Message);
                return false;
            }
        }
        public bool UpdateUsers(User user)
        {
            return _userRepository.UpdateUser(user);
        }
        public bool DeleteUsers(string username)
        {
            return _userRepository.DeleteUser(username);
        }
        public DataTable SearchUser(string username)
        {
            return _userRepository.SearchUsers(username);
        }
        public DataTable SearchUsers(string username)
        {
            return _userRepository.SearchUser(username);
        }
        public bool AddMoney(User user,decimal amount)
        {
            return _userRepository.AddMoney(user,amount);
        }
        public bool Deduct(User user,decimal amount)
        {
            return _userRepository.deduct(user,amount);
        }
        public bool DoiMatKhauKhachHang(User user,string oldPassword)
        {
            return _userRepository.DoiMatKhauKhachHang(user, oldPassword);
        }
        
    }
}
