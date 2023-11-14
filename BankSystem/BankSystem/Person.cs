public abstract class Person
{
    public readonly  string FirstName;
    public readonly string LastName;
    public abstract int Age { get; set; }
    public readonly string Email;   
    public readonly string PhoneNumber;

    protected int age;
    public decimal AccountBalance;
    public abstract decimal Salary { get; }

    private static int bankId = 0;
    public int BankId { get { return bankId; } init { } } 
     
    public Person(string name,string lastname,string email,string phonenumber,object featur)
    {
        ++bankId;
        FirstName = name;
        LastName = lastname;
        Email = email;   
        PhoneNumber = phonenumber;       
    }
    public Person()
    {
            
    }
}

