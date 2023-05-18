namespace Sauna;

public static class Sauna
{
    private static void Main()
    {
        // Initialize celsiusTemp to 0.0 so it's not uninitialized when we first use it
        var celsiusTemp = 0.0;
        do
        {
            int fahrenheitTemp;

            // Keep asking the user for input until they enter a valid integer
            while (true)
            {
                Console.Write("Enter a temperature in Fahrenheit (\u00B0F): ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out fahrenheitTemp)) break;

                // If the user doesn't enter a valid integer, display an error message and ask again
                Console.WriteLine("Error: You must enter a valid integer!");
            }

            try
            {
                // Convert the Fahrenheit temperature to Celsius using the ConvertFahrToCel method
                celsiusTemp = ConvertFahrToCel(fahrenheitTemp);

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
                Console.WriteLine($"Current temperature in celsius: {celsiusTemp}\u00B0C");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // If the temperature is outside the valid range, display the error message from the exception
                Console.WriteLine(ex.Message);
            }
        } while (celsiusTemp is < 73 or > 77);
    }

    // This method converts a Fahrenheit temperature to Celsius
    private static double ConvertFahrToCel(int fahrenheit)
    {
        var celsius = (fahrenheit - 32) * 5.0 / 9.0;
        return Math.Round(celsius, 2);
    }
}