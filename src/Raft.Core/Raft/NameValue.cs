using JetBrains.Annotations;

namespace Raft;

[PublicAPI]
public sealed record NameValue<T>
{
    public NameValue(string name, T value)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        Value = value;
    }

    public string Name { get; }

    public T Value { get; }
}
