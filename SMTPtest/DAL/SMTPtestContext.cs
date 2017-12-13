using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SMTPtest.Models;

namespace SMTPtest.DAL
{
    public class SMTPtestContext: DbContext
    {
        public SMTPtestContext(): base("SMTPtestContext") { }

        public DbSet<User> Users { get; set; }
    }
}