// See https://aka.ms/new-console-template for more information

using TZLDotNetTrainingBatch3.ConsoleApp;

Console.WriteLine("Hello, World!");  //output

//Console.ReadLine();// user  (input)  + enter 
//Console.ReadKey();//enter any key

//string name = "Mg Mg";

string fullName = "Mg Mg";

//int age = 20;

double height = 5.6;

decimal salary = 500000.00M;

//char grade = 'A';

bool isMarried = false;

string name2; // default value is null


int x; // default value is 0


bool isAdult; // default value is false

bool isEqual = false;

string number = "1";

int number2 = 1;

//int number3 = int.Parse(number); // Data type casting

int number3 = Convert.ToInt32(number); //       Use two ways ( convert.ToInt32() or int.Parse())
var result = number2 + number3;

string dob = "2000-10-20";


DateTime dateTime = Convert.ToDateTime(dob);

// not same sql datetime default and c# datetime default
//sql datetime default is 1900-01-01 00:00:00
//C# datetime default is 0001-01-01 00:00:00

string caseno = "A";
char a = 'A'; // single quote for char

if (caseno == "A")
{
    Console.WriteLine("Case A");
}
else if(caseno == "B")
{
    Console.WriteLine("Case B");
}
else if(caseno == "C")
{
    Console.WriteLine("Case C");
}
else
{
    Console.WriteLine("Invalid Case");
}
// Ternary Operator 
switch(caseno)
{
    case "A":
        Console.WriteLine("Case A");
        break;
    case "B":
        Console.WriteLine("Case B");
        break;
    case "C":
        Console.WriteLine("Case C");
        break;
    case "D":
        Console.WriteLine("Case D");
        break;
    default:
        Console.WriteLine("Invalid Case");
        break;
}

for (int i = 0; i <=10; i++)
{
    Console.WriteLine(i);

}

//foreach (var item in collection)
//{

//}

string[] fruits = new string[] { "Apple", "Orange", "Banana" };
foreach (var fruit in fruits)
{
    Console.WriteLine(fruit);
    
}

Month month = Month.January;
switch (month)
{
    case Month.January:
        Console.WriteLine("January");
        break;
    case Month.February:
        Console.WriteLine("February");
        break;
    case Month.March:
        Console.WriteLine("March");
        break;
    case Month.April:
        Console.WriteLine("April");
        break;
    case Month.May:
        Console.WriteLine("May");
        break;
    case Month.June:
        Console.WriteLine("June");
        break;
    default:
        Console.WriteLine("Invalid Month");
        break;
}

Run("Mg Mg", 20);
static void Run(string name, int age)
        {
        Console.WriteLine("Run");
        }
Student  student = new Student(1,"Thuzar", new DateTime(1996-4-11));
//student.studentNo = 1;
//student.studentName = "Mg Mg";
//student.fatherName = "U Soe";

//Student student1 = new Student();
//student1.studentNo = 2;
//student1.studentName = "Aung Aung";
//student1.fatherName = "U Kyaw";

//student1.studentName = "Hla Hla";    

Console.WriteLine(student.studentName);
//Console.WriteLine(student1.studentName);

Wallet wallet = new Wallet();
wallet.Name = "Mg Mg";  
wallet.MobileNo = "09789999999";
wallet.amount = 10000;

 
wallet.ShowBalance();
wallet.SetBalance(5000);




enum Month
{
    January = 1,
    February = 2,
    March = 3,
    April = 4,
    May = 5,
    June = 6

}

