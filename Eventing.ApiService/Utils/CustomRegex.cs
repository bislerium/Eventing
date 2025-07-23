using System.Text.RegularExpressions;

namespace Eventing.ApiService.Utils;

public partial class CustomRegex
{
    public const string FullNameRegexPattern = @"^[\p{L}]+([ '-\.][\p{L}]+)*$";
    [GeneratedRegex(FullNameRegexPattern)]
    public static partial Regex FullNameRegex();
    public const string FullNameRegexErrorMessage = "Please specify a full name.";
    
}