using System.IO;
using NUnit.Framework;

namespace Codecool.Histogram.UnitTests
{
    [TestFixture]
    public class TextReaderTests
    {
        [Test]
        public void TestTextReader_FileNotFound_ThrowsException()
        {
            var textReader = new TextReader("text");
            Assert.Throws<FileNotFoundException>(() => textReader.Read());
        }

        [Test]
        public void TestTextReader_EmptyFileNoText()
        {
            var textReader = new TextReader("empty.txt");
            Assert.AreEqual("", textReader.Read());
        }

        [Test]
        public void TestTextReader_OneLineText()
        {
            var textReader = new TextReader("test.txt");
            Assert.AreEqual("Harry Potter and the Sorcerer's Stone\n", textReader.Read());
        }

        [TestCase("text.txt")]
        public void TestTextReader_MultiLineText(string fileName)
        {
            var textReader = new TextReader(fileName);
            Assert.AreEqual(34, textReader.Read().Split("\n").Length);
        }

    }
}