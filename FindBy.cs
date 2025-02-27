public class FindBy
{
    /// <summary>
    /// Gets or sets the mechanism used for locating an element.
    /// </summary>
    public FindByType Mechanism { get; set; }

    /// <summary>
    /// Gets or sets the locator value used for locating an element.
    /// </summary>
    public string Locator { get; set; }

    /// <summary>
    /// Initializes a new instance of the FindBy class with the specified mechanism and locator.
    /// </summary>
    /// <param name="mechanism">The mechanism used for locating an element.</param>
    /// <param name="locator">The locator value used for locating an element.</param>
    protected FindBy(FindByType mechanism, string locator)
    {
        Mechanism = mechanism;
        Locator = locator;
    }

    /// <summary>
    /// Creates a new FindBy instance with the specified CSS locator.
    /// </summary>
    /// <param name="locator">The CSS locator used for locating an element.</param>
    /// <returns>A FindBy instance with the specified CSS locator.</returns>
    public static FindBy Css(string locator) => new FindBy(FindByType.Css, locator);

    /// <summary>
    /// Creates a new FindBy instance with the specified XPath locator.
    /// </summary>
    /// <param name="locator">The XPath locator used for locating an element.</param>
    /// <returns>A FindBy instance with the specified XPath locator.</returns>
    public static FindBy Xpath(string locator) => new FindBy(FindByType.Xpath, locator);

    /// <summary>
    /// Creates a new FindBy instance with the specified ID locator.
    /// </summary>
    /// <param name="locator">The ID locator used for locating an element.</param>
    /// <returns>A FindBy instance with the specified ID locator.</returns>
    public static FindBy Id(string locator) => new FindBy(FindByType.Id, locator);

    /// <summary>
    /// Creates a new FindBy instance with the specified name locator.
    /// </summary>
    /// <param name="locator">The name locator used for locating an element.</param>
    /// <returns>A FindBy instance with the specified name locator.</returns>
    public static FindBy Name(string locator) => new FindBy(FindByType.Name, locator);

    /// <summary>
    /// Creates a new FindBy instance with the specified text locator.
    /// </summary>
    /// <param name="locator">The text locator used for locating an element.</param>
    /// <returns>A FindBy instance with the specified text locator.</returns>
    public static FindBy Text(string locator) => new FindBy(FindByType.Text, locator);
}
