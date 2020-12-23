using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Taxpayer.Domain.Models;

namespace Taxpayer.Application.Common
{
    public class Taxpayer_DBContext : DbContext
    {
        public Taxpayer_DBContext(DbContextOptions<Taxpayer_DBContext> options)
            : base(options)
        {

        }
       public DbSet<Taxpayer.Domain.Models.Taxpayer> Taxpayer { get; set; }
    }
}
