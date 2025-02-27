public class Table : BaseUIElement<Table>
{
    private readonly IUIDriver uiDriver;
    private readonly UIElementSpec uiElementSpec;

    /// <summary>
    /// Initializes a new instance of the <see cref="Table"/> class.
    /// </summary>
    /// <param name="uiDriver">The UI driver.</param>
    /// <param name="uiElementSpec">The UI element specification.</param>
    internal Table(IUIDriver uiDriver, UIElementSpec uiElementSpec) : base(uiDriver, uiElementSpec)
    {
        this.uiDriver = uiDriver;
        this.uiElementSpec = uiElementSpec;
    }

    /// <summary>
    /// Gets the header of the table.
    /// </summary>
    public Header Header
    {
        get
        {
            uiElementSpec.FindBy.Locator = uiElementSpec.FindBy.Mechanism switch
            {
                FindByType.Css => $"{uiElementSpec.FindBy.Locator} .rt-thead",
                FindByType.Xpath => $"{uiElementSpec.FindBy.Locator}//*[contains(@class,'rt-thead')]",
                FindByType.Id => throw new NotImplementedException(),
                FindByType.Name => throw new NotImplementedException(),
                FindByType.Text => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
            return new Header(uiDriver, uiElementSpec);
        }
    }

    /// <summary>
    /// Gets the body of the table.
    /// </summary>
    public Body Body
    {
        get
        {
            uiElementSpec.FindBy.Locator = uiElementSpec.FindBy.Mechanism switch
            {
                FindByType.Css => $"{uiElementSpec.FindBy.Locator} .rt-tbody",
                FindByType.Xpath => $"{uiElementSpec.FindBy.Locator}//*[contains(@class,'rt-tbody')]",
                FindByType.Id => throw new NotImplementedException(),
                FindByType.Name => throw new NotImplementedException(),
                FindByType.Text => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
            return new Body(uiDriver, uiElementSpec);
        }
    }
}
public class Header(IUIDriver uiDriver, UIElementSpec uiElementSpec) : BaseUIElement<Header>(uiDriver, uiElementSpec)
{
    private readonly IUIDriver uiDriver = uiDriver;
    private readonly UIElementSpec uiElementSpec = uiElementSpec;

    /// <summary>
    /// Gets the specified column in the header.
    /// </summary>
    /// <param name="column">The column number.</param>
    public Column Column(int column)
    {
        uiElementSpec.FindBy.Locator = uiElementSpec.FindBy.Mechanism switch
        {
            FindByType.Css => $"{uiElementSpec.FindBy.Locator} [role='columnheader']:nth-child({column})",
            FindByType.Xpath => $"({uiElementSpec.FindBy.Locator}//*[@role='columnheader'])[{column}]",
            FindByType.Id => throw new NotImplementedException(),
            FindByType.Name => throw new NotImplementedException(),
            FindByType.Text => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
        return new Column(uiDriver, uiElementSpec);
    }
}
public class Body(IUIDriver uiDriver, UIElementSpec uiElementSpec) : BaseUIElement<Body>(uiDriver, uiElementSpec)
{
    private readonly IUIDriver uiDriver = uiDriver;
    private readonly UIElementSpec uiElementSpec = uiElementSpec;

    /// <summary>
    /// Gets the specified row in the body.
    /// </summary>
    /// <param name="row">The row number.</param>
    public Row Row(int row)
    {
        uiElementSpec.FindBy.Locator = uiElementSpec.FindBy.Mechanism switch
        {
            FindByType.Css => $"{uiElementSpec.FindBy.Locator} [role='rowgroup']:nth-child({row})",
            FindByType.Xpath => $"({uiElementSpec.FindBy.Locator}//*[@role='rowgroup'])[{row}]",
            FindByType.Id => throw new NotImplementedException(),
            FindByType.Name => throw new NotImplementedException(),
            FindByType.Text => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
        return new Row(uiDriver, uiElementSpec);
    }

    /// <summary>
    /// Gets the specified cell in the body.
    /// </summary>
    /// <param name="row">The row number.</param>
    /// <param name="column">The column number.</param>
    public Cell Cell(int row, int column)
    {
        uiElementSpec.FindBy.Locator = uiElementSpec.FindBy.Mechanism switch
        {
            FindByType.Css => $"{uiElementSpec.FindBy.Locator}  [role='rowgroup']:nth-child({row}) [role='gridcell']:nth-child({column})",
            FindByType.Xpath => $"(({uiElementSpec.FindBy.Locator}//*[@role='rowgroup'])[{row}]//*[@role='gridcell'])[{column}]",
            FindByType.Id => throw new NotImplementedException(),
            FindByType.Name => throw new NotImplementedException(),
            FindByType.Text => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
        return new Cell(uiDriver, uiElementSpec);
    }
}
public class Row(IUIDriver uiDriver, UIElementSpec uiElementSpec) : BaseUIElement<Row>(uiDriver, uiElementSpec) { }
public class Column(IUIDriver uiDriver, UIElementSpec uiElementSpec) : BaseUIElement<Column>(uiDriver, uiElementSpec) { }
public class Cell(IUIDriver uiDriver, UIElementSpec uiElementSpec) : BaseUIElement<Cell>(uiDriver, uiElementSpec) { }