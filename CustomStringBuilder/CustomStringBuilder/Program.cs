using System.Text;
CustomStringBuilder obj = new CustomStringBuilder();
obj.Append("aaabbbccc");
Console.WriteLine(obj.ToString() + "  - Result ovveride ToString");

//obj.RemoveWhitespaces();
//string t = obj.ToString();
//Console.WriteLine(t + "  - Result method RemoveWhitespaces");

Console.WriteLine(obj.Length + "  - Result method Lenght");



obj.InsertAt("kk", 1);
string t = obj.ToString();
Console.WriteLine(t + "   - Result method InsertAt");


obj.RemoveDuplicates();
t = obj.ToString();
Console.WriteLine(t + "  -  Result method RemoveDuplicates");


bool blanck = obj.IsBlank();
Console.WriteLine(blanck + "   -  Result method IsBlack");

t = obj.Onblank();
Console.WriteLine(t + "   -  Result method OnBlack");
