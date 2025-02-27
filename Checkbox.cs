public class CheckBox : BaseUIElement<CheckBox>
{
    /// <summary>
    /// Initializes a new instance of the CheckBox class with the specified UIDriver and UIElementSpec.
    /// </summary>
    /// <param name="uiDriver">The IUIDriver implementation.</param>
    /// <param name="uiElementSpec">The UIElementSpec defining the checkbox UI element.</param>
    internal CheckBox(IUIDriver uiDriver, UIElementSpec uiElementSpec) : base(uiDriver, uiElementSpec)
    {
    }

    /// <summary>
    /// Checks the checkbox.
    /// </summary>
    /// <returns>The current instance of the CheckBox.</returns>
    public CheckBox Check()
    {
        UIElement.Check();
        return this;
    }

    /// <summary>
    /// Unchecks the checkbox.
    /// </summary>
    /// <returns>The current instance of the CheckBox.</returns>
    public CheckBox Uncheck()
    {
        UIElement.Uncheck();
        return this;
    }

    /// <summary>
    /// Gets the checked status of the checkbox.
    /// </summary>
    public bool CheckedStatus => UIElement.CheckedStatus;
}
