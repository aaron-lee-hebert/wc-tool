using WordCountTool;

namespace WordCountToolTests {
    public class FileProcessorTests {
        private static string TestFile => Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "test.txt");

        [Test]
        public void CanOutputBytesInAFile() {
            // act
            var result = FileProcessor.GetByteCount(TestFile);
            // assert
            Assert.That(result, Is.EqualTo(342190));
        } 

        [Test]
        public void CanOutputLinesInAFile() {
            // act
            var result = FileProcessor.GetLineCount(TestFile);
            // assert
            Assert.That(result, Is.EqualTo(7145));
        }
    }
}