public class Alert : BaseUIElement<Alert>
{
    /// <summary>
    /// Initializes a new instance of the Alert class with the specified UIDriver and UIElementSpec.
    /// </summary>
    /// <param name="uiDriver">The IUIDriver implementation.</param>
    /// <param name="uiElementSpec">The UIElementSpec defining the alert UI element.</param>
    internal Alert(IUIDriver uiDriver, UIElementSpec uiElementSpec) : base(uiDriver, uiElementSpec)
    {
    }
}
