/// <summary>
/// Represents a UI driver for interacting with web pages.
/// </summary>
public interface IUIDriver : IDisposable
{
    /// <summary>
    /// Finds a UI element based on the provided UI element specification.
    /// </summary>
    /// <param name="uiElementSpec">The specification of the UI element to find.</param>
    /// <returns>The found UI element.</returns>
    IUIElementActions FindElement(UIElementSpec uiElementSpec);

    /// <summary>
    /// Navigates to the specified URL.
    /// </summary>
    /// <param name="url">The URL to navigate to.</param>
    void NavigateToPage(string url);

    /// <summary>
    /// Retrieves the title of the current web page.
    /// </summary>
    /// <returns>The title of the web page.</returns>
    string GetPageTitle();

    /// <summary>
    /// Retrieves the HTML code of the current web page.
    /// </summary>
    /// <returns>The HTML code of the web page.</returns>
    string GetPageHtmlCode();

    /// <summary>
    /// Opens a new tab in the same page
    /// </summary>
    public void OpenNewTab();

    /// <summary>
    /// Changes to a specific page number.
    /// </summary>
    /// <param name="pageNumber">The number of the page to change to.</param>
    void ChangeToTab(int pageNumber);

    /// <summary>
    /// Closes the current Tab.
    /// </summary>
    void CloseCurrentTab();

    /// <summary>
    /// Closes all open tabs.
    /// </summary>
    void CloseAllTabs();

    /// <summary>
    /// Takes a screenshot of the current page and saves it at the specified TracingDir location
    /// </summary>
    /// <returns>The screenshot path</returns>
    string TakeScreenshot();
}
