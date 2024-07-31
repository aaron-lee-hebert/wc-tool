namespace WordCountTool {
    public class FileProcessor {
        public static long GetByteCount(string filePath) => File.ReadAllBytes(filePath).Length;

        public static long GetLineCount(string filePath) => File.ReadAllLines(filePath).Length;
    }
}
