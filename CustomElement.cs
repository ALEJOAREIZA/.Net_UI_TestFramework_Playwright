public class CustomElement : BaseUIElement<CustomElement>
{
    /// <summary>
    /// Initializes a new instance of the CustomElement class with the specified UIDriver and UIElementSpec.
    /// </summary>
    /// <param name="uiDriver">The IUIDriver implementation.</param>
    /// <param name="uiElementSpec">The UIElementSpec defining the custom UI element.</param>
    internal CustomElement(IUIDriver uiDriver, UIElementSpec uiElementSpec) : base(uiDriver, uiElementSpec)
    {
    }
}