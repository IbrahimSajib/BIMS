using BIMS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.Services.IService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> GetProductById(int ProductId);
        Task<bool> Create(Product model);
        Task<bool> Edit(Product model);
        Task<bool> IsProductExist(int ProductId, string ProductName);
    }
}
