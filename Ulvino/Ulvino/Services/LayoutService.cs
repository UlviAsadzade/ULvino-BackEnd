using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;

namespace Ulvino.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public Setting GetSetting()
        {
            return _context.Settings.FirstOrDefault();
        }
    }
}
