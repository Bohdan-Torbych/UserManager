namespace UserManager.Core.Extensions;

public static class DateOnlyExtensions
{
    public static int GetAge(this DateOnly date)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var age = today.Year - date.Year;
        if (date > today.AddYears(-age)) age--;

        return age;
    }
}