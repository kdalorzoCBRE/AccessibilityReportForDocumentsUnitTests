using AccessibilityReportForDocuments.core.errors;
using AccessibilityReportForDocuments.core.reports;
using AccessibilityReportForDocuments.core.scanners.wordScanners;
using AccessibilityReportForDocumentsTests;
using Xunit.Abstractions;

namespace AccessibilityReportForDocuments.tests.core.scanners.presentationScanners
{
    public class WordDocumentAccessScannerTests
    {
        private readonly ITestOutputHelper output;

        public WordDocumentAccessScannerTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ScanAccessScannerErrorsFound()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            // Given
            DocumentDisabledAccessContentProgramaticallyScanner scanner = new(Context.ContextLogger());
            string document = "C:\\Users\\v-karladal\\source\\repos\\AccessibilityReportForDocumentsTests\\mocks\\Document with restricted access.docx";
            Stream stream = File.OpenRead(document);

            // When
            WordDocumentReport report = new(Context.ContextLogger());
            List<AccessibilityError> result = report.GenerateReport(stream);

            // Then
            this.output.WriteLine(output.ToString());
            Assert.Single(result);
            Assert.Equal("Word", result[0].ObjectName);
        }
    }
}
