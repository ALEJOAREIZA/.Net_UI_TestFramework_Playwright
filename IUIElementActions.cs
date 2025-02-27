/// <summary>
/// Represents a UI element with various actions that can be performed on it.
/// </summary>
public interface IUIElementActions
{
    /// <summary>
    /// Gets or sets the specification of the UI element.
    /// </summary>
    UIElementSpec UIElementSpec { get; set; }

    /// <summary>
    /// Performs a click action on a link UI element and waits for the page to load.
    /// </summary>
    void ClickOnLink();

    /// <summary>
    /// Performs a click action on the UI element.
    /// </summary>
    void Click();

    /// <summary>
    /// Performs a click action on the UI element to initiate a download and waits for the download to complete.
    /// </summary>
    void ClickToDownload();

    /// <summary>
    /// Checks the UI element (e.g., a checkbox).
    /// </summary>
    void Check();

    /// <summary>
    /// Unchecks the UI element (e.g., a checkbox).
    /// </summary>
    void Uncheck();

    /// <summary>
    /// Types the specified text into the UI element.
    /// </summary>
    /// <param name="text">The text to type.</param>
    void Type(string text, bool obscured = false);

    /// <summary>
    /// Clears the text from the UI element.
    /// </summary>
    void Clear();

    /// <summary>
    /// Gets the selected status of the UI element.
    /// </summary>
    bool SelectedStatus { get; }

    /// <summary>
    /// Gets the visibility status of the UI element.
    /// </summary>
    bool Visibility { get; }

    /// <summary>
    /// Gets the checked status of the UI element.
    /// </summary>
    bool CheckedStatus { get; }

    /// <summary>
    /// Gets the enabled status of the UI element.
    /// </summary>
    bool EnabledStatus { get; }

    /// <summary>
    /// Gets the text value of the UI element.
    /// </summary>
    string Text { get; }

    /// <summary>
    /// Gets the value of the specified attribute of the UI element.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <returns>The value of the attribute.</returns>
    string GetAttribute(string name);

    /// <summary>
    /// Counts the number of occurrences of the UI element.
    /// </summary>
    /// <returns>The number of occurrences of the UI element.</returns>
    int Count();

    /// <summary>
    /// Waits until the UI element disappears from the page.
    /// </summary>
    void WaitUntilItDisappears();

    /// <summary>
    /// Takes a screenshot of the UI element and saves it at the specified TracingDir location
    /// </summary>
    /// <returns>The screenshot path</returns>
    string TakeScreenshot();

    /// <summary>
    /// Presses the Enter key on the UI element.
    /// </summary>
    void PressEnter();
}
