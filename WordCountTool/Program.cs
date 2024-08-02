namespace WordCountTool;
public class Program {
    static void Main(string[] args) {
        if (args.Length == 0) {
            PrintUsage();
            return;
        }

        if (args.Length == 1) {
            string filePath = args[0];
            if (!CheckFileExists(filePath)) return;
            Console.WriteLine($"\t{FileProcessor.GetByteCount(filePath)}  {FileProcessor.GetLineCount(filePath)}  {FileProcessor.GetWordCount(filePath)} {filePath}");
            return;
        }

        for (int i = 0; i < args.Length; i += 2) {
            string option = args[i];
            string filePath = args[i + 1];

            if (!CheckFileExists(filePath)) continue;

            switch (option) {
                case "-c":
                    Console.WriteLine($"\t{FileProcessor.GetByteCount(filePath)} {filePath}");
                    break;
                case "-l":
                    Console.WriteLine($"\t{FileProcessor.GetLineCount(filePath)} {filePath}");
                    break;
                case "-w":
                    Console.WriteLine($"\t{FileProcessor.GetWordCount(filePath)} {filePath}");
                    break;
                case "-m":
                    Console.WriteLine($"\t{FileProcessor.GetCharCount(filePath)} {filePath}");
                    break;
                default:
                    Console.WriteLine($"Unknown option: {option}");
                    PrintUsage();
                    return;
            }
        }
    }

    static void PrintUsage() {
        Console.WriteLine("Usage: ccwc [<file-path>] [-c <file-path>] [-l <file-path>] [-w <file-path>] [-m <file-path>]");
        Console.WriteLine("\nExamples:");
        Console.WriteLine("  ccwc <file-path>     # Outputs the number of bytes, lines, and words in the file");
        Console.WriteLine("  ccwc -c <file-path>  # Outputs the number of bytes in the file");
        Console.WriteLine("  ccwc -l <file-path>  # Outputs the number of lines in the file");
        Console.WriteLine("  ccwc -w <file-path>  # Outputs the number of words in the file");
        Console.WriteLine("  ccwc -m <file-path>  # Outputs the number of chars in the file");
    }

    static bool CheckFileExists(string filePath) {
        if (!File.Exists(filePath)) {
            Console.WriteLine($"Error: File not found: {filePath}");
            return false;
        }

        return true;
    }
}