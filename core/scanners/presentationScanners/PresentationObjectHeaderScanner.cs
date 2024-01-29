using AccessibilityReportForDocuments.core.errors;
using AccessibilityReportForDocuments.core.scanners.wordScanners;
using AccessibilityReportForDocumentsTests;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using Xunit.Abstractions;

namespace AccessibilityReportForDocuments.tests.core.scanners.presentationScanners
{
    public class PresentationObjectHeaderScannerTests
    {
        private readonly ITestOutputHelper output;

        public PresentationObjectHeaderScannerTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ScanPresentationTableHeaderScanner()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            // Given
            PresentationTableHeaderScanner scanner = new(Context.ContextLogger());
            string document = "C:\\Users\\v-karladal\\source\\repos\\AccessibilityReportForDocumentsTests\\mocks\\presentation table header and not.pptx";

            // When
            using PresentationDocument presentationDocument = PresentationDocument.Open(document, false);
            Presentation presentation = presentationDocument.PresentationPart.Presentation;
            List<AccessibilityError> result = scanner.Scan(presentationDocument, presentation);

            // Then            
            this.output.WriteLine(output.ToString());
            Assert.Equal(1, result.Count);
            Assert.Equal("Table 3", result[0].ObjectName);
        }       
    }
}
