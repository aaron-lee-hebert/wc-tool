using WordCountTool;

namespace WordCountToolTests {
    public class FileProcessorTests {
        private static string TestFile => Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Assets\\", "test.txt");
        private static string EmptyFile => Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Assets\\", "empty.txt");


        [Test]
        public void CanOutputBytesInAFile() {
            // act
            var result = FileProcessor.GetByteCount(TestFile);
            // assert
            Assert.That(result, Is.EqualTo(342190));
        }

        [Test]
        public void CanOutputBytesInAFile_EmptyFile() {
            // act
            var result = FileProcessor.GetByteCount(EmptyFile);
            // assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CanOutputLinesInAFile() {
            // act
            var result = FileProcessor.GetLineCount(TestFile);
            // assert
            Assert.That(result, Is.EqualTo(7145));
        }

        [Test]
        public void CanOutputLinesInAFile_EmptyFile() {
            // act
            var result = FileProcessor.GetLineCount(EmptyFile);
            // assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CanOutputWordsInAFile() {
            // act
            var result = FileProcessor.GetWordCount(TestFile);
            // assert
            Assert.That(result, Is.EqualTo(58164));
        }

        [Test]
        public void CanOutputWordsInAFile_EmptyFile() {
            // act
            var result = FileProcessor.GetWordCount(EmptyFile);
            // assert
            Assert.That(result, Is.EqualTo(0));
        }

    }
}