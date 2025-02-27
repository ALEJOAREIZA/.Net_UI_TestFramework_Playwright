internal sealed class PlaywrightUIDriver : IUIDriver
{
    private IPage page;
    private readonly UIDriverConfigOptions uiDriverConfigOptions;
    private readonly TracingManager trace;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightUIDriver"/> class.
    /// </summary>
    /// <param name="uiDriverConfigOptions">UI driver configuration options.</param>
    public PlaywrightUIDriver(UIDriverConfigOptions uiDriverConfigOptions)
    {
        try
        {
            this.uiDriverConfigOptions = uiDriverConfigOptions;
            trace = TracingManager.GetInstance();
            trace.Logging = uiDriverConfigOptions.TracingSettings.Logging;
            trace.TracingDirPath = uiDriverConfigOptions.TracingSettings.TracingDirPath;
            var browser = InitializeBrowser();
            page = InitializePage(browser);
            trace.Write.Info($"===== {TestContext.CurrentContext.Test.MethodName} has started =====");
            trace.Write.Info("User Opened Browser");
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed creating the UIDriver with message \"{ex}\"");
            throw new UIDriverHandlerException("Error:", ex);
        }

    }
    private IBrowser InitializeBrowser()
    {
        var playwrightDriver = Playwright.CreateAsync().Result;
        var launchOptions = new BrowserTypeLaunchOptions
        {
            Channel = uiDriverConfigOptions.BrowserSettings.BrowserType.ToString().ToLower(),
            Headless = uiDriverConfigOptions.BrowserSettings.Headless,
            Args = ["--auth-server-allowlist='*'"]
        };
        return uiDriverConfigOptions.BrowserSettings.BrowserType switch
        {
            BrowserType.Chrome or BrowserType.Chromium => playwrightDriver.Chromium.LaunchAsync(launchOptions).Result,
            BrowserType.Firefox => throw new NotImplementedException("Firefox driver is currently not implemented"),
            BrowserType.IE => throw new NotImplementedException("IE driver is currently not implemented"),
            _ => throw new NotImplementedException()
        };
    }
    private IPage InitializePage(IBrowser browser)
    {
        var browserOptions = CreateBrowserContextOptions();
        var browserContext = browser.NewContextAsync(browserOptions).Result;
        browserContext.SetDefaultTimeout(uiDriverConfigOptions.UIDriverSettings.Timeout);
        browserContext.SetDefaultNavigationTimeout(uiDriverConfigOptions.UIDriverSettings.Timeout);
        if (uiDriverConfigOptions.TracingSettings.Screenshot)
        {
            browserContext.Tracing.StartAsync(new TracingStartOptions
            {
                Screenshots = true,
                Snapshots = true
            }).Wait();
        }
        return browserContext.NewPageAsync().Result;
    }
    private BrowserNewContextOptions CreateBrowserContextOptions()
    {
        var options = new BrowserNewContextOptions
        {
            IgnoreHTTPSErrors = true,
            ViewportSize = new ViewportSize
            {
                Width = uiDriverConfigOptions.BrowserSettings.ScreenSize.Width,
                Height = uiDriverConfigOptions.BrowserSettings.ScreenSize.Height
            }
        };
        if (uiDriverConfigOptions.TracingSettings.HarFile)
        {
            options.RecordHarPath = $"{trace.TracingDirPath}/{DateTime.Now:yyMMddHHmmss}_HARLog.har";
        }
        if (uiDriverConfigOptions.TracingSettings.Video)
        {
            options.RecordVideoDir = trace.TracingDirPath;
        }
        return options;
    }

    /// <summary>
    /// Navigates to the specified URL.
    /// </summary>
    /// <param name="url">The URL to navigate to.</param>
    public void NavigateToPage(string url)
    {
        try
        {
            page.GotoAsync(url, new PageGotoOptions()
            {
                WaitUntil = WaitUntilState.DOMContentLoaded
            }).Wait();
            trace.Write.Info($"User navigated to {url}");
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed navigating to {url}");
            throw new UIDriverHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Closes the current Tab.
    /// </summary>
    public void CloseCurrentTab()
    {
        try
        {
            page.CloseAsync().Wait();
            trace.Write.Info($"User has closed the current tab");
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed closing the tab");
            throw new UIDriverHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Finds an element on the page based on the specified UI element specification.
    /// </summary>
    /// <param name="uiElementSpec">The UI element specification.</param>
    /// <returns>An object representing the found UI element.</returns>
    public IUIElementActions FindElement(UIElementSpec uiElementSpec)
    {
        ILocator locator = null;
        switch (uiElementSpec.FindBy.Mechanism)
        {
            case FindByType.Css:
                locator = page.Locator($"css={uiElementSpec.FindBy.Locator}");
                break;
            case FindByType.Xpath:
                locator = page.Locator($"xpath={uiElementSpec.FindBy.Locator}");
                break;
            case FindByType.Id:
                locator = page.Locator($"#{uiElementSpec.FindBy.Locator}");
                break;
            case FindByType.Name:
                locator = page.Locator($"xpath=//*[@name='{uiElementSpec.FindBy.Locator}']");
                break;
            case FindByType.Text:
                locator = page.Locator($"xpath=//*[translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = '{uiElementSpec.FindBy.Locator}']");


                break;
            default:
                break;
        }
        return new PlaywrightUIElementActions(uiElementSpec, locator);
    }

    /// <summary>
    /// Opens a new tab in the same page.
    /// </summary>
    public void OpenNewTab()
    {
        try
        {
            page.Context.NewPageAsync().Wait();
            page = page.Context.Pages[page.Context.Pages.Count - 1];
            page.BringToFrontAsync().Wait();
            trace.Write.Info($"User has opened a new tab");
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed opening a new tab");
            throw new UIDriverHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Changes to the specified tab number.
    /// </summary>
    /// <param name="tabNumber">The tab number to change to.</param>
    public void ChangeToTab(int tabNumber)
    {
        try
        {
            var allPages = page.Context.Pages;
            page = allPages[tabNumber - 1];
            page.BringToFrontAsync().Wait();
            trace.Write.Info($"User has changed to tab {tabNumber}");
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed changing to tab {tabNumber}");
            throw new UIDriverHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Retrieves the title of the current page.
    /// </summary>
    /// <returns>The title of the page.</returns>
    public string GetPageTitle()
    {
        try
        {
            var title = page.TitleAsync();
            title.Wait();
            trace.Write.Info($"Page Title is \"{title.Result}\"");
            return title.Result;
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed retrieving the title of the page");
            throw new UIDriverHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Retrieves the HTML code of the current page.
    /// </summary>
    /// <returns>The HTML code of the page.</returns>
    public string GetPageHtmlCode() => throw new UIDriverHandlerException("GetPageHtmlCode Method not implemented");

    /// <summary>
    /// Takes a screenshot of the current page and saves it at the specified TracingDir location
    /// </summary>
    /// <returns>The screenshot path</returns>
    public string TakeScreenshot()
    {
        try
        {
            var path = $"{trace.TracingDirPath}/screenshot_{DateTime.Now:yyMMddHHmmss}.png";
            var screenshot = page.ScreenshotAsync(new PageScreenshotOptions()
            {
                Path = path
            });
            screenshot.Wait();
            trace.Write.Info($"User has taken a page screenshot");
            return path;
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed taking page screenshot");
            throw new UIDriverHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Closes all the tabs.
    /// </summary>
    public void CloseAllTabs()
    {
        try
        {
            var pages = page.Context.Pages.ToList();
            if (pages.Count != 0)
            {
                pages.ForEach(page => page.CloseAsync().Wait());
                trace.Write.Info($"User has closed all tabs");
            }
            else
            {
                trace.Write.Info("No tabs to close");
            }
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed closing the page");
            throw new UIDriverHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Disposes the driver and cleans up any resources.
    /// </summary>
    public void Dispose()
    {
        if (page.Context.Browser.IsConnected)
        {
            if (uiDriverConfigOptions.TracingSettings.Screenshot)
            {
                page.Context.Browser.Contexts.ToList().ForEach(context => context.Tracing.StopAsync(new() { Path = $"{trace.TracingDirPath}/Screenshots.zip" }).Wait());
            }
            page.CloseAsync().Wait();
            page.Context.Browser.DisposeAsync().AsTask().Wait();
            trace.Write.Info($"===== {TestContext.CurrentContext.Test.MethodName} has finished =====");
            trace.Write.Info($"Test {TestContext.CurrentContext.Result.Outcome.Status} {TestContext.CurrentContext.Result.Message}");
        }
    }
}