using System.Runtime.ExceptionServices;

namespace WordCountTool;
public class Program {
    static void Main(string[] args) {
        bool verbose = false;

        for (int i = 0; i < args.Length; i++) {
            switch (args[i]) {
                case "-c":
                    if (i + 1 < args.Length) {
                        string? filePath = args[i + 1];
                        i++;
                        Console.WriteLine(FileProcessor.GetByteCount(filePath));
                    } else {
                        Console.WriteLine("Error: Missing value for -c option.");
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