using BLL;
using DAL;
using Org.BouncyCastle.Tls.Crypto.Impl.BC;
using PL;
using System;
using System.Data;
using System.Text;

namespace VtcGamingCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;user=root;password=loc2005;database=quanlyquannet";
            Database database = new Database(connectionString);

            UserRepository userRepository = new UserRepository(database);
            UserManager userManager = new UserManager(userRepository);

            ServiceRepository serviceRepository = new ServiceRepository(database);
            ServiceManager serviceManager = new ServiceManager(serviceRepository);

            ComputerRepository computerRepository = new ComputerRepository(database);
            ComputerManager computerManager = new ComputerManager(computerRepository);
            
            TransactionRepository transactionRepository = new TransactionRepository(database);
            TransactionManager transactionManager = new TransactionManager(transactionRepository,serviceManager);

            Menu menu = new Menu();
            Console.OutputEncoding = Encoding.UTF8;
            int chonNguoiDung = -1;
            int chonMenuAdmin = -1;
            int chonMenuManagerUsers = -1;
            int chonMenuManagerComputers = -1;
            int chonMenuManagerServices = -1;
            int chonMenuUsers = -1;
            do
            {
                while (true)
                {
                    menu.MenuLuaChon();
                    Console.Write("Nhập lựa chọn của bạn: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out chonNguoiDung))
                    {
                        break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                    }
                    else
                    {
                        Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                    }
                }

                switch (chonNguoiDung)
                {
                    case 0:
                        {
                            Console.WriteLine("+---------------+");
                            Console.WriteLine("| Bạn đã thoát! |");
                            Console.WriteLine("+---------------+");
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("+---------------------------------+");
                            Console.WriteLine("| Bạn đang ở chức năng của Admin! |");
                            Console.WriteLine("+---------------------------------+");

                            LoginAdmin(userManager);
                            do
                            {
                                while (true)
                                {
                                    menu.MenuAdmin();
                                    Console.Write("Nhập lựa chọn của bạn: ");
                                    string input = Console.ReadLine();
                                    if (int.TryParse(input, out chonMenuAdmin))
                                    {
                                        break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                                    }
                                    else
                                    {
                                        Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                                    }
                                }

                                switch (chonMenuAdmin)
                                {
                                    case 0:
                                        {
                                            Console.WriteLine("+------------------------------+");
                                            Console.WriteLine("| Bạn đã quay lại trang trước! |");
                                            Console.WriteLine("+------------------------------+");

                                            break;
                                        }
                                    case 1:
                                        {
                                            Console.WriteLine("+-----------------------------------------+");
                                            Console.WriteLine("| Bạn đang ở chức năng quản lí người dùng |");
                                            Console.WriteLine("+-----------------------------------------+");
                                            do
                                            {
                                                while (true)
                                                {
                                                    menu.MenuManagerUsers();
                                                    Console.Write("Nhập lựa chọn của bạn: ");
                                                    string input = Console.ReadLine();
                                                    if (int.TryParse(input, out chonMenuManagerUsers))
                                                    {
                                                        break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                                                    }
                                                }
                                                switch (chonMenuManagerUsers)
                                                {
                                                    case 0:
                                                        {
                                                            Console.WriteLine("+------------------------------+");
                                                            Console.WriteLine("| Bạn đã quay lại trang trước! |");
                                                            Console.WriteLine("+------------------------------+");

                                                            break;
                                                        }
                                                    case 1:
                                                        {
                                                            Console.WriteLine("+--------------------------------------+");
                                                            Console.WriteLine("| Bạn đang ở chức năng thêm người dùng |");
                                                            Console.WriteLine("+--------------------------------------+");
                                                            addUsers(userManager);
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.WriteLine("+------------------------------------------+");
                                                            Console.WriteLine("| Bạn đang ở chức năng hiển thị người dùng |");
                                                            Console.WriteLine("+------------------------------------------+");
                                                            viewAllUsers(userManager);
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.WriteLine("+-------------------------------------+");
                                                            Console.WriteLine("| Bạn đang ở chức năng sửa người dùng |");
                                                            Console.WriteLine("+-------------------------------------+");
                                                            UpdateUsers(userManager);
                                                            break;
                                                        }
                                                    case 4:
                                                        {
                                                            Console.WriteLine("+-------------------------------------+");
                                                            Console.WriteLine("| Bạn đang ở chức năng xoá người dùng |");
                                                            Console.WriteLine("+-------------------------------------+");
                                                            DeleteUsers(userManager);
                                                            break;
                                                        }
                                                    case 5:
                                                        {
                                                            Console.WriteLine("+------------------------------------------+");
                                                            Console.WriteLine("| Bạn đang ở chức năng tìm kiếm người dùng |");
                                                            Console.WriteLine("+------------------------------------------+");
                                                            SearchUsers(userManager);
                                                            break;
                                                        }
                                                    case 6:
                                                        {
                                                            Console.WriteLine("+-------------------------------+");
                                                            Console.WriteLine("| Bạn đang ở chức năng nạp tiền |");
                                                            Console.WriteLine("+-------------------------------+");
                                                            AddMoney(userManager);
                                                            break;
                                                        }
                                                    case 7:
                                                        {
                                                            Console.WriteLine("+-------------------------------+");
                                                            Console.WriteLine("| Bạn đang ở chức năng trừ tiền |");
                                                            Console.WriteLine("+-------------------------------+");
                                                            DeDuct(userManager);
                                                            break;
                                                        }
                                                }

                                            } while (chonMenuManagerUsers != 0);

                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("+---------------------------------------+");
                                            Console.WriteLine("| Bạn đang ở chức năng quản lí máy tính |");
                                            Console.WriteLine("+---------------------------------------+");
                                            do
                                            {
                                                while (true)
                                                {
                                                    menu.MenuMangagerComputers();
                                                    Console.Write("Nhập lựa chọn của bạn: ");
                                                    string input = Console.ReadLine();
                                                    if (int.TryParse(input, out chonMenuManagerComputers))
                                                    {
                                                        break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                                                    }
                                                }
                                                switch (chonMenuManagerComputers)
                                                {
                                                    case 0:
                                                        {
                                                            Console.WriteLine("+-----------------------------+");
                                                            Console.WriteLine("| Bạn đã quay lại trang trước |");
                                                            Console.WriteLine("+-----------------------------+");
                                                            break;
                                                        }
                                                    case 1:
                                                        {
                                                            Console.WriteLine("+----------+");
                                                            Console.WriteLine("| Hiển thị |");
                                                            Console.WriteLine("+----------+");
                                                            ViewAllComputers(computerManager);
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.WriteLine("+------------------+");
                                                            Console.WriteLine("| Bảo trì máy tính |");
                                                            Console.WriteLine("+------------------+");
                                                            UpdateComputers(computerManager);
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.WriteLine("+----------+");
                                                            Console.WriteLine("| tìm kiếm |");
                                                            Console.WriteLine("+----------+");
                                                            SearchComputers(computerManager);
                                                            break;
                                                        }
                                                }
                                            } while (chonMenuManagerComputers != 0);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("+--------------------------------------+");
                                            Console.WriteLine("| Bạn đang ở chức năng quản lí dịch vụ |");
                                            Console.WriteLine("+--------------------------------------+");

                                            do
                                            {
                                                while (true)
                                                {
                                                    menu.MenuManagerServices();
                                                    Console.Write("Nhập lựa chọn của bạn: ");
                                                    string input = Console.ReadLine();
                                                    if (int.TryParse(input, out chonMenuManagerServices))
                                                    {
                                                        break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                                                    }
                                                }
                                                switch (chonMenuManagerServices)
                                                {
                                                    case 0:
                                                        {
                                                            Console.WriteLine("+---------------------------------+");
                                                            Console.WriteLine("| Bạn đã quay trở lại trang trước |");
                                                            Console.WriteLine("+---------------------------------+");

                                                            break;
                                                        }
                                                    case 1:
                                                        {
                                                            Console.WriteLine("+------+");
                                                            Console.WriteLine("| Thêm |");
                                                            Console.WriteLine("+------+");
                                                            AddServices(serviceManager);
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.WriteLine("+----------+");
                                                            Console.WriteLine("| Hiển thị |");
                                                            Console.WriteLine("+----------+");
                                                            ViewServices(serviceManager);
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.WriteLine("+-----+");
                                                            Console.WriteLine("| Sửa |");
                                                            Console.WriteLine("+-----+");
                                                            UpdateServices(serviceManager);
                                                            break;
                                                        }
                                                    case 4:
                                                        {
                                                            Console.WriteLine("+-----+");
                                                            Console.WriteLine("| Xoá |");
                                                            Console.WriteLine("+-----+");
                                                            DeleteServices(serviceManager);
                                                            break;
                                                        }
                                                    case 5:
                                                        {
                                                            Console.WriteLine("+----------+");
                                                            Console.WriteLine("| Tìm kiếm |");
                                                            Console.WriteLine("+----------+");
                                                            SearchServices(serviceManager);
                                                            break;
                                                        }
                                                }
                                            } while (chonMenuManagerServices != 0);
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("+-----------------------------------------+");
                                            Console.WriteLine("| Bạn đang ở chức năng quản lí thanh toán |");
                                            Console.WriteLine("+-----------------------------------------+");
                                            int ChonManagerThanhToan = -1;
                                            do
                                            {
                                                while (true)
                                                {
                                                    menu.MenuManagerPayments();
                                                    Console.Write("Nhập lựa chọn của bạn: ");
                                                    string input = Console.ReadLine();
                                                    if (int.TryParse(input, out ChonManagerThanhToan))
                                                    {
                                                        break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                                                    }
                                                }
                                                switch (ChonManagerThanhToan)
                                                {
                                                    case 0:
                                                        {
                                                            Console.WriteLine("Bạn đã quay lại");
                                                            break;
                                                        }
                                                    case 1:
                                                        {
                                                            Console.WriteLine("Hiển thị các giao dịch chưa duyệt");
                                                            HienThiGiaoDichPending(transactionManager);
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.WriteLine("Hiển thị các giao dịch đã duyệt");
                                                            HienThiGiaoDichDone(transactionManager);
                                                            break;
                                                        }
                                                }
                                            } while (ChonManagerThanhToan != 0);
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.WriteLine("+---------------------------------------+");
                                            Console.WriteLine("| Bạn đang ở chức năng báo cáo thống kê |");
                                            Console.WriteLine("+---------------------------------------+");
                                            ThongKeHoaDon(transactionManager);
                                            break;
                                        }
                                    case 6:
                                        {
                                            Console.WriteLine("+--------------------------+");
                                            Console.WriteLine("| Kênh chat với khách hàng |");
                                            Console.WriteLine("+--------------------------+");
                                            Server server = new Server();
                                            server.StartServer("127.0.0.1", 8888); // Địa chỉ IP và cổng của server
                                            serverApp.Start();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Vui lòng nhập lựa chọn hợp lệ!");
                                            break;
                                        }
                                }

                            } while (chonMenuAdmin != 0);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("+--------------------------------------+");
                            Console.WriteLine("| Bạn đang ở chức năng của khách hàng! |");
                            Console.WriteLine("+--------------------------------------+");


                            Console.WriteLine("\n Bạn cần đăng nhập để tiếp tục!\n");
                            int userID = 0;
                            string userName = string.Empty;
                            string computerName = string.Empty;

                            LoginUsers(computerManager,ref computerName, userManager, ref userName,ref userID);

                            do
                            {
                                while (true)
                                {
                                    menu.MenuKhachHang();
                                    Console.Write("Nhập lựa chọn của bạn: ");
                                    string input = Console.ReadLine();
                                    if (int.TryParse(input, out chonMenuUsers))
                                    {
                                        break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                                    }
                                    else
                                    {
                                        Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                                    }
                                }
                                switch (chonMenuUsers)
                                {
                                    case 0:
                                        {
                                            Logout(computerManager,userManager, userName,computerName);
                                            break;
                                        }
                                    case 1:
                                        {
                                            Console.WriteLine("Quản lí thông tin");
                                            int ChonQuanLiThongTinKhach = -1;
                                            
                                            do
                                            {
                                                while (true)
                                                {
                                                    menu.QuanLiThongTinKhach();
                                                    Console.Write("Nhập lựa chọn của bạn: ");
                                                    string input = Console.ReadLine();
                                                    if (int.TryParse(input, out ChonQuanLiThongTinKhach))
                                                    {
                                                        break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                                                    }
                                                }
                                                switch (ChonQuanLiThongTinKhach)
                                                {
                                                    case 0:
                                                        {
                                                            Console.WriteLine("Bạn đã quay lại trang trước");
                                                            break;
                                                        }
                                                    case 1:
                                                        {
                                                            Console.WriteLine("Bạn đang ở chức năng hiển thị thông tin khách hàng ");
                                                            ThongTinKhachHang(userManager,userName,computerName);
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.WriteLine("Đổi mật khẩu");
                                                            DoiMatKhauKhachHang(userManager, userName);
                                                            break;
                                                        }
                                                }
                                            } while (ChonQuanLiThongTinKhach != 0);
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Mua đồ");
                                            int chonMuaDo = -1;
                                            do
                                            {
                                                while (true)
                                                {
                                                    menu.MuaDo();
                                                    Console.Write("Nhập lựa chọn của bạn: ");
                                                    string input = Console.ReadLine();
                                                    if (int.TryParse(input, out chonMuaDo))
                                                    {
                                                        break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                                                    }
                                                }
                                                switch (chonMuaDo)
                                                {
                                                    case 0:
                                                        {
                                                            Console.WriteLine("Quay lại");
                                                            break;
                                                        }
                                                    case 1:
                                                        {
                                                            Console.WriteLine("hiển thị danh sách sản phẩm!");
                                                            ViewServices(serviceManager);
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.WriteLine("Hiển thị các sản phẩm đã mua!");
                                                            HienThiHoaDon(transactionManager,userID);
                                                            break;
                                                        }
                                                        case 3:
                                                        {
                                                            Console.WriteLine("Mua đồ");
                                                            ViewServices(serviceManager);
                                                            ThemHoaDon(transactionManager,userID,computerName);
                                                            break;
                                                        }
                                                }

                                            } while (chonMuaDo != 0);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("Nạp tiền");
                                            AddMoneyFromCustomer(userManager, userName);
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("Nhắn tin với nhân viên");
                                            string IpSever = "127.0.0.1";
                                            ClientApp clientApp = new ClientApp(IpSever);
                                            clientApp.Start();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Vui lòng nhập lựa chọn hợp lệ!");
                                            break;
                                        }
                                }
                            } while (chonMenuUsers != 0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Vui lòng nhập lựa chọn hợp lệ!");

                            break;
                        }

                }


            } while (chonNguoiDung != 0);
        }
        static void LoginUsers(ComputerManager computerManager,ref string computerName, UserManager userManager, ref string userName,ref int userID)
        {
            bool loginSucceeded = false;
            int SoLanDangNhapFailed = 0;
            while (!loginSucceeded && SoLanDangNhapFailed < 5)
            {
                User user = new User();
                Computer computer = new Computer();

                Console.WriteLine("Nhập tên máy tính (ví dụ: PC-01):");
                computerName = Console.ReadLine();
                computer.computer_name = computerName;

                string computerStatus = computerManager.GetComputerStatus(computer.computer_name);
                if (computerStatus == "available")
                {

                    Console.WriteLine("\n Bạn cần đăng nhập để tiếp tục!\n");
                    Console.Write("Tên đăng nhập: ");
                    userName = Console.ReadLine();
                    user.username = userName;
                    Console.Write("Mật khẩu: ");
                    user.password = ReadPassword();

                    DataTable result = userManager.LoginUsers(user);
                    int count = Convert.ToInt32(result.Rows[0][0]);
                    if (count > 0)
                    {
                        Console.WriteLine("+------------------+");
                        Console.WriteLine("| Login succeeded! |");
                        Console.WriteLine("+------------------+");

                        user.status = "online";
                        userManager.LogOut(user);
                        userName = user.username;
                        computer.status = "in_use";
                        computer.username = userName;
                        computerManager.UpdateComputers(computer);
                        loginSucceeded = true;

                        DataTable layID = userManager.SearchUsers(userName);
                        foreach (DataRow row in layID.Rows)
                        {
                            userID = Convert.ToInt32(layID.Rows[0][0]); // Assuming the userID is in the second column
                        }
                    }
                    else
                    {
                        Console.WriteLine("+---------------+");
                        Console.WriteLine("| Login Failed! |");
                        Console.WriteLine("+---------------+");
                        SoLanDangNhapFailed++;
                        if (SoLanDangNhapFailed < 5)
                        {
                            Console.WriteLine($"Số lần thử đăng nhập còn lại: {5 - SoLanDangNhapFailed}");
                        }
                    }


                    if (SoLanDangNhapFailed == 5)
                    {
                        Console.WriteLine("Bạn đã nhập sai thông tin đăng nhập quá nhiều lần. Vui lòng thử lại sau.");
                        Environment.Exit(0); // Đóng chương trình
                    }
                    else
                    {
                        Console.WriteLine("+--------------------+");
                        Console.WriteLine("| Welcome to System! |");
                        Console.WriteLine("+--------------------+");
                    }
                }
                else if (computerStatus == "in_use")
                {
                    Console.WriteLine($"Máy tính {computer.computer_name} đang có người sử dụng. Vui lòng chọn máy tính khác.\n");
                }
                else if (computerStatus == "maintenance")
                {
                    Console.WriteLine($"Máy tính {computer.computer_name} đang trong quá trình bảo trì. Vui lòng chọn máy tính khác.\n");
                }
                else
                {
                    Console.WriteLine($"Máy tính {computer.computer_name} không tồn tại hoặc có lỗi. Vui lòng chọn máy tính khác.\n");
                }
            }
        }

        static void LoginAdmin(UserManager userManager)
        {
            bool loginSucceeded = false;
            int SoLanDangNhapFailed = 0;

            while (!loginSucceeded && SoLanDangNhapFailed < 5)
            {
                User user = new User();
                Console.WriteLine("\n Bạn cần đăng nhập để tiếp tục!\n");
                Console.Write("Tên đăng nhập: ");
                user.username = Console.ReadLine();
                Console.Write("Mật khẩu: ");
                user.password = ReadPassword();
                DataTable result = userManager.LoginAdmin(user);
                int count = Convert.ToInt32(result.Rows[0][0]);
                if (count > 0)
                {
                    Console.WriteLine("+------------------+");
                    Console.WriteLine("| Login succeeded! |");
                    Console.WriteLine("+------------------+");
                    loginSucceeded = true;
                }
                else
                {
                    Console.WriteLine("+---------------+");
                    Console.WriteLine("| Login Failed! |");
                    Console.WriteLine("+---------------+");
                    SoLanDangNhapFailed++;
                    if (SoLanDangNhapFailed < 5)
                    {
                        Console.WriteLine($"Số lần thử đăng nhập còn lại: {5 - SoLanDangNhapFailed}");
                    }
                }
            }
            if (SoLanDangNhapFailed == 5)
            {
                Console.WriteLine("Bạn đã nhập sai thông tin đăng nhập quá nhiều lần. Vui lòng thử lại sau.");
                Environment.Exit(0); // Đóng chương trình
            }
            else
            {
                Console.WriteLine("+--------------------+");
                Console.WriteLine("| Welcome to System! |");
                Console.WriteLine("+--------------------+");
            }
        }
        static void Logout(ComputerManager computerManager, UserManager userManager, string username,string computerName)
        {

            User user = new User();
            user.username = username;
            user.status = "offline";

            Computer computer = new Computer(); 
            computer.computer_name = computerName;
            computer.status = "available";
            computerManager.UpdateComputers(computer);
            bool result = userManager.LogOut(user);
            if (result)
            {
                Console.WriteLine("Đăng xuất thành công!\n");
            }
            else
            {
                Console.WriteLine("Đăng xuất thất bại!\n");
            }


        }
        static void DoiMatKhauKhachHang(UserManager userManager,string userName)
        {
            User user = new User();
            user.username = userName;
            Console.Write("Nhập mật khẩu cũ : ");
            string OldPassword = Console.ReadLine();
            Console.Write("Nhập mật khẩu mới: ");
            string NewPassword = Console.ReadLine();
            Console.Write("Nhập lại mật khẩu mới : ");
            string ConfirmNewPassword = Console.ReadLine();
            if (NewPassword == ConfirmNewPassword)
            {
                user.password = NewPassword;
                if (userManager.DoiMatKhauKhachHang(user, OldPassword))
                {
                    Console.WriteLine("Đổi mật khẩu mới thành công!");
                }
                else
                {
                    Console.WriteLine("Mật khẩu cũ không đúng, vui lòng thử lại sau!");
                }
            }
            else
            {
                Console.WriteLine("Mật khẩu nhập lại không khớp!");
            }

        }
        static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info;

            do
            {
                info = Console.ReadKey(true);
                if (info.Key != ConsoleKey.Backspace && info.Key != ConsoleKey.Enter)
                {
                    password += info.KeyChar;
                    Console.Write("*");
                }
                else if (info.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    int cursorPosition = Console.CursorLeft;
                    Console.SetCursorPosition(cursorPosition - 1, Console.CursorTop);
                    Console.Write(" ");
                    Console.SetCursorPosition(cursorPosition - 1, Console.CursorTop);
                }
            } while (info.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
        static void viewAllUsers(UserManager userManager)
        {
            DataTable result = userManager.GetAllUsers();
            Console.WriteLine("+------------+----------+--------------+-----------+------------------+");
            Console.WriteLine("| Username   |  Status  |    số dư     | UserType  | total_usage_time |");
            Console.WriteLine("+------------+----------+--------------+-----------+------------------+");


            foreach (DataRow row in result.Rows)
            {
                Console.WriteLine($"| {row["username"],-10} | {row["status"],-8} | {row["balance_account"],-12} | {row["user_type"],-9} | {row["total_usage_time"],-16} | ");
                Console.WriteLine("+------------+----------+--------------+-----------+------------------+");

            }
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();
        }
        static void addUsers(UserManager userManager)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            // Kiểm tra xem tên người dùng đã tồn tại hay chưa
            if (userManager.IsUsernameExists(username))
            {
                Console.WriteLine("Tên người dùng đã tồn tại. Vui lòng chọn tên người dùng khác.");
                return;
            }

            // Tiếp tục với quá trình thêm người dùng

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();
            string userType;
            while (true)
            {
                Console.Write("Enter user type (admin, customer): ");
                userType = Console.ReadLine();

                // Chuyển userType về chữ thường để so sánh, tránh lỗi do nhập sai chữ hoa/chữ thường
                userType = userType.ToLower();

                if (userType == "admin" || userType == "customer")
                {
                    break; // Thoát vòng lặp khi người dùng nhập đúng
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'admin' or 'customer'.");
                }
            }

            User user = new User
            {
                username = username,
                password = password,
                full_name = fullName,
                user_type = userType
            };
            if (userManager.AddUsers(user))
            {
                Console.WriteLine("+-------------------------+");
                Console.WriteLine("| User added successfully |");
                Console.WriteLine("+-------------------------+");
            }
            else
            {
                Console.WriteLine("+--------------------+");
                Console.WriteLine("| Failed to add user |");
                Console.WriteLine("+--------------------+");

            }
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();
        }
        static void UpdateUsers(UserManager userManager)
        {
            Console.Write("Nhập vào tên người dùng cần sửa:");
            string username = Console.ReadLine();
            Console.Write("Nhập vào password:");
            string password = Console.ReadLine();
            Console.Write("Nhập vào họ và tên:");
            string fullname = Console.ReadLine();
            string userType;
            while (true)
            {
                Console.Write("Nhập kiểu người dùng(customer,admin):");
                userType = Console.ReadLine();

                // Chuyển userType về chữ thường để so sánh, tránh lỗi do nhập sai chữ hoa/chữ thường
                userType = userType.ToLower();

                if (userType == "admin" || userType == "customer")
                {
                    break; // Thoát vòng lặp khi người dùng nhập đúng
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'admin' or 'customer'.");
                }
            }

            User user = new User()
            {
                username = username,
                password = password,
                full_name = fullname,
                user_type = userType
            };
            if (userManager.UpdateUsers(user))
            {
                Console.WriteLine("+---------------------------+");
                Console.WriteLine("| User updated successfully |");
                Console.WriteLine("+---------------------------+");

            }
            else
            {
                Console.WriteLine("+-----------------------+");
                Console.WriteLine("| Failed to update user |");
                Console.WriteLine("+-----------------------+");

            }
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();
        }
        static void DeleteUsers(UserManager userManager)
        {
            Console.Write("Nhập vào tên người dùng cần xoá:");
            string username = Console.ReadLine();
            if (userManager.DeleteUsers(username))
            {
                Console.WriteLine("+----------------------------+");
                Console.WriteLine("| Xoá người dùng thành công! |");
                Console.WriteLine("+----------------------------+");
            }
            else
            {
                Console.WriteLine($"không có người dùng với tên :{0} ", username);
            }
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();
        }
        static void SearchUsers(UserManager userManager)
        {

            Console.Write("Nhập vào tên người dùng cần tìm:");
            string username = Console.ReadLine();

            DataTable result = userManager.SearchUser(username);
            Console.WriteLine("+------------+----------+--------------+-----------+------------------+");
            Console.WriteLine("| Username   |  Status  |    số dư     | UserType  | total_usage_time |");
            Console.WriteLine("+------------+----------+--------------+-----------+------------------+");
            foreach (DataRow row in result.Rows)
            {
                if (result != null)
                {
                    Console.WriteLine($"| {row["username"],-10} | {row["status"],-8} | {row["balance_account"],-12} | {row["user_type"],-9} | {row["total_usage_time"],-16} | ");
                    Console.WriteLine("+------------+----------+--------------+-----------+------------------+");
                }
                else
                {
                    Console.WriteLine("Không có người dùng với tên : ", username);
                }
            }
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();
        }
        static void AddMoney(UserManager userManager)
        {
            User user = new User();
            Console.Write("Nhập vào tên tài khoản cần nạp tiền : ");
            user.username = Console.ReadLine();

            decimal amount;
            bool validInput = false;
            do
            {
                Console.Write("Nhập vào số tiền cần nạp: ");
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out amount))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Số tiền nhập vào không hợp lệ. Vui lòng nhập lại.");
                }

            } while (!validInput);
            if (userManager.AddMoney(user,amount))
            {
                Console.WriteLine("+------------------------+");
                Console.WriteLine("| Add Money successfully |");
                Console.WriteLine("+------------------------+");
            }
            else
            {
                Console.WriteLine("+---------------------+");
                Console.WriteLine("| Failed to Add Money |");
                Console.WriteLine("+---------------------+");

            }
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();
        }
        static void AddMoneyFromCustomer(UserManager userManager,string userName)
        {
            User user = new User();
            user.username = userName;
            decimal amount;
            bool validInput = false;
            do
            {
                Console.Write("Nhập vào số tiền cần nạp: ");
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out amount))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Số tiền nhập vào không hợp lệ. Vui lòng nhập lại.");
                }

            } while (!validInput);
            if (userManager.AddMoney(user, amount))
            {
                Console.WriteLine("+------------------------+");
                Console.WriteLine("| Add Money successfully |");
                Console.WriteLine("+------------------------+");
            }
            else
            {
                Console.WriteLine("+---------------------+");
                Console.WriteLine("| Failed to Add Money |");
                Console.WriteLine("+---------------------+");

            }
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();
        }

        static void DeDuct(UserManager userManager)
        {
            User user = new User();
            Console.Write("Nhập vào tên tài khoản cần trừ tiền : ");
            user.username = Console.ReadLine();

            decimal amount;
            bool validInput = false;
            do
            {
                Console.Write("Nhập vào số tiền cần trừ  : ");
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out amount))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Số tiền nhập vào không hợp lệ. Vui lòng nhập lại.");
                }

            } while (!validInput);
            if (userManager.Deduct(user, amount))
            {
                Console.WriteLine("+----------------------+");
                Console.WriteLine("| Trừ tiền thành công! |");
                Console.WriteLine("+----------------------+");
            }
            else
            {
                Console.WriteLine("+--------------------+");
                Console.WriteLine("| Trừ tiền thất bại! |");
                Console.WriteLine("+--------------------+");

            }
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();
        }
        static void ViewAllComputers(ComputerManager computerManager)
        {
            DataTable result = computerManager.ViewAllComputers();
            Console.WriteLine("+----------------+--------------+------------+");
            Console.WriteLine("|  ComputerName  |    Status    |  UserName  |");
            Console.WriteLine("+----------------+--------------+------------+");
            foreach (DataRow row in result.Rows)
            {
                Console.WriteLine($"| {row["computer_name"],-14} | {row["status"],-13}| {row["username"],-10} |");
                Console.WriteLine("+----------------+--------------+------------+");
            }
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();
        }
        static void UpdateComputers(ComputerManager computerManager)
        {
            int updateComputers = -1;
            do
            {
                Menu menu = new Menu();
                while (true)
                {
                    menu.menuBaoTriMayTinh();
                    Console.Write("Nhập lựa chọn của bạn: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out updateComputers))
                    {
                        break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                    }
                    else
                    {
                        Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                    }
                }
                switch (updateComputers)
                {
                    case 0:
                        {
                            Console.WriteLine("Bạn đã thoát!");
                            break;
                        }
                    case 1:
                        {
                            Computer computer = new Computer();
                            ViewAllComputers(computerManager);
                            Console.Write("Nhập máy tính cần bảo trì(ví dụ \"PC-01\") : ");
                            computer.computer_name = Console.ReadLine();
                            computer.username = "";
                            computer.status = "maintenance";
                            if (computerManager.UpdateComputers(computer))
                            {
                                Console.WriteLine($"\nMáy tính \"{computer.computer_name}\" đang được bảo trì!");
                            }
                            else
                            {
                                Console.WriteLine($"\nMáy tính \"{computer.computer_name}\" bảo trì thất bại hoặc không tồn tại! ");
                            }
                            break;
                        }
                    case 2:
                        {
                            Computer computer = new Computer();
                            DataTable result = computerManager.ViewComputerMaintenance(computer);
                            if (result.Rows.Count > 0)
                            {
                                Console.WriteLine("Các máy đang bảo trì : ");
                                Console.WriteLine("+--------------+");
                                Console.WriteLine("| ComputerName |");
                                Console.WriteLine("+--------------+");
                                foreach (DataRow row in result.Rows)
                                {
                                    Console.WriteLine($"|    {row["computer_name"],-7}   |");
                                    Console.WriteLine("+--------------+");
                                }


                                Console.Write("Nhập vào máy tính cần đóng bảo trì(ví dụ \"PC-01\"): ");
                                computer.computer_name = Console.ReadLine();
                                computer.username = "";
                                computer.status = "available";
                                if (computerManager.UpdateComputers(computer))
                                {
                                    Console.WriteLine($"Đóng bảo trì thành công, máy tính \"{computer.computer_name}\" đã sẵn sàng sử dụng!");
                                }
                                else
                                {
                                    Console.WriteLine($"Không có máy tính với tên {computer.computer_name} !");
                                }

                            }
                            else
                            {
                                Console.WriteLine("\nKhông có máy tính nào đang bảo trì!");
                            }

                            break;
                        }
                }
            } while (updateComputers != 0);


        }
        static void SearchComputers(ComputerManager computerManager)
        {
            Computer computer = new Computer();
            Console.Write("Nhập vào tên máy tính cần tìm(ví dụ \"PC-01\") :");
            computer.computer_name = Console.ReadLine();
            DataTable result = computerManager.SearchComputers(computer);
            Console.WriteLine("+----------------+--------------+------------+");
            Console.WriteLine("|  ComputerName  |    Status    |  UserName  |");
            Console.WriteLine("+----------------+--------------+------------+");
            foreach (DataRow row in result.Rows)
            {
                if (result != null)
                {
                    Console.WriteLine($"| {row["computer_name"],-14} | {row["status"],-13}| {row["username"],-10} |");
                    Console.WriteLine("+----------------+--------------+------------+");
                }
                else
                {
                    Console.WriteLine($"Không có máy tính với tên : \"{computer.computer_name}\"  ");
                }
            }
        }

        static void AddServices(ServiceManager serviceManager)
        {
            Service service = new Service();
            Console.Write("Nhập tên sản phẩm : ");
            service.service_name = Console.ReadLine();
            decimal price;
            while (true)
            {
                Console.Write("Nhập giá sản phẩm: ");
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out price))
                {
                    break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                }
                else
                {
                    Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                }
            }
            service.price = price;
            int stock_quantity;
            while (true)
            {
                Console.Write("Nhập số lượng sản phẩm: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out stock_quantity))
                {
                    break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                }
                else
                {
                    Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                }
            }
            stock_quantity = service.stock_quantity;
            if (serviceManager.AddServices(service))
            {
                Console.WriteLine("+----------------------------+");
                Console.WriteLine("| Service added successfully |");
                Console.WriteLine("+----------------------------+");
            }
            else
            {
                Console.WriteLine("+-----------------------+");
                Console.WriteLine("| Failed to add service |");
                Console.WriteLine("+-----------------------+");
            }
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();

        }
        static void UpdateServices(ServiceManager serviceManager)
        {
            Service service = new Service();
            Console.Write("Nhập tên sản phẩm cũ : ");
            service.service_name = Console.ReadLine();
            Console.Write("Nhập tên sản phẩm mới : ");
            string newService_Name = Console.ReadLine();
            decimal price;
            while (true)
            {
                Console.Write("Nhập giá sản phẩm cần sửa: ");
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out price))
                {
                    break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                }
                else
                {
                    Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                }
            }
            service.price = price;
            int stock_quantity;
            while (true)
            {
                Console.Write("Nhập số lượng sản phẩm cần sửa :");
                string input = Console.ReadLine();
                if (int.TryParse(input, out stock_quantity))
                {
                    break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                }
                else
                {
                    Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                }
            }
            service.stock_quantity = stock_quantity;
            if (serviceManager.UpdateServices(service, newService_Name))
            {
                Console.WriteLine("+------------------------------+");
                Console.WriteLine("| Service updated successfully |");
                Console.WriteLine("+------------------------------+");
            }
            else
            {
                Console.WriteLine("+--------------------------+");
                Console.WriteLine("| Failed to update service |");
                Console.WriteLine("+--------------------------+");
            }

            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();
        }
        static void DeleteServices(ServiceManager serviceManager)
        {
            Service service = new Service();
            Console.WriteLine("Nhập vào dịch vụ cần xoá: ");
            service.service_name = Console.ReadLine();

            if (serviceManager.DeleteServices(service))
            {
                Console.WriteLine("+-------------------------+");
                Console.WriteLine("| Xoá dịch vụ thành công! |");
                Console.WriteLine("+-------------------------+");
            }
            else
            {
                Console.WriteLine($"không có dịch vụ với tên : {0} ", service.service_name);
            }
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();
        }
        static void ViewServices(ServiceManager serviceManager)
        {
            DataTable result = serviceManager.ViewAllServices();
            Console.WriteLine("+------------+-------------------+-------------------+----------------+");
            Console.WriteLine("| Service_Id |   Service_Name    |       Price       | Stock_Quantity |");
            Console.WriteLine("+------------+-------------------+-------------------+----------------+");


            foreach (DataRow row in result.Rows)
            {
                Console.WriteLine($"| {row["service_id"],-10} | {row["service_name"],-18}| {row["price"],-14} vnđ| {row["stock_quantity"],-14} |");
                Console.WriteLine("+------------+-------------------+-------------------+----------------+");

            }
            
        }
        static void SearchServices(ServiceManager serviceManager)
        {
            Service service = new Service();
            Console.Write("Nhập vào tên sản phẩm cần tìm kiếm");
            service.service_name = Console.ReadLine();

            DataTable result = serviceManager.SearchServices(service);
            Console.WriteLine("+------------+-------------------+--------+----------------+");
            Console.WriteLine("| Service_Id |   Service_Name    | Price  | Stock_Quantity |");
            Console.WriteLine("+------------+-------------------+--------+----------------+");

            foreach (DataRow row in result.Rows)
            {
                Console.WriteLine($"| {row["service_id"],-12} | {row["service_name"],-20}| {row["price"],-8} | {row["stock_quantity"],-9} |");
                Console.WriteLine("+------------+-------------------+--------+----------------+");

            }
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();
        }
        static void ThongTinKhachHang(UserManager userManager,string userName,string computerName)
        {
            
            DataTable result = userManager.SearchUsers(userName);
            foreach (DataRow row in result.Rows)
            {
                Console.WriteLine("+=======[ Thông tin khách hàng ]=======+");
                Console.WriteLine($"| PC Name: {computerName,-27} |");
                Console.WriteLine($"| User Id: {row["user_id"],-27} |");
                Console.WriteLine($"| Username: {row["username"],-26} |");
                Console.WriteLine($"| Fullname: {row["full_name"],-27}|");
                Console.WriteLine($"| Balance Account: {row["balance_account"],-16} vnđ|");
                Console.WriteLine($"| Login Time: {row["login_time"],-19}      |");
                Console.WriteLine("+======================================+");
            }

        }
        static void ThemHoaDon(TransactionManager transactionsManager,int userID,string ComputerName)
        {
            Transactions transactions = new Transactions();
            transactions.user_id = userID;
            transactions.computer_name = ComputerName;
            int service_id;
            while (true)
            {
                Console.Write("Nhập vào id sản phẩm cần mua: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out service_id))
                {
                    break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                }
                else
                {
                    Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                }
            }
            transactions.service_id = service_id;
            int quantity;
            while (true)
            {
                Console.Write("Nhập vào số lượng cần mua : ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out quantity))
                {
                    break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                }
                else
                {
                    Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                }
            }
            transactions.quantity = quantity;
            if (transactionsManager.ThemHoaDon(transactions))
            {
                Console.WriteLine("Tạo hóa đơn thành công!");
            }
            else
            {
                Console.WriteLine("Tạo hóa đơn thất bại!");
            }

        }
        static void HienThiHoaDon(TransactionManager transactionManager,int userID)
        {
            Transactions transactions = new Transactions();
            transactions.user_id = userID;
            DataTable result = transactionManager.HienThiHoaDon(transactions);
            foreach(DataRow row in result.Rows)
            {
                Console.WriteLine("+=======[ Hoá đơn ]=======+");
                Console.WriteLine($"ID giao dịch : {row["transaction_id"]}");
                Console.WriteLine($"ID người dùng : {row["user_id"]}");
                Console.WriteLine($"Máy:  : {row["computer_name"]}");
                Console.WriteLine($"ID sản phẩm : {row["service_id"]}");
                Console.WriteLine($"số lượng : {row["quantity"]}");
                Console.WriteLine($"Tổng giá : {row["total_price"]}");
                Console.WriteLine($"thời gian giao dịch : {row["transaction_time"]}");
                Console.WriteLine("+======================================+");
            }

        }
        static void HienThiGiaoDichPending(TransactionManager transactionManager)
        {
            DataTable result = transactionManager.HienThiHoaDonChoDuyet();
            Console.WriteLine("+----------------+-----------+--------------------+---------+------------+-----------------------+---------------+");
            Console.WriteLine("| ID giao dịch   |  ID user  |    ID sản phẩm     |Số lượng | Tổng tiền  |  Thời gian giao dịch  |  Trạng thái   |");
            Console.WriteLine("+----------------+-----------+--------------------+---------+------------+-----------------------+---------------+");

            foreach (DataRow row in result.Rows)
            {
                Console.WriteLine($"| {row["transaction_id"],-14} | {row["user_id"],-9} | {row["service_id"],-18} | {row["quantity"],-7} | {row["total_price"],-10} | {row["transaction_time"],-16} | {row["status"],-13} | ");
                Console.WriteLine("+----------------+-----------+--------------------+---------+------------+-----------------------+---------------+");

            }
            Transactions transactions = new Transactions();

            int transactions_id;
            while (true)
            {
                Console.Write("Nhập vào ID giao dịch đã hoàn thành để hoàn thành đơn: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out transactions_id))
                {
                    break; // Thoát vòng lặp khi người dùng nhập đúng số nguyên
                }
                else
                {
                    Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                }
            }
            transactions.transaction_id = transactions_id;
            transactions.status = "done";
            if (transactionManager.HoanThanhDon(transactions))
            {
                Console.WriteLine($"Đơn hàng với mã giao dịch :{transactions.transaction_id} đã được hoàn thành!");
            }
            else
            {
                Console.WriteLine($"Không có đơn hàng với mã giao dịch :{transactions.transaction_id} !");
            }

            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();
        }
        static void HienThiGiaoDichDone(TransactionManager transactionManager)
        {
            DataTable result = transactionManager.HienThiHoaDonDone();
            Console.WriteLine("+----------------+-----------+--------------------+---------+------------+-----------------------+---------------+");
            Console.WriteLine("| ID giao dịch   |  ID user  |    ID sản phẩm     |Số lượng | Tổng tiền  |  Thời gian giao dịch  |  Trạng thái   |");
            Console.WriteLine("+----------------+-----------+--------------------+---------+------------+-----------------------+---------------+");

            foreach (DataRow row in result.Rows)
            {
                Console.WriteLine($"| {row["transaction_id"],-14} | {row["user_id"],-9} | {row["service_id"],-18} | {row["quantity"],-7} | {row["total_price"],-10} | {row["transaction_time"],-16} | {row["status"],-13} | ");
                Console.WriteLine("+----------------+-----------+--------------------+---------+------------+-----------------------+---------------+");

            }
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Press any key to continue... |");
            Console.WriteLine("+------------------------------+");
            Console.ReadKey();
        }
        static void ThongKeHoaDon(TransactionManager transactionManager)
        {
            decimal amount = 0;
            DataTable result = transactionManager.ThongKeHoaDon();
            foreach(DataRow row in result.Rows)
            {
                if (row["total_price"] != DBNull.Value)
                {
                    amount += Convert.ToDecimal(row["total_price"]);
                }
            }
            Console.WriteLine($"Tổng tiền đã thu: {amount} vnđ ");
        }
    }
}



    