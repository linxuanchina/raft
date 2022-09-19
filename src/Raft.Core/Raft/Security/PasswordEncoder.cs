namespace Raft.Security;

public static class PasswordEncoder
{
    public static string Encode(string rawPassword) =>
        BCrypt.Net.BCrypt.HashPassword(Check.NotNullOrEmpty(rawPassword, nameof(rawPassword)));

    public static bool Matches(string rawPassword, string encodedPassword) => BCrypt.Net.BCrypt.Verify(
        Check.NotNullOrEmpty(rawPassword, nameof(rawPassword)),
        Check.NotNullOrEmpty(encodedPassword, nameof(encodedPassword)));
}
