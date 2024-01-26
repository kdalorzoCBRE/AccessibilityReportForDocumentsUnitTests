using Microsoft.Extensions.Logging;

namespace AccessibilityReportForDocumentsTests
{
    public static class Context
    {
        public static ILogger ContextLogger()
        {
            return new LoggerFactory().CreateLogger(typeof(Context));
        }
    }
}
