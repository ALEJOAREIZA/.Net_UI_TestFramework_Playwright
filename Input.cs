public class Input : BaseUIElement<Input>
{
    /// <summary>
    /// Initializes a new instance of the Input class with the specified UIDriver and UIElementSpec.
    /// </summary>
    /// <param name="uiDriver">The IUIDriver implementation.</param>
    /// <param name="uiElementSpec">The UIElementSpec defining the input UI element.</param>
    internal Input(IUIDriver uiDriver, UIElementSpec uiElementSpec) : base(uiDriver, uiElementSpec)
    {
    }

    /// <summary>
    /// Types the specified text into the input field.
    /// </summary>
    /// <param name="text">The text to type.</param>
    /// <returns>The current instance of the Input.</returns>
    public Input TypeText(string text, bool obscured = false)
    {
        UIElement.Type(text, obscured);
        return this;
    }

    /// <summary>
    /// Gets the value of the input field.
    /// </summary>
    /// <returns>The value of the input field.</returns>
    public string GetValue() => UIElement.GetAttribute("value");

    /// <summary>
    /// Clears the input field.
    /// </summary>
    /// <returns>The current instance of the Input.</returns>
    public Input Clear()
    {
        UIElement.Clear();
        return this;
    }
}