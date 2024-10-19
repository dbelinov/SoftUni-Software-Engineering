namespace DeskMarket.Common.ValidationConstants;

public static class ProductValidationConstants
{
    public const int NameMinLength = 2;
    public const int NameMaxLength = 60;
    public const int DescriptionMinLength = 10;
    public const int DescriptionMaxLength = 250;
    public const double PriceMinValue = 1.00;
    public const double PriceMaxValue = 3000.00;
    public const string DateFormat = "dd-MM-yyyy";
}