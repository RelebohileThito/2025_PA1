using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using _2025_PA1.BL.Classes;

namespace _2025_PA1.DAL
{
    public class AnimalContext:DbContext
    {
        public DbSet<Parrot> Parrots { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Animals.db");
            //SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            
        }

    }
    
}
