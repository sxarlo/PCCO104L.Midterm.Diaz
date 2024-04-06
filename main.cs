using System;
class Program {
    static void Main(string[] args) {
        int baseFanPower = 10;
        int fanSpeed = 0;
        char oscillateOption = '\0';

        while (true)
        {
            Console.Write("Enter fan speed (1, 2, or 3): ");
            if (int.TryParse(Console.ReadLine(), out fanSpeed) && (fanSpeed >= 1 && fanSpeed <= 3))
            {
                break;
            }
            else
            {
                Console.WriteLine("INVALID!!!");
            }
        }

        while (true)
        {
            Console.Write("Oscillate fan? (Y/N): ");
            string input = Console.ReadLine()?.ToUpper();
            if (!string.IsNullOrEmpty(input) && (input == "Y" || input == "N"))
            {
                oscillateOption = input[0];
                break;
            }
            else
            {
                Console.WriteLine("INVALID!.");
            }
        }

        int fanPowerOutput = baseFanPower * fanSpeed;

        if (oscillateOption == 'Y')
        {
            OscillateFan(fanSpeed, fanPowerOutput);
        }
        else
        {
            StaticFan(fanSpeed);
        }

        Console.ReadLine();
    }

    static void OscillateFan(int fanSpeed, int fanPowerOutput)
    {
        for (int i = fanSpeed; i <= fanPowerOutput && i <= fanSpeed * 10; i += fanSpeed)
        {
            Console.WriteLine($"{new string('~', i)}");
        }

        for (int i = fanPowerOutput - fanSpeed; i >= fanSpeed; i -= fanSpeed)
        {
            Console.WriteLine($"{new string('~', i)}");
        }
    }

    static void StaticFan(int fanSpeed)
    {
        int lines = fanSpeed + 10;
        int outputLength = fanSpeed * 10;
        for (int i = 0; i < lines; i++)
        {
            Console.WriteLine($"{new string('~', outputLength)}");
        }
    }
}
