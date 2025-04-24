using _2025_PA1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using Microsoft.Data.Sqlite;
using _2025_PA1.BL.Classes;


namespace _2025_PA1.BL
{
    public class ParrotBL
    {
        private ProviderBase providerBase;
        public ParrotBL(string Provider)
        {
            setupProviderBase(Provider);
        }
        
            
        
        public List<Parrot> SelectAll()
        {
            return providerBase.SelectAll();
        }
        public int SelectParrot(string ID, ref Parrot parrot)
        {
            return providerBase.SelectParrot(ID,ref parrot);
        }
        public int Insert(Parrot newParrot)
        {
            return providerBase.Insert(newParrot);
        }
        public int Update(Parrot newParrot)
        {
            return providerBase.Update(newParrot);
        }
        public int Delete(string ID)
        {
            return providerBase.Delete(ID);
        }
        private void setupProviderBase(string Provider)
        {
            if (Provider == "XMLProvider")
            {
                //providerBase = new XMLProvider();
            } // end if
            else
            {
                if (Provider == "SQLiteProvider")
                {
                    providerBase = new SQLiteProvider();
                } // end if
                else
                {
                    if (Provider == "MySQLProvider")
                    {
                        //providerBase = new MySQLProvider();
                    } // end if
                } // end else
            } // end else
        }

    }
}
