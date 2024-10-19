namespace DeskMarket.Common.ErrorMessages;

public static class ProductErrorMessages
{
    public const string NameRequired = "Product name is required";
    public const string NameLengthError = "Product name should be between 2 and 60 characters";
    public const string DescriptionRequired = "Product description is required";
    public const string DescriptionLengthError = "Product description should be between 10 and 250 characters";
    public const string PriceRequired = "Product price is required";
    public const string PriceRangeError = "Price must be in the range [1.00;3000.00].";
    public const string CategoryRequired = "Category is required";
    public const string AddedDateRequired = "AddedOn Date is required";
}