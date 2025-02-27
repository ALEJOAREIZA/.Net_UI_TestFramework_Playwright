public class SearchInput : BaseUIElement<SearchInput>
{
    /// <summary>
    /// Initializes a new instance of the SearchInput class with the specified UIDriver and UIElementSpec.
    /// </summary>
    /// <param name="uiDriver">The IUIDriver implementation.</param>
    /// <param name="uiElementSpec">The UIElementSpec defining the search input UI element.</param>
    internal SearchInput(IUIDriver uiDriver, UIElementSpec uiElementSpec) : base(uiDriver, uiElementSpec)
    {
    }

    /// <summary>
    /// Types the specified text into the search input field.
    /// </summary>
    /// <param name="text">The text to type.</param>
    /// <returns>The current instance of the SearchInput.</returns>
    public SearchInput TypeText(string text)
    {
        UIElement.Type(text);
        return this;
    }
}