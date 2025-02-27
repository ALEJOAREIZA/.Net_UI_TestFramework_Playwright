public class Link : BaseUIElement<Link>
{
    /// <summary>
    /// Initializes a new instance of the Link class with the specified UIDriver and UIElementSpec.
    /// </summary>
    /// <param name="uiDriver">The IUIDriver implementation.</param>
    /// <param name="uiElementSpec">The UIElementSpec defining the link UI element.</param>
    internal Link(IUIDriver uiDriver, UIElementSpec uiElementSpec) : base(uiDriver, uiElementSpec)
    {
    }

    /// <summary>
    /// Performs a click action on the link.
    /// </summary>
    /// <returns>The current instance of the Link.</returns>
    public override Link Click()
    {
        UIElement.ClickOnLink();
        return this;
    }
}