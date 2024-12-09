using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using ClassApp;

namespace StoreStudentData
{
    class Program
    {
        public static List<School> StudentDetails = new List<School>();
        public static List<School> TeacherDetails = new List<School>();
        static int StudentID = 1001;
        static int TeacherID = 1001;
        public static bool iscontinue ;
        public static bool isRunning = true ;




        static void Main()
        {
            string prompt = "Press 1 to Add Student\n" +
                            "Press 2 to Retrieve Student Data\n" +
                            "Press 3 to Add Teacher\n" +
                            "Press 4 to Retrieve Teacher Data\n" +
                            "Press 5 to Retrieve Both\n" +
                            "Press 6 to Edit Data\n" +
                            "Press 7 to Remove Data\n" +
                            "Press 8 to Exit the Program\n";

            while (isRunning)
            {
                try
                {
                    Console.WriteLine(prompt);
                    int userinput = Convert.ToInt32(Console.ReadLine());

                    switch (userinput)
                    {
                        case 1: // Add Student
                            iscontinue = false;
                            while (!iscontinue)
                            {
                                // Create a new instance for each student
                                School s = new Students
                                {
                                    ID = StudentID
                                };
                                s.AddData();

                                Console.WriteLine("Do you want to add this Data to the list? y/n");
                                string add = Console.ReadLine();
                                if (add.ToLower() == "y")
                                {
                                    StudentDetails.Add(s);
                                    StudentID++;
                                    Program.DataAddLogic();
                                }
                                else if (add.ToLower() == "n")
                                {
                                    Console.WriteLine("Student not added. Returning to the main menu\n");
                                    iscontinue = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input!");
                                    iscontinue = true;
                                }
                            }
                            break;

                        case 2: // Show Student Data
                            if (StudentDetails.Count == 0)
                            {
                                Console.WriteLine("No student data available. Please add some data.");
                            }
                            else
                            {
                               
                                foreach (var item in StudentDetails)
                                {
                                    item.show();
                                }


                            }
                            break;

                        case 3: // Add Teacher
                            iscontinue = false;
                            while (!iscontinue)
                            {
                                // Create a new instance for each teacher
                                School s = new Teachers
                                {
                                    ID = TeacherID
                                }; 
                                s.AddData();

                                Console.WriteLine("Do you want to add this Data to the list? y/n");
                                string addTeacher = Console.ReadLine();
                                if (addTeacher.ToLower() == "y")
                                {
                                    TeacherDetails.Add(s);
                                    TeacherID++;
                                    Program.DataAddLogic();
                                }
                                else if (addTeacher.ToLower() == "n")
                                {
                                    Console.WriteLine("Teacher not added. Returning to the main menu\n");
                                    iscontinue = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input!");
                                    iscontinue = true;
                                }
                            }
                            break;

                        case 4: // Show Teacher Data
                            if (TeacherDetails.Count == 0)
                            {
                                Console.WriteLine("No teacher data available. Please add some data.");
                            }
                            else
                            {
                                foreach (var item in TeacherDetails)
                                {
                                    item.show();
                                }
                            }
                            break;

                        case 5: // Show Both
                            ShowBoth();
                            break;

                        case 6:
                            Program.EditData();
                            break;

                        case 7:
                            Program.DeleteData();
                            break;

                        case 8: // Exit Program
                            isRunning = false;
                            Console.WriteLine("Exiting the program...");
                            break;

                        default:
                            Console.WriteLine("Invalid selection! Please choose a valid option.");
                            break;
                    } // switch
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: Invalid input. Please enter a valid number.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        } // while loop end
         


        static void DataAddLogic()
        {
            Console.WriteLine("Successfully Added. Do you want to continue adding data? y/n");
            string ask = Console.ReadLine();

            if (ask.ToLower() == "y")
            {
                iscontinue = false; // Continue adding
            }
            else if (ask.ToLower() == "n")
            {
                iscontinue = true; // Exit loop
            }
            else
            {
                Console.WriteLine("Invalid input! Returning to the main menu.");
                iscontinue = true;
            }
        }

        static void ShowBoth()
        {
            if (StudentDetails.Count == 0 && TeacherDetails.Count == 0)
            {
                Console.WriteLine("No data available. Please add student and teacher data.");
            }
            else if (StudentDetails.Count == 0)
            {
                Console.WriteLine("Teacher Data:\n");
                
                foreach (var item in TeacherDetails)
                {
                    item.show();
                }

                Console.WriteLine("\nNo student data available.\n");
            }
            else if (TeacherDetails.Count == 0)
            {
                Console.WriteLine("Student Data:\n");
              
                foreach (var item in StudentDetails)
                {
                    item.show();
                }

                Console.WriteLine("\nNo teacher data available.\n");
            }
            else
            {
                Console.WriteLine("Teacher Data:\n");
                foreach (var item in TeacherDetails)
                {
                    item.show();
                }
                Console.WriteLine("Student Data:\n");
               
                foreach (var item in StudentDetails)
                {
                    item.show();
                }

            }
        }// show both method
        static void EditData()
        {
            Console.WriteLine("Which Data Do You Want to Edit Student or Teacher?\n" +
                                "Press s for Student\n" +
                                "Press t for Teacher\n");
            string edit = Console.ReadLine();
            switch (edit.ToLower())
            {

                case "s":
                    Students.finddata();
                        break;

                case "t":
                   Teachers.finddata();

                    break;

                default:
                    Console.WriteLine("Invalid Input! Enter a Valid Input\n");
                    break;
            }
        } // Edit Data
        static void DeleteData()
        {
            Console.WriteLine("Which Data Do You Want to Edit Student or Teacher?\n" +
                                "Press s for Student\n" +
                                "Press t for Teacher\n");
            string delete = Console.ReadLine();
            switch (delete.ToLower())
            {
                case "s":
                    Console.WriteLine("Enter Student ID");
                    int stdid = Convert.ToInt32(Console.ReadLine());

                    var data = StudentDetails.Find(a => a.ID == stdid);
                    StudentDetails.Remove(data);
                    Console.WriteLine("Data Removed Successfully!");

                    break;

                case "t":
                    Console.WriteLine("Enter Teacher ID");
                    int teachid = Convert.ToInt32(Console.ReadLine());

                    var techdata = TeacherDetails.Find(a => a.ID == teachid);
                    TeacherDetails.Remove(techdata);
                    Console.WriteLine("Data Removed Successfully!");

                    break;

                default:
                    Console.WriteLine("Invalid Input! Enter a Valid Input\n");
                    break;

            } // Delete Data
        }
    } // program class
} // namespace

