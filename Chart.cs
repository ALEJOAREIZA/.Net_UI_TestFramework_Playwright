public class Chart : BaseUIElement<Chart>
{
    /// <summary>
    /// Initializes a new instance of the Chart class with the specified UIDriver and UIElementSpec.
    /// </summary>
    /// <param name="uiDriver">The IUIDriver implementation.</param>
    /// <param name="uiElementSpec">The UIElementSpec defining the chart UI element.</param>
    internal Chart(IUIDriver uiDriver, UIElementSpec uiElementSpec) : base(uiDriver, uiElementSpec)
    {
    }
}