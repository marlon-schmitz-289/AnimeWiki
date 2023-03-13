using BaseClasses;

namespace PasswordGenerator;

public static class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                bool lower = false,
                    upper = false,
                    symbols = false,
                    numbers = false;

                var length = 0;

                var input = Console.ReadLine();

                if (input is not null && (input.Equals("Close") || input.Equals("close")))
                {
                    return;
                }

                length = int.Parse(input ?? "0");

                lower = CheckInput(Console.ReadLine());
                upper = CheckInput(Console.ReadLine());
                symbols = CheckInput(Console.ReadLine());
                numbers = CheckInput(Console.ReadLine());

                switch (length)
                {
                    case > 20:
                        throw new Exception("Die Zahl ist zu groß!");
                    case < 8:
                        throw new Exception("Die Zahl ist zu klein!");
                }

                Console.WriteLine(Generator.GeneratePassword(length, lower, upper, symbols, numbers));
                Console.ReadKey(true);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Ein Fehler ist aufgetreten:");
                Console.WriteLine("Bei der Eingabe muss es sich um eine Zahl handeln!");
                Console.ReadKey(true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ein Fehler ist aufgetreten:");
                Console.WriteLine(e.Message);
                Console.ReadKey(true);
            }
        }
    }


    private static bool CheckInput(string? input)
    {
        return input is not null && (input.ToLower().Equals("ja") || input.ToLower().Equals("j")
                                                                  || input.ToLower().Equals("yes")
                                                                  || input.ToLower().Equals("y"));
    }
}