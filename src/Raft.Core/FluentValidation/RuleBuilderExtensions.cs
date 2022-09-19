using Raft;
using JetBrains.Annotations;
using System.Text.RegularExpressions;

namespace FluentValidation;

[PublicAPI]
public static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, string?> SingleLineMatches<T>(this IRuleBuilder<T, string?> @this,
        string pattern)
    {
        IRuleBuilder<T, string?> builder;
        builder = Check.NotNull(@this, nameof(builder));
        return builder.Matches(Check.NotNullOrEmpty(pattern, nameof(pattern)), RegexOptions.Singleline);
    }

    public static IRuleBuilderOptions<T, string?> PhoneNumber<T>(this IRuleBuilder<T, string?> @this) =>
        SingleLineMatches(@this, Raft.Validation.PhoneNumber.Pattern);


    public static IRuleBuilderOptions<T, string?> PostalCode<T>(this IRuleBuilder<T, string?> @this) =>
        SingleLineMatches(@this, Raft.Validation.PostalCode.Pattern);

    public static IRuleBuilderOptions<T, string?> PlateNumber<T>(this IRuleBuilder<T, string?> @this) =>
        SingleLineMatches(@this, Raft.Validation.PlateNumber.Pattern);
}
