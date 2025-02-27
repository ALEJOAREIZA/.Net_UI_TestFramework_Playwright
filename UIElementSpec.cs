/// <summary>
/// Initializes a new instance of the UIElementSpec class with the specified name and FindBy.
/// </summary>
/// <param name="name">The name of the UI element.</param>
/// <param name="findBy">The FindBy object defining the method and locator for finding the UI element.</param>
public class UIElementSpec(string name, FindBy findBy)
{
    /// <summary>
    /// Gets or sets the name of the UI element.
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// Gets or sets the method and locator used to find the UI element.
    /// </summary>
    public FindBy FindBy { get; set; } = findBy;
}
