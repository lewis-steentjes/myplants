// See https://aka.ms/new-console-template for more information
using PostgrestExample.models;


// uploadPlantData --id 8 --recorded_at? time --image_frame? 8 --video_location? str --hydration? num --light? num --temperature? num --humidity? num
public class Application
{
    static async Task<int> Main(string[] args)
    {
        var parsedData = ParseArgs(args);
        Console.WriteLine(parsedData);
        string SUPABASE_URL = ReadSecret("SUPABASE_URL", "userSecrets.env");
        string SUPABASE_KEY = ReadSecret("SUPABASE_KEY", "userSecrets.env");
        var options = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = true
        };
        var supabase = new Supabase.Client(SUPABASE_URL, SUPABASE_KEY, options);
        Console.WriteLine("initializing supabase...");
        await supabase.InitializeAsync();
        Console.WriteLine("Supabase initialized!");
        Console.WriteLine("Uploading Data Entry...");
        await supabase.From<PlantData>().Insert(parsedData);
        Console.WriteLine("Upload Completed.");
        return 1;
    }

    static PlantData ParseArgs(string[] args)
    {
        var result = new PlantData();
        bool problemsOccurred = false;

        // uploadPlantData --id 8 --recorded_at? time --image_frame? 8 --video_location? str --hydration? num --light? num --temperature? num --humidity? num
        for (int i = 0; i < (args.Length - 1); i++)
        {
            string arg = args[i];
            bool isOption = false;
            if (arg.Length >= 3)
            {
                isOption = (arg.Substring(0, 2) == "--");
            }
            if (isOption)
            {
                // Console.WriteLine($"{arg.Substring(2)}: {args[i + 1]}");
                arg = arg.Substring(2);
                string argValue = args[i + 1];
                int value;
                switch (arg)
                {

                    // --id 8 --recorded_at? time --image_frame? 8 --video_location? str --hydration? num --light? num --temperature? num --humidity? num
                    case ("plant_id"):
                        problemsOccurred = !Int32.TryParse(argValue, out value);
                        result.PlantId = value;
                        break;
                    case ("recorded_at"):
                        result.RecordedAt = System.DateTime.Now;
                        break;
                    case ("image_frame"):
                        Int32.TryParse(argValue, out value);
                        result.ImageFrame = value;
                        break;
                    case ("video_location"):
                        result.VideoFile = argValue;
                        break;
                    case ("hydration"):
                        Int32.TryParse(argValue, out value);
                        result.HydrationLevel = value;
                        break;
                    case ("light"):
                        Int32.TryParse(argValue, out value);
                        result.LightLevel = value;
                        break;
                    case ("temperature"):
                        Int32.TryParse(argValue, out value);
                        result.TemperatureReading = value;
                        break;
                    case ("humidity"):
                        Int32.TryParse(argValue, out value);
                        result.HumidityReading = value;
                        break;
                    default:
                        break;
                }
            }
        }
        // Error handling. Forget about it!
        if (result.PlantId == -1)
        {
            throw new Exception("error. missing plant ID in data entry");
        }
        if (result.ImageFrame == -1 ^ result.VideoFile == "")
        {
            throw new Exception("error. video file was listed without corresponding image frame");
        }
        return result;
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
