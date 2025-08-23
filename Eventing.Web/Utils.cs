namespace Eventing.Web;

public static class Utils
{
    public static string GetInitials(string fullName, int maxInitials = 3)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return string.Empty;

        var words = fullName.Trim()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Take first letter of each word
        var initials = words.Select(w => char.ToUpper(w[0]));

        // Limit to maxInitials
        return new string(initials.Take(maxInitials).ToArray());
    }
}