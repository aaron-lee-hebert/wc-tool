namespace WordCountTool;
public class Program {
    static void Main(string[] args) {
        if (args.Length < 2 || args.Length % 2 != 0) {
            PrintUsage();
            return;
        }

        for (int i = 0; i < args.Length; i += 2) {
            string option = args[i];
            string filePath = args[i + 1];

            if (!File.Exists(filePath)) {
                Console.WriteLine($"Error: File not found: {filePath}");
                continue;
            }

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
                default:
                    Console.WriteLine($"Unknown option: {option}");
                    PrintUsage();
                    return;
            }
        }
    }

    static void PrintUsage() {
        Console.WriteLine("Usage: ccwc [-c <file-path>] [-l <file-path>] [-w <file-path>]");
        Console.WriteLine("\nExamples:");
        Console.WriteLine("  ccwc -c <file-path>  # Outputs the number of bytes in the file");
        Console.WriteLine("  ccwc -l <file-path>  # Outputs the number of lines in the file");
        Console.WriteLine("  ccwc -w <file-path>  # Outputs the number of words in the file");
    }
}