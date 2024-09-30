using BIMS.DataAccess.IRepository;
using BIMS.DataAccess.Models;
using BIMS.DataAccess.ViewModels;
using BIMS.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.Services.Service
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _sRepo;

        public SalesService(ISalesRepository sRepo)
        {
            _sRepo = sRepo;
        }

        public async Task<List<SalesOrderVM>> GetAllSalesOrder()
        {
            return await _sRepo.GetAllSalesOrder();
        }
        public async Task<bool> Create(SalesOrder model)
        {
            return await _sRepo.Create(model);
        }
    }
}
