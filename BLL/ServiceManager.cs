using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServiceManager
    {
        private readonly ServiceRepository _serviceRepository;
        public ServiceManager(ServiceRepository serviceRepository) 
        {
            _serviceRepository = serviceRepository;
        }
        public DataTable ViewAllServices()
        {
            return _serviceRepository.ViewAllServices();
        }
        public DataTable SearchServices(Service service)
        {
            return _serviceRepository.SearchServices(service);
        }
        public bool AddServices(Service service)
        {
            return _serviceRepository.AddServices(service);
        }
        public bool DeleteServices(Service service)
        {
            return _serviceRepository.deleteServices(service);
        }
        public bool UpdateServices(Service service,string NewS)
        {
            return _serviceRepository.UpdateServices(service,NewS);
        }

        public Service GetServiceById(int service_id)
        {
            DataTable dt = _serviceRepository.GetServiceById(service_id);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = dt.Rows[0];
            return new Service
            {
                service_id = Convert.ToInt32(row["service_id"]),
                service_name = row["service_name"].ToString(),
                price = Convert.ToDecimal(row["price"]),
                stock_quantity = Convert.ToInt32(row["stock_quantity"])
            };
        }
        public bool UpdateServiceBuy(Service service)
        {
            return _serviceRepository.UpdateServiceBuy(service);
        }
    }
}
