//using System.Runtime.CompilerServices;
bool temp;
string firstName, lastName, email, phoneNumber;
int age;
int input;
int id;
Person person;
Bank bankAll = new();
do
{
    Console.Clear();
    Console.WriteLine("Click 0,if you want to close the window.\nClick 1,if you want to create a new account.\nClick 2,if you want to see the account.\nClick 3,if you want to see the all account.");
    temp = false;
    Console.Write("Input number -> ");
    int clickNumber = int.Parse(Console.ReadLine());

    switch (clickNumber)
    {
        case 0:
            Console.ReadKey();
            break;

        case 1:
            CreatePerson(out input, out person);
            Bank bank = new Bank(person);          
            break;

        case 2:
            Console.Clear();
            Console.WriteLine(  "Serech person!");
            Console.Write("First name   : ");
            firstName = Console.ReadLine();
            Console.Write("Last name    : ");
            lastName = Console.ReadLine();
            Console.Write("Id   : ");
            id=int.Parse(Console.ReadLine());
            Console.Clear();
            bankAll.SelectPersonAccount(firstName,lastName,id);
            Console.WriteLine("------------------------------------");
            Console.Write("Click 1,if you want to add money.\nClick 2,if you want to take money.\nInput number -> ");
            int number=int.Parse(Console.ReadLine());
            decimal money;
            person = bankAll.Select(firstName, lastName, id);
            if (number == 1)
            {
                Console.Write("The amount of money : ");
                money= decimal.Parse(Console.ReadLine());
                bankAll.AddAccontBalance(money); 
            }
            else
            {
                Console.Write("The amount of money : ");
                money = decimal.Parse(Console.ReadLine());
                bankAll.ReduceAccountBalance(money); 
            }          
            Console.WriteLine( $"Now your account balance is : { person.AccountBalance}");
            break;

        case 3:
            Console.Clear();
            bankAll.SelectAllPersonaccount();
            break;

        default:
            temp = true;
            Console.WriteLine("You entered the wrong number,please try again!");
            break;
    }
    if (clickNumber > 0 && clickNumber<4)
    {
        Console.Write("----------------------\nClick 0,if you want anything else․\nInput number -> ");
        input = int.Parse(Console.ReadLine());

        if (input == 0)
            temp = true;      
    }
    
} while (temp);
 void CreateData(out string firstName, out string lastName, out string email, out string phoneNumber, out int age,string personType)
{
    Console.Clear();
    Console.WriteLine($"Registration {personType}\n-----------------------");
    Console.Write("First name   : ");
    firstName = Console.ReadLine();
    Console.Write("Last name    : ");
    lastName = Console.ReadLine();
    Console.Write("Email        : ");
    email = Console.ReadLine();
    Console.Write("Phone number : ");
    phoneNumber = Console.ReadLine();
    Console.Write("Age          : ");
    age = int.Parse(Console.ReadLine());
}
 void CreatePerson(out int input, out Person person) 
{
    Console.Clear();
    Console.Write("Click 1,if you are a student.\nClick 2,if you are a teacher.\nClick 3,if you are an emploee.\nInput number -> ");
    input = int.Parse(Console.ReadLine());
    switch (input)
    {
       
        case 1:          
            CreateData(out firstName, out lastName, out email, out phoneNumber, out age, "Student account!");
            person = new Student(firstName, lastName, age, email, phoneNumber, "null");
            break;

        case 2:
            CreateData(out firstName, out lastName, out email, out phoneNumber, out age, "Teacher account!");
            person = new Teacher(firstName, lastName, age, email, phoneNumber, "null");
            break;

        case 3:
            CreateData(out firstName, out lastName, out email, out phoneNumber, out age, "Employee account!");
            person = new Employee(firstName, lastName, age, email, phoneNumber, "null");
            break;

        default:
           Console.WriteLine("You entered the wrong number,please try again!");
            CreatePerson(out input,out person);
            break;

    }
}