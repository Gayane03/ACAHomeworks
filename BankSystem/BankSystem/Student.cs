
    public class Student:Person
    {
    
    private  double averageScore;
    public Student():base()
    {
            
    }
    public Student(string name, string lastname, int age, string email, string phonenumber, object featur) : base( name,  lastname,    email,  phonenumber,  featur)
    {
        Age = age;
       // averageScore = (double)feature; 
    }


    public override int Age
    {
        get
        { return age; }
        set
        {
            if (value > 14)
                age = value;
            else
                throw new Exception("You are not old enough to register");

        }
    }

    public override decimal Salary => 5000;
}

