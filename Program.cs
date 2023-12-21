using Bank;

Test1();

void Test1() {
try
{
    var account = new Account("   Jo   ", 100.0m);
    Console.WriteLine(account);
}
catch (ArgumentException)
{
    Console.WriteLine("Name is to short");
}
}