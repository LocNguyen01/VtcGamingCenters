using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TransactionManager
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly ServiceManager _serviceManager;

        public TransactionManager(TransactionRepository transactionRepository, ServiceManager serviceManager)
        {
            _transactionRepository = transactionRepository;
            _serviceManager = serviceManager;
        }
        public DataTable HienThiHoaDon(Transactions transaction)
        {
            return _transactionRepository.HoaDonThanhToan(transaction);
        }
        public bool ThemHoaDon(Transactions transactions)
        {
            Service service = _serviceManager.GetServiceById(transactions.service_id);
            if (service == null)
            {
                Console.WriteLine("Dịch vụ không tồn tại!");
                return false;
            }

            if (service.stock_quantity < transactions.quantity)
            {
                Console.WriteLine("Số lượng tồn kho không đủ!");
                return false;
            }

            service.stock_quantity -= transactions.quantity;
            _serviceManager.UpdateServiceBuy(service);

            transactions.total_price = transactions.quantity * service.price;

            return _transactionRepository.ThemHoaDon(transactions);
        }

        public DataTable HienThiHoaDonChoDuyet()
        {
            return _transactionRepository.HienThiHoaDonChoDuyet();
        }
        public DataTable HienThiHoaDonDone()
        {
            return _transactionRepository.HienThiHoaDonDone();
        }
        public bool HoanThanhDon(Transactions transactions)
        {
            return _transactionRepository.HoanThanhDon(transactions);
        }
        public DataTable ThongKeHoaDon()
        {
            return _transactionRepository.ThongKeHoaDon();
        }
    }
}
