using BIMS.DataAccess.Models;
using BIMS.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.Services.IService
{
    public interface IPurchaseServic
    {
        Task<List<PurchaseOrderVM>> GetAllPurchaseOrder();
        Task<bool> Create(PurchaseOrder model);
    }
}
