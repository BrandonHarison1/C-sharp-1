using TestApp;

var VerifyEmail = new VerifyEmail();
string email;
List<string> emails = new List<string>();

do
{
    Console.WriteLine("\nPlease enter your email");
    email = Console.ReadLine();

    if (!email.Equals("quit"))
    {
        emails.Add(email);
        Console.WriteLine(VerifyEmail.IsEmailValid(email));
    }

} while (!email.Equals("quit"));

Console.WriteLine("Email List:");
foreach (string mail in emails)
{
    Console.WriteLine($"{mail}");
}


