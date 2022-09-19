using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Raft.Validation;

[PublicAPI]
public static class PhoneNumber
{
    public const string Pattern = @"^(0|86|17951)?(13[0-9]|15[012356789]|166|17[3678]|18[0-9]|14[57])[0-9]{8}$";

    public static bool IsMatch(string text, RegexOptions options = RegexOptions.None) =>
        Check.NotNullOrEmpty(text, nameof(text)).IsMatch(Pattern, options);
}
