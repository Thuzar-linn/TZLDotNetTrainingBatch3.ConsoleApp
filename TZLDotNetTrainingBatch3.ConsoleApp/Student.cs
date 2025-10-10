using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TZLDotNetTrainingBatch3.ConsoleApp
{
    internal class Student
    {   //fields
        public int studentNo;
        public string studentName;
        public string fatherName;

        private string name; // fields

        public string Name // property
        {
            get { return name; }
            set { name = value; }
        }

        //public Student() // default constructor
        //{
        //    studentName = "empty";
        //}

        public Student(int studentNo, string studentName,DateTime dateOfBirth)
        {

        }
        public int StudentNo { get; set; } // auto-implemented property 
        public string StudentName { get; set; } 
        public string FatherName { get; set; }  
        public DateTime DateOfBirth { get; set; }


    }

    public class Wallet
    {
        public decimal amount;
        public string Name { get; set; }    
        public string MobileNo { get; set; }    
        public decimal Balance { get; set; }
        public decimal ShowBalance()
        {
            return Balance;
        }   
        
    public void SetBalance(decimal amount)
        {
            if (amount < 0)
            {
                throw new Exception(" Amount is greater than 0");
            }
            Balance = amount;
        }
    }

}
