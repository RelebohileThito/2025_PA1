using _2025_PA1.BL;
using _2025_PA1.BL.Classes;
using System;

namespace _2025_PA1
{
    internal class Program
    {
        public static List<Parrot> parrotList;
        public static ParrotBL pBL;
        static void Main(string[] args)
        {
            // ShowMenu();
            // ShowParrotMain

            char choice = '0';
            ConsoleKeyInfo cki;
            try
            {
                Initialize();
                Console.WriteLine();
                ShowMenu();
                cki = Console.ReadKey();
                Console.WriteLine();
                choice = cki.KeyChar;
                while (choice != 'x' && choice != 'X')
{
                    switch (choice)
                    {
                        case '1':
                                ProcessParrotMenu();
                            break;
                        case 'x':
                        case 'X':
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    } // end switch
                    Console.WriteLine();
                    ShowMenu();
                    cki = Console.ReadKey();
                    Console.WriteLine();
                    choice = cki.KeyChar;
                } // end while
            } // end try
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } // end catch


        }

        static void Initialize()
        {
            parrotList = new List<Parrot>();
            pBL = new ParrotBL("SQLiteProvider");
        }
        public static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter an option: ");
            Console.WriteLine("_________________________________________");
            Console.WriteLine("_________________________________________");
            Console.WriteLine("1. Parrot Maintenance");
            Console.WriteLine("X. Exit");
        }
        public static void ShowParrotMain()
        {
            Console.WriteLine("1. List Parrots");
            Console.WriteLine("2. Add Parrot");
            Console.WriteLine("3. Remove Parrot");
            Console.WriteLine("4. Update Parrot");
            Console.WriteLine("R. Return");
        }

        public static void ProcessParrotMenu()
        {
            char choice = '0';
            ConsoleKeyInfo cki;
            Console.WriteLine();
            ShowParrotMain();

            cki = Console.ReadKey();
            Console.WriteLine();
            choice = cki.KeyChar;
            while (choice != 'r' && choice != 'R')
            {
                switch (choice)
                {
                    case '1':
                        ParrotList();
                        break;
                    case '2':
                        ParrotAdd();
                        break;
                    case '3':
                        ParrotRemove();
                        break;
                    case '4':
                        ParrotUpdate();
                        break;
                    case 'R':
                    case 'r':
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                } // end switch
                Console.WriteLine();
                ShowParrotMain();

                cki = Console.ReadKey();
                Console.WriteLine();
                choice = cki.KeyChar;
            }
        }
        public static void ParrotUpdate()
        {
            string ID = "";
            string age = "";
            string Name = "";
            string trainerName = "";
            int rc = 0;
            int trainerExperience = 0;
            bool change = false;
            Parrot parrot = new Parrot();
            Console.Write("Please enter the parrot ID: ");
            ID = Console.ReadLine().ToUpper();
            rc = pBL.SelectParrot(ID, ref parrot);
            if (rc == 0)
            {
                parrot.ID = ID;
                Console.WriteLine(parrot);
                Console.Write("New age or press enter not to change: ");
                age = Console.ReadLine();
                if (age.Length != 0)
                {
                    parrot.Age = Convert.ToInt32(age);
                    change = true;
                } // end if
                Console.Write("New name or press enter not to change: ");
                Name = Console.ReadLine();
                if (Name.Length != 0)
                {
                    parrot.Name = Name;
                    change = true;
                } // end if
                Console.Write("New trainer name or press enter not to change: ");
                trainerName = Console.ReadLine();
                if (trainerName.Length != 0)
                {
                    parrot.Trainer.Name = trainerName;
                    change = true;
                }
                Console.Write("New trainer experience years or press enter not to change: ");
                trainerExperience = Convert.ToInt32(Console.ReadLine());
                if (trainerExperience != 0)
                {
                    parrot.Trainer.ExperienceYears = trainerExperience;
                    change = true;
                }
                if (change)
                {
                    rc = pBL.Update(parrot);
                    if (rc == -1)
                    {
                        Console.WriteLine(ID + " NOT updated since it is not in the DB");
                    } // end if
                    else
                    {
                        Console.WriteLine(ID + " updated");
                    } // end else
                } // end if
                else
                {
                    Console.WriteLine("Nothing selected to update");
                } // end else
            } // end if
            else
            {
                Console.WriteLine(ID + " NOT found");
            } // end else
        } // end method
        public static void ParrotAdd()
        {
            string ID = "";
            string Name = "";
            string trainerName = "";
            int trainerExperience = 0;
            int age = 0;
            int rc = 0;
            Parrot parrot = null;
            Console.WriteLine("Please supply the following Parrot info:");
            Console.Write("ID: ");
            ID = Console.ReadLine().ToUpper();
            rc = pBL.SelectParrot(ID, ref parrot);
            if (rc == 0)
            {
                Console.WriteLine(ID + " NOT added since it is already in the DB");
            } // end if
            else
            {
                Console.Write("Age: ");
                age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Name: ");
                Name = Console.ReadLine();
                Console.Write("Trainer Name: ");
                trainerName = Console.ReadLine();
                Console.Write("Trainer experience years: ");
                trainerExperience = Convert.ToInt32(Console.ReadLine());
                rc = pBL.Insert(new Parrot(ID, Name, age));
                if (rc == -1)
                {
                    Console.WriteLine(ID + " NOT added since it is already in the DB");
                } // end if
                else
                {
                    Console.WriteLine(ID + " added");
                } // end else
            } // end else
        }
        public static void ParrotRemove()
        {
            string code = "";
            int rc = 0;
            if (parrotList.Count > 0)
            {
                Console.Write("Please enter the Parrot ID: ");
                code = Console.ReadLine().ToUpper();
                rc = pBL.Delete(code);
                if (rc == 0)
                {
                    Console.WriteLine(code + " removed from DB");
                } // end if
                else
                {
                    Console.WriteLine(code + " NOT removed since it is not in the DB");
                } // end else
            } // end if
            else
            {
                Console.WriteLine("No Parrot record to remove from DB");
            } // end else

        }
        public static void ParrotList()
        {
            parrotList = pBL.SelectAll();
            if (parrotList.Count == 0)
            {
                Console.WriteLine("No Parrot records found");
            } // end if
            else
            {
                foreach (Parrot pRef in parrotList)
                {
                    Console.WriteLine(pRef);
                } // end foreach
            } // end if
        }

        

    }
        
    
}