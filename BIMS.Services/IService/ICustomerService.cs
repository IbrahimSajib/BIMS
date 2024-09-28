﻿using BIMS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.Services.IService
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(int CustomerId);
        Task<bool> Create(Customer model);
        Task<bool> Edit(Customer model);
        Task<bool> IsCustomerCodeExist(int CustomerId, string CustomerCode);
    }
}
