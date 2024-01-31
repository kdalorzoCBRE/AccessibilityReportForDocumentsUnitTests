using AccessibilityReportForDocuments.core.errors;
using AccessibilityReportForDocuments.core.scanners.wordScanners;
using AccessibilityReportForDocumentsTests;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using Xunit.Abstractions;

namespace AccessibilityReportForDocuments.tests.core.scanners.presentationScanners
{
    public class PresentationSectionNameScannerTests
    {
        private readonly ITestOutputHelper output;

        public PresentationSectionNameScannerTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ScanPresentationSectionNameScanner()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            // Given
            SectionNameScanner scanner = new(Context.ContextLogger());
            string document = "C:\\Users\\v-karladal\\source\\repos\\AccessibilityReportForDocumentsTests\\mocks\\presentation with default sections.pptx";

            // When
            using PresentationDocument presentationDocument = PresentationDocument.Open(document, false);
            Presentation presentation = presentationDocument.PresentationPart.Presentation;
            List<AccessibilityError> result = scanner.Scan(presentationDocument, presentation);

            // Then            
            this.output.WriteLine(output.ToString());
            Assert.Equal(4, result.Count);
            Assert.Equal("Default Section", result[0].ObjectName);
            Assert.Equal("Untitled Section", result[1].ObjectName);
            Assert.Equal("Section 1", result[2].ObjectName);
            Assert.Equal("Section 100", result[3].ObjectName);

        }
    }
}
