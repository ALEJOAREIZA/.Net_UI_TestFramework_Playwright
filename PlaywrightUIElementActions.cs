internal sealed class PlaywrightUIElementActions(UIElementSpec uiElementSpec, ILocator locator) : IUIElementActions
{
    private readonly ILocator locator = locator;
    private readonly TracingManager trace = TracingManager.GetInstance();
    public UIElementSpec UIElementSpec { get; set; } = uiElementSpec;

    /// <summary>
    /// Performs a click action on the UI element.
    /// </summary>
    public void Click()
    {
        try
        {
            locator.ClickAsync().Wait();
            trace.Write.Info($"User clicked on \"{UIElementSpec.Name}\"");
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to click on \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Checks the UI element (e.g., checkbox).
    /// </summary>
    public void Check()
    {
        try
        {
            locator.CheckAsync().Wait();
            trace.Write.Info($"User checked \"{UIElementSpec.Name}\"");
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to check \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Unchecks the UI element (e.g., checkbox).
    /// </summary>
    public void Uncheck()
    {
        try
        {
            locator.UncheckAsync().Wait();
            trace.Write.Info($"User unchecked \"{UIElementSpec.Name}\"");
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to uncheck \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Performs a click action on a link UI element and waits for the page to load.
    /// </summary>
    public void ClickOnLink()
    {
        try
        {
            var newPage = locator.Page.Context.WaitForPageAsync();
            locator.ClickAsync().Wait();
            newPage.Wait();
            trace.Write.Info($"User clicked on link \"{UIElementSpec.Name}\"");
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to click on link \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Types the specified text into the UI element.
    /// </summary>
    /// <param name="text">The text to type.</param>
    public void Type(string text, bool obscured = false)
    {
        try
        {
            locator.ClearAsync().Wait();
            locator.FillAsync(text).Wait();
            if (!obscured)
            {
                trace.Write.Info($"User typed \"{text}\" into \"{UIElementSpec.Name}\"");
            }
            else
            {
                trace.Write.Info($"User typed \"****\" into \"{UIElementSpec.Name}\"");
            }
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to type \"{text}\" into \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Clears the text in the UI element.
    /// </summary>
    public void Clear()
    {
        try
        {
            locator.ClearAsync().Wait();
            trace.Write.Info($"User cleared text in \"{UIElementSpec.Name}\"");
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to clear text in \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Gets the visibility status of the UI element.
    /// </summary>
    public bool Visibility => IsVisible();

    /// <summary>
    /// Gets the selected status of the UI element.
    /// </summary>
    public bool SelectedStatus => IsSelected();

    /// <summary>
    /// Gets the checked status of the UI element.
    /// </summary>
    public bool CheckedStatus => IsChecked();

    /// <summary>
    /// Gets the enabled status of the UI element.
    /// </summary>
    public bool EnabledStatus => IsEnabled();

    /// <summary>
    /// Gets the text of the UI element.
    /// </summary>
    public string Text => GetText();

    private bool IsVisible()
    {
        try
        {
            locator.WaitForAsync(new LocatorWaitForOptions() { Timeout = 5000 }).Wait();
        }
        catch { }
        try
        {
            var visibility = locator.IsVisibleAsync();
            visibility.Wait();
            trace.Write.Info($"Visibility of \"{UIElementSpec.Name}\" is \"{visibility.Result}\"");
            return visibility.Result;
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to check visibility of \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    private bool IsSelected()
    {
        try
        {
            var class_attribute = locator.GetAttributeAsync("class");
            class_attribute.Wait();
            var ariaselected_attribute = locator.GetAttributeAsync("aria-selected");
            ariaselected_attribute.Wait();
            var classattribute_result = class_attribute.Result?.Contains("selected", StringComparison.InvariantCultureIgnoreCase) ?? false;
            var ariaselectedattribute_result = ariaselected_attribute.Result?.ToLowerInvariant() is "true";
            var result = classattribute_result || ariaselectedattribute_result;
            trace.Write.Info($"Selected status of \"{UIElementSpec.Name}\" is \"{result}\"");
            return result;
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to check Selected status of \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    private bool IsChecked()
    {
        try
        {
            var ischecked = locator.IsCheckedAsync();
            ischecked.Wait();
            trace.Write.Info($"Checked status of \"{UIElementSpec.Name}\" is \"{ischecked.Result}\"");
            return ischecked.Result;
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to check Checked status of \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Gets the value of the specified attribute of the UI element.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <returns>The value of the attribute.</returns>
    public string GetAttribute(string name)
    {
        try
        {
            var attribute = locator.GetAttributeAsync(name);
            attribute.Wait();
            trace.Write.Info($"Attribute {name} of \"{UIElementSpec.Name}\" is \"{attribute.Result}\"");
            return attribute.Result;
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to get attribute \"{name}\" of \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    private string GetText()
    {
        try
        {
            locator.WaitForAsync(new LocatorWaitForOptions() { Timeout = 3000 }).Wait();
        }
        catch { }
        try
        {
            var innertext = locator.InnerTextAsync();
            innertext.Wait();
            trace.Write.Info($"Text of \"{UIElementSpec.Name}\" is \"{innertext.Result}\"");
            return innertext.Result;
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to get text of \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Returns the number of UI elements matching the locator.
    /// </summary>
    /// <returns>The count of UI elements.</returns>
    public int Count()
    {
        try
        {
            locator.WaitForAsync(new LocatorWaitForOptions() { Timeout = 3000 }).Wait();
        }
        catch { }
        try
        {
            var counter = locator.CountAsync();
            counter.Wait();
            trace.Write.Info($"Number of \"{UIElementSpec.Name}\" is \"{counter.Result}\"");
            return counter.Result;
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to get count of \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Performs a click action on the UI element to initiate a download and waits for the download to complete.
    /// </summary>
    public void ClickToDownload()
    {
        try
        {
            var download = locator.Page.WaitForDownloadAsync();
            locator.ClickAsync().Wait();
            download.Wait();
            trace.Write.Info($"User clicked on \"{UIElementSpec.Name}\" and downloaded \"{download.Result.SuggestedFilename}\" ");
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to click and download on \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Takes a screenshot of the UI element and saves it at the specified TracingDir location
    /// </summary>
    /// <returns>The screenshot path</returns>
    public string TakeScreenshot()
    {
        try
        {
            var path = $"{trace.TracingDirPath}/{UIElementSpec.Name}_{DateTime.Now:yyMMddHHmmss}.png";
            var screenshot = locator.ScreenshotAsync(new LocatorScreenshotOptions()
            {
                Path = path
            });
            screenshot.Wait();
            trace.Write.Info($"User has taken a screenshot of \"{UIElementSpec.Name}\"");
            return path;
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to take screenshot of \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Waits until the UI element disappears from the page.
    /// </summary>
    public void WaitUntilItDisappears()
    {
        var flag = true;
        var sw = new Stopwatch();
        var limit = 30000;
        sw.Start();
        while (flag)
        {
            if (sw.ElapsedMilliseconds > limit)
            {
                throw new TimeoutException($"{UIElementSpec.Name} didn't disappear after {limit} ms");
            }
            try
            {
                locator.WaitForAsync(new LocatorWaitForOptions() { Timeout = 5000 }).Wait();
            }
            catch (Exception)
            {
            }
            flag = locator.IsVisibleAsync().Result;
        }
        sw.Stop();
    }

    private bool IsEnabled()
    {
        try
        {
            locator.WaitForAsync(new LocatorWaitForOptions() { Timeout = 5000 }).Wait();
        }
        catch { }
        try
        {
            var enabled = locator.IsEnabledAsync();
            enabled.Wait();
            trace.Write.Info($"Enabled status of \"{UIElementSpec.Name}\" is {enabled.Result}");
            return enabled.Result;
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to check Enabled status of \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }

    /// <summary>
    /// Simulates pressing the Enter key on the UI element.
    /// </summary>
    public void PressEnter()
    {
        try
        {
            locator.PressAsync("Enter").Wait();
            trace.Write.Info($"User pressed Enter on \"{UIElementSpec.Name}\"");
        }
        catch (Exception ex)
        {
            trace.Write.Error($"Failed to press Enter on \"{UIElementSpec.Name}\"");
            throw new UIElementHandlerException("Error:", ex);
        }
    }
}