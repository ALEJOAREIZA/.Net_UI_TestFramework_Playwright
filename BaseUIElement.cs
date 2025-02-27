public abstract class BaseUIElement<TSELF>(IUIDriver uiDriver, UIElementSpec uiElementSpec)
    where TSELF : BaseUIElement<TSELF>
{
    /// <summary>
    /// Gets or sets the underlying IUIElement instance.
    /// </summary>
    internal IUIElementActions UIElement { get; } = uiDriver.FindElement(uiElementSpec);

    /// <summary>
    /// Gets or sets the UIElementSpec for the UI element.
    /// </summary>
    public UIElementSpec UIElementSpec { get; set; } = uiElementSpec;

    /// <summary>
    /// Performs a click action on the UI element.
    /// </summary>
    /// <returns>The updated instance of the derived class.</returns>
    public virtual TSELF Click()
    {
        UIElement.Click();
        return (TSELF)this;
    }

    /// <summary>
    /// Gets the visibility status of the UI element.
    /// </summary>
    public bool Visibility => UIElement.Visibility;

    /// <summary>
    /// Gets the enabled status of the UI element.
    /// </summary>
    public bool EnabledStatus => UIElement.EnabledStatus;

    /// <summary>
    /// Gets the text of the UI element.
    /// </summary>
    public string Text => UIElement.Text;

    /// <summary>
    /// Waits until the UI element disappears from the page.
    /// </summary>
    /// <returns>The updated instance of the derived class.</returns>
    public TSELF WaitUntilItDisappears()
    {
        UIElement.WaitUntilItDisappears();
        return (TSELF)this;
    }

    /// <summary>
    /// Returns the number of UI elements matching the locator.
    /// </summary>
    /// <returns>The count of UI elements.</returns>
    public int Count() => UIElement.Count();

    /// <summary>
    /// Gets the value of the specified attribute of the UI element.
    /// </summary>
    /// <param name="attribute">The name of the attribute.</param>
    /// <returns>The value of the attribute.</returns>
    public string GetAttribute(string attribute) => UIElement.GetAttribute(attribute);

    /// <summary>
    /// Simulates pressing the Enter key on the UI element.
    /// </summary>
    /// <returns>The updated instance of the derived class.</returns>
    public TSELF PressEnter()
    {
        UIElement.PressEnter();
        return (TSELF)this;
    }

    /// <summary>
    /// Takes a screenshot of the UI element and saves it at the specified TracingDir location
    /// </summary>
    /// <returns>The screenshot path</returns>
    public string TakeScreenshot() => UIElement.TakeScreenshot();
}