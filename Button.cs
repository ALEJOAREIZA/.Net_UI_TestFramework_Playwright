public class Button : BaseUIElement<Button>
{
    /// <summary>
    /// Initializes a new instance of the Button class with the specified UIDriver and UIElementSpec.
    /// </summary>
    /// <param name="uiDriver">The IUIDriver implementation.</param>
    /// <param name="uiElementSpec">The UIElementSpec defining the button UI element.</param>
    internal Button(IUIDriver uiDriver, UIElementSpec uiElementSpec) : base(uiDriver, uiElementSpec)
    {
    }

    /// <summary>
    /// Performs a click action on the button to initiate a download.
    /// </summary>
    public void ClickToDownload() => UIElement.ClickToDownload();
}
