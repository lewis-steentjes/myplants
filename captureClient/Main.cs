// See https://aka.ms/new-console-template for more information

using PostgrestExample.models;

public class Application
{
    static async Task Main()
    {
        Console.WriteLine("Reading SupaBase credentials...");
        string SUPABASE_URL = ReadSecret("SUPABASE_URL", "userSecrets.env");
        string SUPABASE_KEY = ReadSecret("SUPABASE_KEY", "userSecrets.env");
        // Console.WriteLine(SUPABASE_URL);
        // Console.WriteLine(SUPABASE_KEY);
        var options = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = true
        };
        var supabase = new Supabase.Client(SUPABASE_URL, SUPABASE_KEY, options);
        Console.WriteLine("initializing supabase...");
        await supabase.InitializeAsync();
        Console.WriteLine("Supabase initialized!");
        var result = await supabase.From<User>().Get();
        var users = result.Models;
        Console.WriteLine(users);

    }

    static string ReadSecret(string variableName, string fileName)
    {
        try
        {
            // Open the text file using a stream reader.
            using StreamReader reader = new("userSecrets.env");

            // Read the stream as a string.
            string[] lines = reader.ReadToEnd().Trim().Split("\n");
            foreach (string line in lines)
            {
                string[] lineInfo = ParseLine(line);
                if (lineInfo[0] == variableName) return lineInfo[1];
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        return "";
    }

    static string[] ParseLine(string line)
    {
        // Takes input string, eg "SUPABASE_URL='https://www.supabase.com/' and returns two strings ["SUPABASE_URL", "https://www.supabase.com/"]
        int variableStart = line.IndexOf("\"");
        int variableEnd = line.Substring(variableStart + 1).IndexOf("\"");
        string variableValue = line.Substring(variableStart + 1, variableEnd);
        string[] splitLine = line.Split("=");
        if (splitLine.Length < 1)
        {
            Console.WriteLine("Unable to seperate variable name from value");
            return ["", ""];
        }
        string variableName = line.Split("=")[0].Trim();
        return [variableName, variableValue];
    }
}
