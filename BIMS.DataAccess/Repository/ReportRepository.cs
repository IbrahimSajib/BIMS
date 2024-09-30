using BIMS.DataAccess.Data;
using BIMS.DataAccess.IRepository;
using BIMS.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.DataAccess.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly BIMSDbContext _db;

        public ReportRepository(BIMSDbContext db)
        {
            _db = db;
        }


        public async Task<TotalItemVM> GetTotalItemCount()
        {
            TotalItemVM data = new TotalItemVM()
            {
                TotalCategory = await _db.Category.CountAsync(),
                TotalCustomer = await _db.Customer.CountAsync(),
                TotalSupplier = await _db.Supplier.CountAsync(),
                TotalProduct = await _db.Product.CountAsync(),
                TotalPurchaseOrder = await _db.PurchaseOrder.CountAsync(),
                TotalSalesOrder = await _db.SalesOrder.CountAsync()
            };

            return data;
        }

    }
}
