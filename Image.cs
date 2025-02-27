public class Image : BaseUIElement<Image>
{
    /// <summary>
    /// Initializes a new instance of the Image class with the specified UIDriver and UIElementSpec.
    /// </summary>
    /// <param name="uiDriver">The IUIDriver implementation.</param>
    /// <param name="uiElementSpec">The UIElementSpec defining the image UI element.</param>
    internal Image(IUIDriver uiDriver, UIElementSpec uiElementSpec) : base(uiDriver, uiElementSpec)
    {
    }
}