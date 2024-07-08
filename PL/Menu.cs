using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Menu
    {
        public void MenuLuaChon()
        {
            Console.WriteLine("+=====[ Chọn người dùng ]=====+");
            Console.WriteLine("| 0.Thoát                     |");                                    
            Console.WriteLine("| 1.Administrator             |");
            Console.WriteLine("| 2.Customers                 |");
            Console.WriteLine("+-----------------------------+");
        }
        public void MenuAdmin()
        {
            Console.WriteLine("+========[ Administrator ]========+");
            Console.WriteLine("| 0.Quay lại                      |");
            Console.WriteLine("| 1.Quản lí người dùng            |");
            Console.WriteLine("| 2.Quản lí máy tính              |");
            Console.WriteLine("| 3.Quản lí dịch vụ               |");
            Console.WriteLine("| 4.Quản lí thanh toán            |");
            Console.WriteLine("| 5.Báo cáo thống kê              |");
            Console.WriteLine("| 6.Kênh chat với khách hàng      |");
            Console.WriteLine("+---------------------------------+");
        }
        public void MenuManagerUsers()
        {
            Console.WriteLine(" Quản lí người dùng ");
            Console.WriteLine(" 0.Quay lại");
            Console.WriteLine(" 1.Thêm");
            Console.WriteLine(" 2.Hiển thị");
            Console.WriteLine(" 3.Sửa");
            Console.WriteLine(" 4.Xoá");
            Console.WriteLine(" 5.Tìm kiếm");
            Console.WriteLine(" 6.Nạp tiền");
            Console.WriteLine(" 7.Trừ tiền");

        }
        public void MenuMangagerComputers()
        {
            Console.WriteLine("Quản lí máy tính");
            Console.WriteLine("0.Quay lại");
            Console.WriteLine("1.Hiển thị");
            Console.WriteLine("2.Bảo trì máy tính");
            Console.WriteLine("3.Tìm kiếm");
        }
        public void menuBaoTriMayTinh()
        {
            Console.WriteLine("bao tri may tinh (trong quan li may tinh)");
            Console.WriteLine("0.Quay lại");
            Console.WriteLine("1.Bảo trì máy tính");
            Console.WriteLine("2.Đóng bảo trì");
        }
        public void MenuManagerServices()
        {
            Console.WriteLine("menu quan li dich vi");
            Console.WriteLine("0.Quay lại");
            Console.WriteLine("1.Thêm");
            Console.WriteLine("2.Hiển thị");
            Console.WriteLine("3.Sửa");
            Console.WriteLine("4.Xoá");
            Console.WriteLine("5.Tìm kiếm");

        }
        public void MenuManagerPayments()
        {
            Console.WriteLine("quarn li thanh toasn");
            Console.WriteLine("0.Quay lại");
            Console.WriteLine("1.Hiển thị các máy cần duyệt đơn");
            Console.WriteLine("2.Hiển thị các máy đã duyệt đơn");
        }
        public void MenuReports()
        {
            Console.WriteLine("báo cáo");
            Console.WriteLine("0.Quay lại");
            Console.WriteLine("1.Hiển thị báo cáo hôm nay");
        }
        public void MenuKhachHang()
        {

            Console.WriteLine("+=========[ Menu khách hàng ]=========+");
            Console.WriteLine("| 0.Đăng xuất                         |");
            Console.WriteLine("| 1.Quản lí thông tin                 |");
            Console.WriteLine("| 2.Mua đồ                            |");
            Console.WriteLine("| 3.Nạp tiền                          |");
            Console.WriteLine("| 4.Nhắn tin nhân viên                |");
            Console.WriteLine("+-------------------------------------+");
        }
        public void QuanLiThongTinKhach()
        {
            Console.WriteLine("Quan li thong tin khach hang");
            Console.WriteLine("0.Quay lại");
            Console.WriteLine("1.Hiển thị thông tin cá nhân");
            Console.WriteLine("2.Đổi mật khẩu");
        }
        public void MuaDo()
        {
            Console.WriteLine("Menu mua do");
            Console.WriteLine("0.Quay lại");
            Console.WriteLine("1.Hiển thị danh sách sản phẩm");
            Console.WriteLine("2.Hiển thị danh sách sản phẩm đã mua");
            Console.WriteLine("3.Mua sản phẩm");
        }
    }
}
