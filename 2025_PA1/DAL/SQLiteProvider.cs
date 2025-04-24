using System;
using System.Collections.Generic;
using System.IO.Pipes;
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
    public class SQLiteProvider:ProviderBase
    {
        public override List<Parrot> SelectAll()
        {
            List<Parrot> parrotList;
            try
            {
                parrotList = new List<Parrot>();
                using (AnimalContext db = new AnimalContext())
                {
                    foreach (Parrot item in db.Parrots)
                    {
                        parrotList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return parrotList;
        }

        public override int SelectParrot(string ID, ref Parrot parrot)
        {
            int it;

            try
            {
                using (AnimalContext db = new AnimalContext())
                {
                    parrot = db.Parrots.FirstOrDefault(p => p.ID.Equals(ID));
                    if (parrot == null)//not found
                    {
                        it = -1;
                    }
                    else
                    {
                        it = 0;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return it;
        }

        public override int Insert(Parrot newParrot)
        {
            Parrot parrot;
            int it;
            try
            {
                using (AnimalContext db = new AnimalContext())
                {
                    parrot = db.Parrots.FirstOrDefault(b=>b.ID.Equals(newParrot));
                    if (parrot==null)
                    {
                        db.Parrots.Add(newParrot);
                        db.SaveChanges();
                        it = 0;
                    }
                    else
                    {
                        it = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return it;
        }

        public override int Update(Parrot existingParrot)
        {
            Parrot parrot;
            int it;
            try
            {
                using (AnimalContext db = new AnimalContext())
                {
                    parrot = db.Parrots.FirstOrDefault(p => p.ID.Equals(existingParrot));
                    if (parrot == null)
                    {
                        it = -1;
                    }
                    else
                    {
                        parrot.Age = existingParrot.Age;
                        parrot.Name = existingParrot.Name;
                        parrot.Trainer.Name = existingParrot.Trainer.Name;
                        parrot.Trainer.ExperienceYears = existingParrot.Trainer.ExperienceYears;
                        db.SaveChanges();
                        it = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return it;
        }

        public override int Delete(string ID)
        {
            Parrot parrot;
            int it;
            try
            {
                using (AnimalContext db = new AnimalContext())
                {
                    parrot = db.Parrots.FirstOrDefault(b => b.ID.Equals(ID));
                    if (parrot == null)
                    {
                        it = -1;
                    }
                    else
                    {
                        db.Parrots.Remove(parrot);
                        db.SaveChanges();
                        it = 0;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return it;
        }

    }
}
