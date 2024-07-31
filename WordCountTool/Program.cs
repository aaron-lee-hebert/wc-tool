namespace WordCountTool;
public class Program {
    static void Main(string[] args) {
        if (args.Length < 2 || args.Length % 2 != 0) {
            Console.WriteLine("Usage: ccwc [-c <file-path>] [-l <file-path>]");
            Console.WriteLine("\nExamples");
            Console.WriteLine("  ccwc -c <file-path>\t# Outputs the number of bytes in the file");
            Console.WriteLine("  ccwc -l <file-path>\t# Outputs the number of lines in the file");
            return;
        }

        for (int i = 0; i < args.Length; i++) {
            switch (args[i]) {
                // Output the number of bytes in the file
                case "-c":
                    if (i + 1 < args.Length) {
                        string? filePath = args[i + 1];
                        i++;
                        Console.WriteLine($"\t{FileProcessor.GetByteCount(filePath)} {filePath}");
                    } else {
                        Console.WriteLine("Error: Missing value for -c option.");
                        return;
                    }
                    break;
                // Output the number of lines in the file
                case "-l":
                    if (i + 1 < args.Length) {
                        string? filePath = args[i + 1];
                        i++;
                        Console.WriteLine($"\t{FileProcessor.GetLineCount(filePath)} {filePath}");
                    } else {
                        Console.WriteLine("Error: Missing value for -l option.");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine($"Unknown option: {args[i]}");
                    return;
            }
        }
    }
}