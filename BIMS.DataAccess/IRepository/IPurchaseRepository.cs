using BIMS.DataAccess.Models;
using BIMS.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.DataAccess.IRepository
{
    public interface IPurchaseRepository
    {
        Task<List<PurchaseOrderVM>> GetAllPurchaseOrder();
        Task<bool> Create(PurchaseOrder model);
    }
}
