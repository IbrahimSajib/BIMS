using BIMS.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.DataAccess.IRepository
{
    public interface IReportRepository
    {
        Task<TotalItemVM> GetTotalItemCount();
        Task<InventoryReportVM> GetInventoryReport(InventoryReportVM model);
    }
}
