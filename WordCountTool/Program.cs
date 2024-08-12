namespace WordCountTool;
public class Program {
    static void Main(string[] args) {
        try {
            if (Console.IsInputRedirected) {
                ProcessStandardInput(args);
                return;
            }

            if (args.Length == 0) {
                PrintUsage();
                return;
            }

            if (args.Length >= 2) {
                string option = args[0];
                string filePath = args[1];

                if (!CheckFileExists(filePath)) return;
                ProcessFile(option, filePath);
            } else {
                string filePath = args[0];

                if (!CheckFileExists(filePath)) return;
                DefaultProcess(filePath);
            }
        } catch (Exception ex) {
            Console.WriteLine($"An error occurred: {ex.Message}");
            PrintUsage();
        }
    }

    private static void ProcessStandardInput(string[] args) {
        string option = (args.Length == 1) ? args[0] : null;
        string tempFilePath = Path.GetTempFileName();

        try {
            using (TextReader reader = Console.In)
            using (var writer = new StreamWriter(tempFilePath)) {
                writer.Write(reader.ReadToEnd());
            }

            ProcessFile(option, tempFilePath, true);
        } catch (Exception ex) {
            Console.WriteLine($"An error occurred: {ex.Message}");
        } finally {
            if (File.Exists(tempFilePath)) File.Delete(tempFilePath);
        }
    }


    static void ProcessFile(string option, string filePath, bool isStandardInput = false) {
        var displayFile = !isStandardInput ? filePath : string.Empty;
        switch (option) {
            case "-c":
                Console.WriteLine($"\t{FileProcessor.GetByteCount(filePath)} {displayFile}");
                break;
            case "-l":
                Console.WriteLine($"\t{FileProcessor.GetLineCount(filePath)} {displayFile}");
                break;
            case "-w":
                Console.WriteLine($"\t{FileProcessor.GetWordCount(filePath)} {displayFile}");
                break;
            case "-m":
                Console.WriteLine($"\t{FileProcessor.GetCharCount(filePath)} {displayFile}");
                break;
            case null:
                DefaultProcess(filePath, isStandardInput);
                break;
            default:
                Console.WriteLine($"Unknown option: {option}");
                if (isStandardInput) File.Delete(filePath);
                PrintUsage();
                return;
        }
    }

    static void DefaultProcess(string filePath, bool isStandardInput = false) =>
        Console.WriteLine($"\t{FileProcessor.GetByteCount(filePath)}  {FileProcessor.GetLineCount(filePath)}  {FileProcessor.GetWordCount(filePath)} {(!isStandardInput ? filePath : string.Empty)}");

    static void PrintUsage() {
        Console.WriteLine("Usage: ccwc [<file-path>] [-c <file-path>] [-l <file-path>] [-w <file-path>] [-m <file-path>]");
        Console.WriteLine("\nExamples:");
        Console.WriteLine("  ccwc <file-path>     # Outputs the number of bytes, lines, and words in the file");
        Console.WriteLine("  ccwc -c <file-path>  # Outputs the number of bytes in the file");
        Console.WriteLine("  ccwc -l <file-path>  # Outputs the number of lines in the file");
        Console.WriteLine("  ccwc -w <file-path>  # Outputs the number of words in the file");
        Console.WriteLine("  ccwc -m <file-path>  # Outputs the number of chars in the file");
        Console.WriteLine("\ncat <file-path> | ccwc <option>  # Outputs the option taken from standard input");
    }

    static bool CheckFileExists(string filePath) {
        if (!File.Exists(filePath)) {
            Console.WriteLine($"Error: File not found: {filePath}");
            return false;
        }

        return true;
    }
}