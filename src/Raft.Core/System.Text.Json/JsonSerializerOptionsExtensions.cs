using System.Text.Json.Serialization;
using Raft;
using Raft.Json;
using JetBrains.Annotations;

namespace System.Text.Json;

[PublicAPI]
public static class JsonSerializerOptionsExtensions
{
    public static JsonSerializerOptions AddConverter(this JsonSerializerOptions @this, JsonConverter converter)
    {
        JsonSerializerOptions options;
        options = Check.NotNull(@this, nameof(options));
        options.Converters.AddIfNotContains(Check.NotNull(converter, nameof(converter)));
        return options;
    }

    public static JsonSerializerOptions AddConverter<T>(this JsonSerializerOptions @this)
        where T : JsonConverter, new() => AddConverter(@this, new T());

    public static JsonSerializerOptions AddLongEpochTimeConverter(this JsonSerializerOptions @this) =>
        AddConverter<LongEpochTimeConverter>(@this);

    public static JsonSerializerOptions AddEpochTimeConverter(this JsonSerializerOptions @this) =>
        AddConverter<EpochTimeConverter>(@this);

    public static JsonSerializerOptions AddGuidConverter(this JsonSerializerOptions @this) =>
        AddConverter<GuidConverter>(@this);
}
