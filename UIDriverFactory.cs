public class UIDriverFactory
{
    private readonly UIDriverConfigOptions uiDriverConfigOptions;

    /// <summary>
    /// Initializes a new instance of the UIDriverFactory class with the specified UIDriverConfigOptions.
    /// </summary>
    /// <param name="uiDriverConfigOptions">The UIDriverConfigOptions for configuring the UIDriver.</param>
    public UIDriverFactory(UIDriverConfigOptions uiDriverConfigOptions) => this.uiDriverConfigOptions = uiDriverConfigOptions;

    /// <summary>
    /// Initializes a new instance of the UIDriverFactory class with default UIDriverConfigOptions.
    /// </summary>
    public UIDriverFactory() => this.uiDriverConfigOptions = new UIDriverConfigOptions();

    /// <summary>
    /// Creates an instance of IUIDriver based on the configured UIDriverType.
    /// </summary>
    /// <returns>An instance of IUIDriver.</returns>
    public IUIDriver CreateUIDriver() => this.uiDriverConfigOptions.UIDriverSettings.UIDriverType switch
    {
        UIDriverType.Playwright => new PlaywrightUIDriver(uiDriverConfigOptions),
        _ => throw new ArgumentException($"Wrong UIDriverType \'{uiDriverConfigOptions.UIDriverSettings.UIDriverType}\'"),
    };
}
