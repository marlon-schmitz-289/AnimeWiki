namespace BaseClasses;

public class Generator
{
    private const string LOWERLETTERS = "abcdefghijklmnopqrstuvwxyz";
    private const string UPPERLETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string SYMBOLS = @"!§$%&/()=?{[]}\@+*~#,.-<>|";
    private const string NUMBERS = "0123456789";

    public static string GeneratePassword(
        int length = 12, bool lower = true,
        bool upper = true, bool symbols = true,
        bool numbers = true)
    {
        var rndm = new Random();
        var password = "";

        var choices = new List<char>();
        if (lower) choices.Add('l');
        if (upper) choices.Add('u');
        if (symbols) choices.Add('s');
        if (numbers) choices.Add('n');

        for (int i = 0; i < length; i++)
        {
            switch (choices[rndm.Next(0, choices.Count)])
            {
                case 'l':
                    password += LOWERLETTERS[rndm.Next(0, LOWERLETTERS.Length)];
                    break;
                case 'u':
                    password += UPPERLETTERS[rndm.Next(0, UPPERLETTERS.Length)];
                    break;
                case 's':
                    password += UPPERLETTERS[rndm.Next(0, SYMBOLS.Length)];
                    break;
                case 'n':
                    password += UPPERLETTERS[rndm.Next(0, NUMBERS.Length)];
                    break;
            }
        }
        
        return password;
    }
}