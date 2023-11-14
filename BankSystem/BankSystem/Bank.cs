public class Bank:IComparable
{
    private static Dictionary<int, Person> peopleAccount = new Dictionary<int, Person>();
    private Person person;
    private bool exist;
    private int BankId;

    public Bank(Person person)
    {
        this.person = person;
        this.BankId = person.BankId;
        AddPersonAccount();
    }
    public Bank()
    {

    }

    public void AddAccontBalance(decimal money)
    {
        person.AccountBalance += money;
    }
    public void ReduceAccountBalance(decimal money)
    {
        person.AccountBalance -= money;
    }
    private void AddSalary()
    {
        person.AccountBalance += person.Salary;
    }

    private void ReduceWages()
    {
        person.AccountBalance -= person.Salary;
    }

    
    private void AddPersonAccount()
    {
        exist = false;
        foreach (var user in peopleAccount)
        {
            if (user.Value == person)// && person.Bank.BankId == user.Key)
            {
                exist = true;
                break;
            }
        }
        if (exist)
            Console.WriteLine("Such an account exists!");
        else
        {
            peopleAccount.Add(BankId, person);
            Console.WriteLine("Thank you, the transaction was successful!");
        }
    }
    public void SelectPersonAccount(string firstname, string lastname, int id)
    {
        exist = false;
        foreach (var user in peopleAccount)
        {
            if (user.Value.FirstName == firstname && user.Value.LastName == lastname && user.Key == id)// && person.Bank.BankId == user.Key)
            {
                person = user.Value;
                personData(firstname, lastname, user.Value.Email, user.Value.PhoneNumber, user.Value.Age,user.Value.AccountBalance);
                return;
            }
        }
        Console.WriteLine("No such account exists!");
    }
    public Person Select(string firstname, string lastname, int id)
    {
        exist = false;
        foreach (var user in peopleAccount)
        {
            if (user.Value.FirstName == firstname && user.Value.LastName == lastname && user.Key == id)
            {
                return user.Value;
            }
        }
        person = new Student();
        return person;
        //Console.WriteLine("No such account exists!");
    }
    public void SelectAllPersonaccount()
    {
        foreach (var user in peopleAccount)
        {
            personData(user.Value.FirstName, user.Value.LastName, user.Value.Email, user.Value.PhoneNumber, user.Value.Age,user.Value.AccountBalance);
            Console.WriteLine("\n-----------------------------");
        }

    }
    private void personData(string firstname, string lastname, string email, string phonenumber, int age,decimal accountbalance)
    {
        Console.WriteLine("Person data!\n-------------------------");
        Console.WriteLine($"First name      :{firstname} ");
        Console.WriteLine($"Last name       :{lastname} ");
        Console.WriteLine($"Email           :{email} ");
        Console.WriteLine($"Phone number    :{phonenumber} ");
        Console.WriteLine($"Age             :{age} ");
        Console.WriteLine($"Account balance :{accountbalance}");
    }

    public int CompareTo(object? obj)
    {
        Bank? bank = obj as Bank;
        if(bank is null || this.person.AccountBalance > bank.person.AccountBalance)
        {
            return 1;
        }
        else if(this.person.AccountBalance < bank.person.AccountBalance)
        {
            return -1;
        }
        return 0;
    }
}

