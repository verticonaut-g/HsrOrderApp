using System.ComponentModel;

namespace HsrOrderApp.SharedLibraries.SharedEnums
{
    public enum CreditRating : int
    {
        [Description("Superior")]
        Superior,

        [Description("Excellent")]
        Excellent,

        [Description("AboveAverage")]
        AboveAverage,

        [Description("Average")]
        Average,

        [Description("BelowAverage")]
        BelowAverage
    }
}
