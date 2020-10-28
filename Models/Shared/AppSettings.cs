using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication47.Models.Shared
{
    public class AppSettings
    {
        public static string ConnectionString()
        {
            return @"Data Source=DESKTOP-6AVBNVP\SQLEXPRESS;Initial Catalog=TestDB2;Integrated Security=True";
        }
    }
}
