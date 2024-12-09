using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StoreStudentData;

namespace ClassApp
{
   abstract class School
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual void AddData()
        {
            while (true)
            {

                Console.WriteLine("Enter Name:");
                Name = Console.ReadLine();
                if (Regex.IsMatch(Name, @"^[a-zA-Z\s]+$") && Name.Length >= 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid name format! Only letters and spaces are allowed and name should be contain atleast 3 or above char.");
                }
            }

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z]+\.[a-zA-Z]{2,}$";
            while (true)
            {

                Console.WriteLine("Enter Email Address:");
                Email = Console.ReadLine();
                if (Regex.IsMatch(Email, emailPattern))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid email format! Please enter a valid email address.");
                }
            }
        }
        public abstract void show();
    }
    class Students : School
        {

            public override void AddData()
            {
                base.AddData();
            }

        public override void show()
        {
            Console.WriteLine($"\nStudent ID : {ID}\nStudent Name : {Name}\nStudent Email : {Email}\n");
        }

        public static void finddata()
            {
            while (true)
            {


                Console.WriteLine("Enter ID");
                int stdid = Convert.ToInt32(Console.ReadLine());

                var data = StoreStudentData.Program.StudentDetails.Find(a => a.ID == stdid);
                if (StoreStudentData.Program.StudentDetails.Contains(data))
                {

                    bool isname = false;
                    while (!isname)
                    {

                        Console.WriteLine("Enter Name:");
                        data.Name = Console.ReadLine();
                        if (Regex.IsMatch(data.Name, @"^[a-zA-Z\s]+$") && data.Name.Length >= 3)
                        {
                            isname = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid name format! Only letters and spaces are allowed and name should be contain atleast 3 or above char.");
                        }
                    }

                    string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z]+\.[a-zA-Z]{2,}$";
                    bool isemail = false;
                    while (!isemail)
                    {

                        Console.WriteLine("Enter Email Address:");
                        data.Email = Console.ReadLine();
                        if (Regex.IsMatch(data.Email, emailPattern))
                        {
                            isemail = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid email format! Please enter a valid email address.\n");
                        }
                    }
                    Console.WriteLine("\nData updated Successfully\n");
                    break;
                }
                else
                {
                    Console.WriteLine("please enter a valid Id\n");
                   // continue;
                }
            }
        }
    }
   
    class Teachers : School
    {

        public override void AddData()
        {
            base.AddData();
        }

        public override void show()
        {
            ///   throw new NotImplementedException();
            Console.WriteLine($"Teacher ID : {ID}\nTeacher Name : {Name}\nTeacher Email : {Email}\n");
        }


        public static void finddata()
        {
            while (true)
            {


                Console.WriteLine("Enter ID");
                int techid = Convert.ToInt32(Console.ReadLine());

                var data = StoreStudentData.Program.TeacherDetails.Find(a => a.ID == techid);
                if (StoreStudentData.Program.TeacherDetails.Contains(data))
                {

                    bool isname = false;
                    while (!isname)
                    {

                        Console.WriteLine("Enter Name:");
                        data.Name = Console.ReadLine();
                        if (Regex.IsMatch(data.Name, @"^[a-zA-Z\s]+$") && data.Name.Length >= 3)
                        {
                            isname = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid name format! Only letters and spaces are allowed and name should be contain atleast 3 or above char.");
                        }
                    }

                    string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z]+\.[a-zA-Z]{2,}$";
                    bool isemail = false;
                    while (!isemail)
                    {

                        Console.WriteLine("Enter Email Address:");
                        data.Email = Console.ReadLine();
                        if (Regex.IsMatch(data.Email, emailPattern))
                        {
                            isemail = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid email format! Please enter a valid email address.\n");
                        }
                    }
                    Console.WriteLine("\nData updated Successfully\n");
                    break;
                }
                else
                {
                    Console.WriteLine("please enter a valid Id\n");
                    // continue;
                }
            }
        }

    } // teacher class
}
