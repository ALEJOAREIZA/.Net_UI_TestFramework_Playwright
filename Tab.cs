public class Tab : BaseUIElement<Tab>
{
    /// <summary>
    /// Initializes a new instance of the Tab class with the specified UIDriver and UIElementSpec.
    /// </summary>
    /// <param name="uiDriver">The IUIDriver implementation.</param>
    /// <param name="uiElementSpec">The UIElementSpec defining the tab UI element.</param>
    internal Tab(IUIDriver uiDriver, UIElementSpec uiElementSpec) : base(uiDriver, uiElementSpec)
    {
    }

    /// <summary>
    /// Gets the selected status of the tab.
    /// </summary>
    public bool SelectedStatus => UIElement.SelectedStatus;
}