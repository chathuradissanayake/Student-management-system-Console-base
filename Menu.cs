using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CKD3910
{
    public class Menu
    {
        public int ColPos { get; set; }
        public int RowPos { get; set; }
        public int SelectedItem { get; set; }



        public List<MenuItem> MenuItems { get; set; }
        List<Student> students = new List<Student>();


        //constructor
        public Menu()
        {

            ColPos = 15;
            RowPos = 12;
            SelectedItem = 0;


            //List<int> A = new List<int> {1, 2, 3, 4};

            MenuItems = new List<MenuItem>
            {
                new MenuItem("ADD USER", true),
                new MenuItem("SELECT USER", false),
                new MenuItem("DELETE USER", false),
                new MenuItem("DISPLAY ALL USERS", false),
                new MenuItem("QUIT", false)
            };
        }

        public void DisplayMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;
            bool running = true;

            while (running) //loop to check the actions
            {
                Console.SetCursorPosition(ColPos, RowPos);
                

                for (int i = 0; i < MenuItems.Count; i++)
                {
                    Console.SetCursorPosition(ColPos, RowPos + i);
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
                    Console.WriteLine($"You Selected {MenuItems[SelectedItem].Title}");

                    if (MenuItems[SelectedItem].Title == "ADD USER")
                    {
                        Console.Clear();
                        Console.WriteLine($"You Selected {MenuItems[SelectedItem].Title}");


                        Console.WriteLine();


                        

                        Console.Write("Enter your First Name : ");
                        String firstname = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write("Enter your Last Name  : ");
                        String lastname = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write("Enter your Date of Birth DD/MM/YYYY :  ");
                        String birthday = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write("Enter Address: ");
                        string address = Console.ReadLine();
                        Console.WriteLine();

                        int id =students.Count + 1001;
                        Console.Write("Your Details Added Successfully");
                        Console.WriteLine();

                        Console.WriteLine("Your ID is : " + id);

                        Student Students = new Student(id, firstname, lastname, birthday, address);
                        students.Add(Students);
                        Console.WriteLine();
                        Console.WriteLine("Press Any Key to Continue..");
                        Console.ReadLine();

                        Console.Clear();
                        
                    }


                    if (MenuItems[SelectedItem].Title == "SELECT USER")

                    {
                        bool found = false;
                        Console.Clear();
                        Console.WriteLine("Enter the ID");


                        int id = Convert.ToInt32((Console.ReadLine()));

                        foreach (Student students1 in students)
                        {
                            if (students1.ID == id)
                            {
                                Console.WriteLine("Is this the User(y/n)");
                                found = true;
                                char p = Convert.ToChar(Console.ReadLine());
                                if (p == 'y')
                                {
                                    SubMenu submenu = new SubMenu();
                                    submenu.DisplaySubMenu(students1, students);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Command");
                                    Console.Clear();
                                    break;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Invalid User ID !");
                                //Console.ForegroundColor = ConsoleColor.Blue;
                                //Console.WriteLine("Enter Valid user ID : ");
                            }


                        }

                    }

                    if (MenuItems[SelectedItem].Title == "DISPLAY ALL USERS")
                    {
                        Console.Clear();

                        Console.WriteLine("\t\t\t\t" + "ID".PadRight(10) + "First Name".PadRight(15) + "Last Name".PadRight(15) + "Date of Birth".PadRight(20) + "GPA".PadRight(10));
                        Console.WriteLine(" \t\t\t\t" + "----------------------------------------------------------------");
                        
                        foreach (var student in students)
                        {
                            Console.WriteLine(" \t\t\t\t" + student.ID.ToString().PadRight(10) + student.FirstName.PadRight(15) + student.LastName.PadRight(15) + student.DateOfBirth.PadRight(20) );
                        }
                        
                        Console.Write("\nPress any key to return to the MAIN MANU ");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    //start
                    if (MenuItems[SelectedItem].Title == "DELETE USER")
                    {
                        Console.Clear();
                        Console.WriteLine("For the cofirmation");
                        Console.Write("Enter the User ID Again : ");
                        int userid = Convert.ToInt32(Console.ReadLine());

                        Student selectedUser = students.Find(u => u.ID == userid);
                        

                        if (selectedUser!=null)
                        {
                            Console.WriteLine("Is this the User(y/n)");
                            
                            char p = Convert.ToChar(Console.ReadLine());
                            if (p == 'y')
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
                    //end

                    if (MenuItems[SelectedItem].Title == "QUIT")
                    {
                        Console.Clear();

                        running = false;
                    }
                }
            }
        }
    }
            
}
