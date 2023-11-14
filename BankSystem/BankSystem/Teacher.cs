﻿public class Teacher : Person
{
    public Teacher(string name, string lastname, int age, string email, string phonenumber, object featur) : base(name, lastname, email, phonenumber, featur)
    {
        Age = age;
    }
    public override int Age 
    { 
        get { return age; } 
        set 
        {
            if(value>20)
                age = value;    
            else
                throw new Exception("You are not old enough to register");
        } 
    }
    public override decimal Salary => 120000;
}

