using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DaintStudio.Services.Common;

public static class DateExtensions
{

    public static DateTime ToVnDatetime(this DateTime input)
    {
        return input.AddHours(7);
    }

}
public static class StringExtensions
{

    public static decimal ToDaintDecimal(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return 0m;

        if (decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            return result;

        string fixedInput = input.Contains(",") ? input.Replace(",", ".") : input.Replace(".", ",");
        if (decimal.TryParse(fixedInput, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            return result;

        throw new FormatException($"Không thể parse '{input}' thành decimal.");
    }

    public static bool IsNumber(this string input)
    {
        return decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
    }

}
