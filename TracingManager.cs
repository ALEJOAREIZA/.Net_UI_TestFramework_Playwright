internal sealed class TracingManager
{
    public bool Logging { get; set; } = true;
    public string TracingDirPath { get; set; } = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}/TraceData";
    private readonly string fileName = $"{DateTime.Now:yyMMdd-HHmmss}_Trace.{FileType.Log}";

    private TracingManager()
    {
    }

    private static TracingManager instance;

    public static TracingManager GetInstance()
    {
        instance ??= new TracingManager();
        return instance;
    }

    public WriteManager Write => new WriteManager(this);

    public void ConvertDirectoryToZip()
    {
        var zipFile = $"{TracingDirPath}.zip";
        if (File.Exists(zipFile))
        {
            File.Delete(zipFile);
        }
        ZipFile.CreateFromDirectory(TracingDirPath, zipFile);
    }

    public sealed class WriteManager(TracingManager tracingManager)
    {
        private readonly TracingManager tracingManager = tracingManager;

        public void Info(string message) => WriteMessage($"{MessageType.Info} {message}");
        public void Warning(string message) => WriteMessage($"{MessageType.Warning} {message}");
        public void Error(string message) => WriteMessage($"{MessageType.Error} {message}");

        private void WriteMessage(string message)
        {
            if (tracingManager.Logging)
            {
                Directory.CreateDirectory(tracingManager.TracingDirPath);
                var dateHour = $"{DateTime.Now:dd-MM-yyyy h:mm:ss tt}";
                var file = $"{tracingManager.TracingDirPath}/{tracingManager.fileName}";
                using var writer = new StreamWriter(file, true);
                writer.WriteLine($"{dateHour}: {message}");
            }
        }
    }
}
