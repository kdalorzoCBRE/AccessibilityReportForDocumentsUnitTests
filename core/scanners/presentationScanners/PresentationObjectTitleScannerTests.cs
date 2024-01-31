using AccessibilityReportForDocuments.core.errors;
using AccessibilityReportForDocuments.core.scanners.wordScanners;
using AccessibilityReportForDocumentsTests;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using Xunit.Abstractions;

namespace AccessibilityReportForDocuments.tests.core.scanners.presentationScanners
{
    public class PresentationObjectTitleScannerTests
    {
        private readonly ITestOutputHelper output;

        public PresentationObjectTitleScannerTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ScanPresentationSlideTitleScanner()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            // Given
            SlideTitleScanner scanner = new(Context.ContextLogger());
            string document = "C:\\Users\\v-karladal\\source\\repos\\AccessibilityReportForDocumentsTests\\mocks\\presentation slide titles.pptx";

            // When
            using PresentationDocument presentationDocument = PresentationDocument.Open(document, false);
            Presentation presentation = presentationDocument.PresentationPart.Presentation;
            List<AccessibilityError> result = scanner.Scan(presentationDocument, presentation);

            // Then            
            this.output.WriteLine(output.ToString());
            Assert.Equal(3, result.Count);
            Assert.Equal("Slide 1", result[0].ObjectName);
            Assert.Equal("Slide 3", result[1].ObjectName);
            Assert.Equal("Slide 4", result[2].ObjectName);
        }
    }
}
