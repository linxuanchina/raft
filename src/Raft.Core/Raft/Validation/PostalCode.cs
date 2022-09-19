using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Raft.Validation;

[PublicAPI]
public static class PostalCode
{
    public const string Pattern = @"^[1-9]\d{5}(?!\d)$";

    public static bool IsMatch(string text, RegexOptions options = RegexOptions.None) =>
        Check.NotNullOrEmpty(text, nameof(text)).IsMatch(Pattern, options);
}
