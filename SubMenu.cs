using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CKD3910
{
    public class SubMenu
    {
        public int ColPos { get; set; }
        public int RowPos { get; set; }
        public int SelectedItem { get; set; }

        public List<MenuItem> MenuItems { get; set; }

        public List<Module> Modules { get; set; }

        //constructor
        public SubMenu()
        {

            ColPos = 15;
            RowPos = 12;
            SelectedItem = 0;
            //List<int> A = new List<int> {1, 2, 3, 4};

            MenuItems = new List<MenuItem>
            {
                new MenuItem("MODIFY USER", true),
                new MenuItem("DELETE USER",false),
                new MenuItem("ADD MODULE", false),
                new MenuItem("DELETE MODULE", false),
                new MenuItem("BACK", false),

            };
        }

        public void DisplaySubMenu(Student students1, List<Student> students)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;
            bool running = true;

            while (running) //loop to check the actions
            {
                Console.SetCursorPosition(ColPos, RowPos);
                //Console.Write("Hello");

                for (int i = 0; i < MenuItems.Count; i++)
                {
                    Console.SetCursorPosition(ColPos, RowPos + i);
                    //Console.Write(MenuItems[i].Title);
                    if (MenuItems[i].IsSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        //Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(MenuItems[i].Title);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(MenuItems[i].Title);
                    }
                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem + 1) % MenuItems.Count;
                    MenuItems[SelectedItem].IsSelected = true;
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem - 1);
                    if (SelectedItem < 0)
                    {
                        SelectedItem = MenuItems.Count - 1;
                    }
                    MenuItems[SelectedItem].IsSelected = true;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(2, 0);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.WriteLine($"You Selected {MenuItems[SelectedItem].Title}");

                    if (MenuItems[SelectedItem].Title== "MODIFY USER")
                    {
                        Console.Clear();
                        Console.WriteLine("For the cofirmation");
                        Console.Write("Enter the User ID Again : ");
                        int userid = Convert.ToInt32(Console.ReadLine());

                        Student selectedUser = students.Find(u => u.ID == userid);

                        if (selectedUser != null)
                        {
                            Console.WriteLine("Enter the new First Name: ");
                            selectedUser.FirstName = Console.ReadLine();
                            Console.WriteLine("Enter the new Last Name: ");
                            selectedUser.LastName = Console.ReadLine();
                            Console.WriteLine("Enter the new Date of Birth: ");
                            selectedUser.DateOfBirth = Console.ReadLine();
                            Console.WriteLine("Enter the new Address: ");
                            selectedUser.Address = Console.ReadLine();
                            Console.WriteLine("User has been modified successfully!");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");

                        }
                        Console.WriteLine("\nPress any key to return to the main menu");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    if (MenuItems[SelectedItem].Title == "DELETE USER")
                    {
                        Console.Clear();
                        Console.WriteLine("For the cofirmation");
                        Console.Write("Enter the User ID Again : ");
                        int userid = Convert.ToInt32(Console.ReadLine());

                        Student selectedUser = students.Find(u => u.ID == userid);
                        

                        if (selectedUser!=null)
                        {
                            Console.WriteLine("Confirm to press ENTER");
                            var key1 = Console.ReadKey();
                            //char p = Convert.ToChar(Console.ReadLine());
                            if (key1.Key == ConsoleKey.Enter)
                            {
                                students.Remove(selectedUser);
                                Console.Write("Press any Key to Continue..");
                                Console.ReadLine();
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Invalid Command");
                                Console.Clear();
                                
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid User ID !");
                            
                        }
                    }

                    if (MenuItems[SelectedItem].Title == "ADD MODULE")
                    {
                        Console.WriteLine($"You Selected {MenuItems[SelectedItem].Title}");

                        Console.WriteLine();
                        Console.Clear(); 
                        Console.WriteLine("Available Modules are");
                        Console.WriteLine("# 3305 Signal and Systems");
                        Console.WriteLine("# 3301 Analog Electronics");
                        Console.WriteLine("# 3302 Data Structures and Algorithems");
                        Console.WriteLine("# 3203 Measurement");
                        Console.WriteLine("# 3251 GUI Prgramming");
                        Console.WriteLine("# 3250 Programming  Project");

                        
                        

                        Console.Write("Enter Module Name : ");
                        String modulename = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write("Enter Module ID  : ");
                        String moduleid = Console.ReadLine();
                        Console.WriteLine();


                        Console.Write("Enter Grade :  ");
                        char grade = Convert.ToChar(Console.ReadLine());
                        Console.WriteLine();

                        Console.Write("Enter Credit Value of Module: ");
                        int creditpoint = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();


                        double gradepoint = 0;

                        if (grade == 'A')
                        {
                            gradepoint = 4;
                        }
                        if (grade == 'B')
                        {
                            gradepoint = 3;
                        }
                        if (grade == 'C')
                        {
                            gradepoint = 2;
                        }
                        if (grade == 'E')
                        {
                            gradepoint = 0;
                        }
                        //int gpa = students1.Calculate_Gpa();

                        Module module = new Module(moduleid, modulename, gradepoint, creditpoint, grade);
                        students1.Modules.Add(module);
                        Console.WriteLine();
                        Console.WriteLine("Press Any Key to Continue..");
                        Console.ReadLine();

                        Console.Clear();

                        Console.WriteLine("-Module Added-");


                    }


                    if (MenuItems[SelectedItem].Title == "DELETE MODULE")
                    {
                        Console.Clear();
                        Console.WriteLine("For the cofirmation");
                        Console.Write("Enter the User ID Again : ");
                        int modid = Convert.ToInt32(Console.ReadLine());

                        Student selectedModule = students.Find(u => u.ID == modid);


                        if (selectedModule != null)
                        {
                            Console.WriteLine("Confirm to press ENTER");
                            var key1 = Console.ReadKey();
                            //char p = Convert.ToChar(Console.ReadLine());
                            if (key1.Key == ConsoleKey.Enter)
                            {
                                students.Remove(selectedModule);
                                Console.Write("Press any Key to Continue..");
                                Console.ReadLine();
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Invalid Command");
                                Console.Clear();

                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid User ID !");

                        }
                    }
                    if (MenuItems[SelectedItem].Title == "BACK")
                    {
                        //string response = Console.ReadLine().ToLower();
                        running = false;
                    }

                }
            }
        }
    }
}