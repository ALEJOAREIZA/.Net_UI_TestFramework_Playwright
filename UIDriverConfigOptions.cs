/// <summary>
/// Represents the configuration options class for the UI driver. (UIDriverSettings, TracingSettings, BrowserSettings)
/// </summary>
public class UIDriverConfigOptions
{
    /// <summary>
    /// <para>Represents the configuration options for the UI driver. (UIDriverType, Workers, Timeout)</para>
    /// </summary>
    public UIDriverSettings UIDriverSettings { get; set; } = new UIDriverSettings();

    /// <summary>
    /// <para>Represents the settings for tracing (Logging, Screenshot, Video, HARFile, TracingDirPath).</para>
    /// </summary>
    public TracingSettings TracingSettings { get; set; } = new TracingSettings();

    /// <summary>
    /// <para>Represents the settings for the browser. (BrowserType, Headless, ScreenSize)</para>
    /// </summary>
    public BrowserSettings BrowserSettings { get; set; } = new BrowserSettings();
}

/// <summary>
/// <para>Represents the configuration options for the UI driver. (UIDriverType, Workers, Timeout)</para>
/// </summary>
public class UIDriverSettings
{
    /// <summary>
    /// <para>Represents the type of UI driver. Default value is Playwright.</para>
    /// </summary>
    public UIDriverType UIDriverType { get; set; } = UIDriverType.Playwright;

    /// <summary>
    /// <para>Represents the number of workers for parallel execution. Default value is 1.</para>
    /// <para>Still under development</para>
    /// </summary>
    public int Workers { get; set; } = 1;

    /// <summary>
    /// <para>Represents the timeout duration in milliseconds. Default value is 30000.</para>
    /// </summary>
    public float Timeout { get; set; } = 30000;
}

/// <summary>
/// <para>Represents the settings for the browser. (BrowserType, Headless, ScreenSize)</para>
/// </summary>
public class BrowserSettings
{
    /// <summary>
    /// <para>Represents the type of browser to be used. Default value is Chromium.</para>
    /// <para>Choose from Chrome, Chromium</para>
    /// </summary>
    public BrowserType BrowserType { get; set; } = BrowserType.Chromium;

    /// <summary>
    /// <para>Indicates whether the browser should run in headless mode. Default value is true.</para>
    /// </summary>
    public bool Headless { get; set; } = true;

    /// <summary>
    /// <para>Represents the screen size for the browser</para>
    /// <para>Default value is 1800x957</para>
    /// </summary>
    public ScreenSize ScreenSize { get; set; } = new ScreenSize();
}

/// <summary>
/// <para>Represents the settings for tracing (Logging, Screenshot, Video, HARFile, TracingDirPath).</para>
/// </summary>
public class TracingSettings
{
    /// <summary>
    /// <para>Indicates whether logging should be enabled during tracing. Default value is true.</para>
    /// </summary>
    public bool Logging { get; set; } = true;

    /// <summary>
    /// <para>Indicates whether capturing screenshots should be enabled during tracing. Default value is true.</para>
    /// </summary>
    public bool Screenshot { get; set; } = true;

    /// <summary>
    /// <para>Indicates whether recording videos should be enabled during tracing. Default value is true.</para>
    /// </summary>
    public bool Video { get; set; } = true;

    /// <summary>
    /// <para>Indicates whether saving HAR files should be enabled during tracing. Default value is true.</para>
    /// </summary>
    public bool HarFile { get; set; } = true;

    /// <summary>
    /// <para>Represents the directory path where the tracing data will be stored. The default path is CurrentDirectory/TraceData/DateTime.Now/TestMethodName.</para>
    /// </summary>
    public string TracingDirPath { get; set; } = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}/TraceData/{DateTime.Now:yyMMdd-HHmmss}_{TestContext.CurrentContext.Test.MethodName}";
}

public class ScreenSize
{
    /// <summary>
    /// <para>Represents the width of the screen. Default value is 1800.</para>
    /// </summary>
    public int Width { get; set; } = 1800;

    /// <summary>
    /// <para>Represents the height of the screen. Default value is 957.</para>
    /// </summary>
    public int Height { get; set; } = 957;
}
