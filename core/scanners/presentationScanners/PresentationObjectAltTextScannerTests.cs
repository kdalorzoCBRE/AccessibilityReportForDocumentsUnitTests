using AccessibilityReportForDocuments.core.errors;
using AccessibilityReportForDocuments.core.scanners.presentationScanners;
using AccessibilityReportForDocumentsTests;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;

namespace AccessibilityReportForDocuments.tests.core.scanners.presentationScanners
{
    public class PresentationObjectAltTextScannerTests
    {

        [Fact]
        public void ScanPresentationImageAltTextScannerErrorsFound()
        {
            // Given
            ImageAltTextScanner scanner = new(Context.ContextLogger());
            string document = "C:\\Users\\v-karladal\\source\\repos\\AccessibilityReportForDocumentsTests\\mocks\\presentation with no alt text for objects.pptx";

            // When
            using PresentationDocument presentationDocument = PresentationDocument.Open(document, false);
            Presentation presentation = presentationDocument.PresentationPart.Presentation;
            List<AccessibilityError> result = scanner.Scan(presentationDocument, presentation); 

            // Then
            Assert.Equal(4, result.Count);
            Assert.Equal("Picture 6", result[0].ObjectName);
            Assert.Equal("Content Placeholder 4", result[1].ObjectName);
            Assert.Equal("Content Placeholder 6", result[2].ObjectName);
            Assert.Equal("3D Model 3", result[3].ObjectName);
        }

        [Fact]
        public void ScanPresentationImageAltTextScannerNoErrorsFound()
        {
            // Given
            ImageAltTextScanner scanner = new(Context.ContextLogger());
            string document = "C:\\Users\\v-karladal\\source\\repos\\AccessibilityReportForDocumentsTests\\mocks\\presentation with alt text for objects.pptx";

            // When
            using PresentationDocument presentationDocument = PresentationDocument.Open(document, false);
            Presentation presentation = presentationDocument.PresentationPart.Presentation;
            List<AccessibilityError> result = scanner.Scan(presentationDocument, presentation);

            // Then
            Assert.Empty(result);
        }

        [Fact]
        public void ScanPresentationShapeAltTextScannerErrorsFound()
        {
            // Given
            ShapeAltTextScanner scanner = new(Context.ContextLogger());
            string document = "C:\\Users\\v-karladal\\source\\repos\\AccessibilityReportForDocumentsTests\\mocks\\presentation with no alt text for objects.pptx";

            // When
            using PresentationDocument presentationDocument = PresentationDocument.Open(document, false);
            Presentation presentation = presentationDocument.PresentationPart.Presentation;
            List<AccessibilityError> result = scanner.Scan(presentationDocument, presentation);

            // Then
            Assert.Single(result);
            Assert.Equal("Rectangle 3", result[0].ObjectName);
        }

        [Fact]
        public void ScanPresentationShapeAltTextScannerNoErrorsFound()
        {
            // Given
            ShapeAltTextScanner scanner = new(Context.ContextLogger());
            string document = "C:\\Users\\v-karladal\\source\\repos\\AccessibilityReportForDocumentsTests\\mocks\\presentation with alt text for objects.pptx";

            // When
            using PresentationDocument presentationDocument = PresentationDocument.Open(document, false);
            Presentation presentation = presentationDocument.PresentationPart.Presentation;
            List<AccessibilityError> result = scanner.Scan(presentationDocument, presentation);

            // Then
            Assert.Empty(result);
        }


        [Fact]
        public void ScanPresentationGraphicAltTextScannerAltTextScannerErrorsFound()
        {
            // Given
            GraphicAltTextScanner scanner = new(Context.ContextLogger());
            string document = "C:\\Users\\v-karladal\\source\\repos\\AccessibilityReportForDocumentsTests\\mocks\\presentation with no alt text for objects.pptx";

            // When
            using PresentationDocument presentationDocument = PresentationDocument.Open(document, false);
            Presentation presentation = presentationDocument.PresentationPart.Presentation;
            List<AccessibilityError> result = scanner.Scan(presentationDocument, presentation);

            // Then
            Assert.Equal(3, result.Count);
            Assert.Equal("3D Model 3", result[0].ObjectName);
            Assert.Equal("Diagram 3", result[1].ObjectName);
            Assert.Equal("Content Placeholder 5", result[2].ObjectName);
        }

        [Fact]
        public void ScanPresentationGraphicAltTextScannerAltTextScannerNoErrorsFound()
        {
            // Given
            GraphicAltTextScanner scanner = new(Context.ContextLogger());
            string document = "C:\\Users\\v-karladal\\source\\repos\\AccessibilityReportForDocumentsTests\\mocks\\presentation with alt text for objects.pptx";

            // When
            using PresentationDocument presentationDocument = PresentationDocument.Open(document, false);
            Presentation presentation = presentationDocument.PresentationPart.Presentation;
            List<AccessibilityError> result = scanner.Scan(presentationDocument, presentation);
            
            // Then
            Assert.Empty(result);
        }
    }
}
