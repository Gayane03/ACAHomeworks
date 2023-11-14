using EnumerableFunctions;
using System.Collections;

var collection = new List<Person>()
{
    new Person{ Name="Gayane" ,Age=20 },
    new Person{ Name="Gayane" ,Age=18 },
      new Person{ Name="Anahit" ,Age=18, },
      new Person { Name="Gevorg",Age=35},
      new Person { Name = "Anan", Age = 30 }
  
};
var a=collection.Select(x => x.Name).ToList();

collection.Add(new Person { Name="Hakob",Age=10});
 foreach (var item in a)
{
    Console.WriteLine( item);
}
                

//var answer = collection.OrderBy();
//foreach (var item in answer)
//{
//    Console.WriteLine(item.Name);
//}
//var answerGroupby = collection.MyGroupBy(coll => coll.Age);
//foreach (var item in answerGroupby)
//{
//    Console.Write("Key " + item.Key + "\n");
//    foreach (var item2 in item)
//    {
//        Console.WriteLine(item2.Name);
//    }
//    Console.WriteLine();
//}
//var answerWhereOverload1=collection.MyWhere(x => x.Age > 19).ToList();
//var answerWhereOverload2= collection.MyWhere((x,i) => x.Age > 19 && i%2==0).ToList();
//foreach (var item in answerWhereOverload2)
//{
//    Console.WriteLine(item.Name);
//}
//var comparer = Comparer<int>.Create((x, y) => x.CompareTo(y));
//var answerOrderedBy2 = collection.OrderBy(person => person.Age, comparer);
//var resultOrderBy=collection.MyOrderBy(x => x.Age);   
//foreach (var item in answerOrderedBy2)
//{
//    Console.WriteLine("Name : "+item.Name+" Age : "+item.Age);
//}
//IList list = new ArrayList();

//list.Add(new Person { Name = "Gayane", Age = 20 });
//list.Add(new Person { Name = "Anan", Age = 30 });
//list.Add("Anna");
//list.Add(15);
//list.Add("Hakob");
//list.Add(22);

//var answerOfType = list.MyOfType<string>();

//foreach (var item in answerOfType)
//{
//    Console.WriteLine(item);
//}


class Person
{
  
    public string Name;
    public int Age;
    public Person()
    {
            
    }
}
