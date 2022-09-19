using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Raft.Validation;

[PublicAPI]
public static class PlateNumber
{
    public const string Pattern = @"^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}[A-Z0-9]{4}[A-Z0-9挂学警港澳]{1}$";

    public static bool IsMatch(string text, RegexOptions options = RegexOptions.None) =>
        Check.NotNullOrEmpty(text, nameof(text)).IsMatch(Pattern, options);
}
