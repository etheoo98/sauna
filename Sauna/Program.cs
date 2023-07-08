namespace Sauna;

public static class Sauna
{
    private static void Main()
    {
        double celsiusTemp;

        do
        {
            int fahrenheitTemp;

            // Keep asking the user for input until they enter a valid integer
            while (true)
            {
                Console.Write("Enter a temperature in Fahrenheit (\u00B0F): ");

                if (int.TryParse(Console.ReadLine(), out fahrenheitTemp)) break;

                // If the user doesn't enter a valid integer, display an error message and ask again
                Console.WriteLine("Error: You must enter a valid integer!");
            }

            Console.Clear();

            celsiusTemp = fahrenheitTemp != 0
                ? ConvertFahrToCel(fahrenheitTemp) // Convert the Fahrenheit temperature to Celsius
                : ConvertFahrToCel(); // Generate a random Fahrenheit temperature and convert it to Celsius

            // Determine the appropriate message to display based on the Celsius temperature
            switch (celsiusTemp)
            {
                case 75:
                    Console.WriteLine("This temperature is pleasant for everyone.");
                    break;
                case > 73 and < 77:
                    Console.WriteLine("This temperature is not optimal, but it will do.");
                    break;
                case < 73:
                    Console.WriteLine("It's not warm enough.");
                    break;
                case > 77:
                    Console.WriteLine("It's way too hot!");
                    break;
            }

            // Display the current temperature in Celsius (Optional)
            // Console.WriteLine($"Current temperature in celsius: {celsiusTemp}\u00B0C");
        } while (celsiusTemp is < 73 or > 77);

        Console.Write("\nThe program will now exit...");
    }

    // This method generates a random Fahrenheit temperature and converts it to Celsius
    private static double ConvertFahrToCel()
    {
        var random = new Random();
        var fahrenheit = random.Next(130, 190);
        return ConvertFahrToCel(fahrenheit);
    }

    // This method converts a Fahrenheit temperature to Celsius
    private static double ConvertFahrToCel(int fahrenheit)
    {
        var celsius = (fahrenheit - 32) * 5.0 / 9.0;
        return Math.Round(celsius, 1);
    }
}