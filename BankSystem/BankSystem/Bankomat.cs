public class Bankomat
{
    private static Bank bank=new();
    private Person person;
    public Bankomat(string firstname,string lastname,int id)
    {
        person=bank.Select(firstname,lastname,id);       
    }
    public void SeeAccountBalance() => Console.WriteLine(person.AccountBalance);
    public void AddAccontBalance(decimal money)
    {
        person.AccountBalance += money;
    }
    public void ReduceAccountBalance(decimal money)
    {
        person.AccountBalance -= money;
    }
}

