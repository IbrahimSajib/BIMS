﻿using BIMS.DataAccess.Data;
using BIMS.DataAccess.IRepository;
using BIMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.DataAccess.Repository
{
    public class DDLRepository : IDDLRepository
    {
        private readonly BIMSDbContext _db;

        public DDLRepository(BIMSDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoryDDL()
        {
            IEnumerable<SelectListItem> datas = await _db.Category.Where(x => x.IsActive == 1)
              .Select(c => new SelectListItem
              {
                  Value = c.CategoryId.ToString(),
                  Text = c.CategoryName.ToString()
              }).Distinct().ToListAsync();

            return datas.OrderBy(x => x.Text).ToList();
        }


        public async Task<IEnumerable<SelectListItem>> GetCategoryDDL(int categoryid)
        {
            IEnumerable<SelectListItem> datas = await _db.Category.Where(x => x.IsActive == 1 || x.CategoryId == categoryid)
              .Select(c => new SelectListItem
              {
                  Value = c.CategoryId.ToString(),
                  Text = c.CategoryName.ToString()
              }).Distinct().ToListAsync();

            return datas.OrderBy(x => x.Text).ToList();
        }


        public async Task<IEnumerable<SelectListItem>> GetSupplierDDL()
        {
            IEnumerable<SelectListItem> datas = await _db.Supplier.Where(x => x.IsActive == 1)
              .Select(s => new SelectListItem
              {
                  Value = s.SupplierId.ToString(),
                  Text = s.SupplierName.ToString() + "-" + s.SupplierCode.ToString()
              }).Distinct().ToListAsync();

            return datas.OrderBy(x => x.Text).ToList();
        }

        public async Task<IEnumerable<SelectListItem>> GetSupplierDDL(int supplierId)
        {
            IEnumerable<SelectListItem> datas = await _db.Supplier.Where(x => x.IsActive == 1 || x.SupplierId==supplierId)
              .Select(s => new SelectListItem
              {
                  Value = s.SupplierId.ToString(),
                  Text = s.SupplierName.ToString()+"-"+s.SupplierCode.ToString()
              }).Distinct().ToListAsync();

            return datas.OrderBy(x => x.Text).ToList();
        }


        public async Task<IEnumerable<SelectListItem>> GetCustomerDDL()
        {
            IEnumerable<SelectListItem> datas = await _db.Customer.Where(x => x.IsActive == 1)
              .Select(s => new SelectListItem
              {
                  Value = s.CustomerId.ToString(),
                  Text = s.CustomerName.ToString() + "-" + s.CustomerCode.ToString()
              }).Distinct().ToListAsync();

            return datas.OrderBy(x => x.Text).ToList();
        }
        
        public async Task<IEnumerable<SelectListItem>> GetCustomerDDL(int customerId)
        {
            IEnumerable<SelectListItem> datas = await _db.Customer.Where(x => x.IsActive == 1 || x.CustomerId == customerId)
              .Select(s => new SelectListItem
              {
                  Value = s.CustomerId.ToString(),
                  Text = s.CustomerName.ToString() + "-" + s.CustomerCode.ToString()
              }).Distinct().ToListAsync();

            return datas.OrderBy(x => x.Text).ToList();
        }


    }
}
