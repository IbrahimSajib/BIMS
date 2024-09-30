﻿using BIMS.DataAccess.IRepository;
using BIMS.DataAccess.ViewModels;
using BIMS.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.Services.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _rRepo;

        public ReportService(IReportRepository rRepo)
        {
            _rRepo = rRepo;
        }

        public async Task<TotalItemVM> GetTotalItemCount()
        {
            return await _rRepo.GetTotalItemCount();
        }
    }
}
