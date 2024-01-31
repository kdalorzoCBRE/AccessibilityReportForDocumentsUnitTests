using AccessibilityReportForDocuments.core.errors;
using AccessibilityReportForDocuments.core.scanners.wordScanners;
using AccessibilityReportForDocumentsTests;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Xunit.Abstractions;

namespace AccessibilityReportForDocuments.tests.core.scanners.presentationScanners
{
    public class WordObjectHeaderScannerTests
    {
        private readonly ITestOutputHelper output;

        public WordObjectHeaderScannerTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ScanWordTableHeaderScannerErrorsFound()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            // Given
            WordTableHeaderScanner scanner = new(Context.ContextLogger());
            string document = "C:\\Users\\v-karladal\\source\\repos\\AccessibilityReportForDocumentsTests\\mocks\\doc with tables header no header.docx";

            // When
            using WordprocessingDocument wordDocument = WordprocessingDocument.Open(document, false);
            Body body = wordDocument.MainDocumentPart.Document.Body;
            List<AccessibilityError> result = scanner.Scan(wordDocument, body);

            // Then
            this.output.WriteLine(output.ToString());
            Assert.Single(result);
            Assert.Equal("Table 0480", result[0].ObjectName);
        }
    }
}
