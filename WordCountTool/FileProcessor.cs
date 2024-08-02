namespace WordCountTool {
    public class FileProcessor {
        public static long GetByteCount(string filePath) {
            try {
                return File.ReadAllBytes(filePath).Length;
            }
            catch (Exception ex) {
                Console.WriteLine($"Error getting byte count: {ex.Message}");
                return 0;
            }
        }

        public static long GetLineCount(string filePath) {
            try {
                return File.ReadAllLines(filePath).Length;
            }
            catch (Exception ex) {
                Console.WriteLine($"Error getting line count: {ex.Message}");
                return 0;
            }
        }

        public static long GetWordCount(string filePath) {
            try {
                return File.ReadAllText(filePath).Split([' ', '\t', '\n', '\r'], StringSplitOptions.RemoveEmptyEntries).Length;
            }
            catch (Exception ex) {
                Console.WriteLine($"Error getting word count: {ex.Message}");
                return 0;
            }
        }

        public static long GetCharCount(string filePath) {
            try {
                var result = File.ReadAllText(filePath).Length;
                return result != 0 ? result + 1 : result;
            }
            catch (Exception ex) {
                Console.WriteLine($"Error getting character count: {ex.Message}");
                return 0;
            }
        }
    }
}
