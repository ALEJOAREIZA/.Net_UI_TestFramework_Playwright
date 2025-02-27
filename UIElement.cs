/// <summary>
/// The <c>UIElement</c> class represents pre-created UI elements with their related properties and methods.
/// It provides a convenient way to work with UI elements out of the box.
/// </summary>
/// <param name="uiDriver"></param>
public class UIElement(IUIDriver uiDriver)
{
    private readonly IUIDriver uiDriver = uiDriver;

    /// <summary>
    /// Creates a new instance of CheckBox with the specified UIElementSpec.
    /// </summary>
    /// <param name="uiElementSpec">The UI element specification for the CheckBox.</param>
    /// <returns>A new instance of CheckBox.</returns>
    public CheckBox CheckBox(UIElementSpec uiElementSpec) => new CheckBox(uiDriver, uiElementSpec);

    /// <summary>
    /// Creates a new instance of Button with the specified UIElementSpec.
    /// </summary>
    /// <param name="uiElementSpec">The UI element specification for the Button.</param>
    /// <returns>A new instance of Button.</returns>
    public Button Button(UIElementSpec uiElementSpec) => new Button(uiDriver, uiElementSpec);

    /// <summary>
    /// Creates a new instance of Input with the specified UIElementSpec.
    /// </summary>
    /// <param name="uiElementSpec">The UI element specification for the Input.</param>
    /// <returns>A new instance of Input.</returns>
    public Input Input(UIElementSpec uiElementSpec) => new Input(uiDriver, uiElementSpec);

    /// <summary>
    /// Creates a new instance of SearchInput with the specified UIElementSpec.
    /// </summary>
    /// <param name="uiElementSpec">The UI element specification for the SearchInput.</param>
    /// <returns>A new instance of SearchInput.</returns>
    public SearchInput SearchInput(UIElementSpec uiElementSpec) => new SearchInput(uiDriver, uiElementSpec);

    /// <summary>
    /// Creates a new instance of Alert with the specified UIElementSpec.
    /// </summary>
    /// <param name="uiElementSpec">The UI element specification for the Alert.</param>
    /// <returns>A new instance of Alert.</returns>
    public Alert Alert(UIElementSpec uiElementSpec) => new Alert(uiDriver, uiElementSpec);

    /// <summary>
    /// Creates a new instance of Tab with the specified UIElementSpec.
    /// </summary>
    /// <param name="uiElementSpec">The UI element specification for the Tab.</param>
    /// <returns>A new instance of Tab.</returns>
    public Tab Tab(UIElementSpec uiElementSpec) => new Tab(uiDriver, uiElementSpec);

    /// <summary>
    /// Creates a new instance of Chart with the specified UIElementSpec.
    /// </summary>
    /// <param name="uiElementSpec">The UI element specification for the Chart.</param>
    /// <returns>A new instance of Chart.</returns>
    public Chart Chart(UIElementSpec uiElementSpec) => new Chart(uiDriver, uiElementSpec);

    /// <summary>
    /// Creates a new instance of Link with the specified UIElementSpec.
    /// </summary>
    /// <param name="uiElementSpec">The UI element specification for the Link.</param>
    /// <returns>A new instance of Link.</returns>
    public Link Link(UIElementSpec uiElementSpec) => new Link(uiDriver, uiElementSpec);

    /// <summary>
    /// Creates a new instance of CustomElement with the specified UIElementSpec.
    /// </summary>
    /// <param name="uiElementSpec">The UI element specification for the CustomElement.</param>
    /// <returns>A new instance of CustomElement.</returns>
    public CustomElement CustomElement(UIElementSpec uiElementSpec) => new CustomElement(uiDriver, uiElementSpec);

    /// <summary>
    /// Creates a new instance of Image with the specified UIElementSpec.
    /// </summary>
    /// <param name="uiElementSpec">The UI element specification for the Image.</param>
    /// <returns>A new instance of Image.</returns>
    public Image Image(UIElementSpec uiElementSpec) => new Image(uiDriver, uiElementSpec);

    /// <summary>
    /// Creates a new instance of Table with the specified UIElementSpec.
    /// </summary>
    /// <param name="uiElementSpec">The UI element specification for the Table.</param>
    /// <returns>A new instance of Table.</returns>
    public Table Table(UIElementSpec uiElementSpec) => new Table(uiDriver, uiElementSpec);
}
