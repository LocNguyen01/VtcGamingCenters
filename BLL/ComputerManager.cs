using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class ComputerManager
    {
        ComputerRepository repository;
        public ComputerManager(ComputerRepository computerRepository)
        {
            repository = computerRepository;
        }
        public DataTable ViewAllComputers()
        {
            return repository.GetAllComputers();

        }
        public bool UpdateComputers(Computer computer)
        {
            return repository.UpdateComputer(computer);
        }
        public DataTable ViewComputerMaintenance(Computer computer)
        {
            return repository.ViewComputersMaintenance(computer);
        }
        public DataTable SearchComputers(Computer computer)
        {
            return repository.SearchComputer(computer);
        }
        public string GetComputerStatus(string computerName)
        {
            return repository.GetComputerStatus(computerName);
        }
    }
}
