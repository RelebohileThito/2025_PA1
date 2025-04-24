using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using _2025_PA1.BL.Classes;

namespace _2025_PA1.DAL
{
    public abstract class ProviderBase
    {
        public abstract List<Parrot>SelectAll();
        public abstract int SelectParrot(string ID, ref Parrot parrot);
        public abstract int Insert(Parrot newParrot);
        public abstract int Update(Parrot existingParrot);
        public abstract int Delete(string ID);
    }
}
