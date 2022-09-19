namespace Tidsbanken_Backend.Services;

/// <summary>
/// This class helps to avoid misspelling of the string values which determine a vacationRequest's status.
/// </summary>
public static class StatusHelper
{
    public const string Pending = "Pending";
    public const string Approved = "Approved";
    public const string Denied = "Denied";

    /// <summary>
    /// Check whether the given status is spelled correctly.
    /// </summary>
    public static bool IsValidStatus(string status)
    {
        return status switch
        {
            Pending => true,
            Approved => true,
            Denied => true,
            _ => false,
        };
    }
}
