using BIMS.DataAccess.Models;
using BIMS.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.DataAccess.IRepository
{
    public interface ISalesRepository
    {
        Task<List<SalesOrderVM>> GetAllSalesOrder();
        Task<bool> Create(SalesOrder model);
        Task<int> GetAvailableQuantityByProductId(int productId);
    }
}
