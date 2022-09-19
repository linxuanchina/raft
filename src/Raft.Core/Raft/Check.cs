using JetBrains.Annotations;

namespace Raft;

[PublicAPI]
public static class Check
{
    public static T NotNull<T>(T obj, [InvokerParameterName] string paramName) where T : class
    {
        if (obj.IsNull())
        {
            throw new ArgumentNullException(paramName);
        }

        return obj;
    }

    public static T NotNull<T>(T obj, [InvokerParameterName] string paramName, [InvokerParameterName] string message)
        where T : class
    {
        if (obj.IsNull())
        {
            throw new ArgumentNullException(paramName, message);
        }

        return obj;
    }

    public static ICollection<T> NotNullOrEmpty<T>(ICollection<T> obj, [InvokerParameterName] string paramName)
    {
        if (obj.IsNullOrEmpty())
        {
            throw new ArgumentException($"{paramName} can not be null or empty", paramName);
        }

        return obj;
    }

    public static Type AssignableTo<T>(
        Type obj,
        [InvokerParameterName] string paramName)
    {
        if (obj.IsNull())
        {
            throw new ArgumentNullException(paramName);
        }

        var baseType = typeof(T);

        if (obj.IsAssignableTo(baseType))
        {
            return obj;
        }

        throw new ArgumentException(
            $"{paramName} (type of {obj.AssemblyQualifiedName}) should be assignable to the {baseType.AssemblyQualifiedName}");
    }

    public static T NotDefault<T>(T obj, [InvokerParameterName] string paramName)
    {
        if (obj.IsDefault())
        {
            throw new ArgumentException($"{paramName} has a default value", paramName);
        }

        return obj;
    }

    public static Guid NotEmpty(Guid obj, [InvokerParameterName] string paramName)
    {
        if (obj.IsEmpty())
        {
            throw new ArgumentException($"{paramName} can not be empty", paramName);
        }

        return obj;
    }

    public static string NotNull(string obj, [InvokerParameterName] string paramName,
        [NonNegativeValue] int maxLength = int.MaxValue, [NonNegativeValue] int minLength = 0)
    {
        if (obj.IsNull())
        {
            throw new ArgumentException($"{paramName} can not be null", paramName);
        }

        if (obj.Length > maxLength)
        {
            throw new ArgumentException($"{paramName} length must be equal to or lower than {maxLength}", paramName);
        }

        if (minLength > 0 && obj.Length < minLength)
        {
            throw new ArgumentException($"{paramName} length must be equal to or bigger than {minLength}",
                paramName);
        }

        return obj;
    }

    public static string NotNullOrEmpty(string obj, [InvokerParameterName] string paramName,
        [NonNegativeValue] int maxLength = int.MaxValue, [NonNegativeValue] int minLength = 0)
    {
        if (obj.IsNullOrEmpty())
        {
            throw new ArgumentException($"{paramName} can not be null or empty", paramName);
        }

        if (obj.Length > maxLength)
        {
            throw new ArgumentException($"{paramName} length must be equal to or lower than {maxLength}", paramName);
        }

        if (minLength > 0 && obj.Length < minLength)
        {
            throw new ArgumentException($"{paramName} length must be equal to or bigger than {minLength}",
                paramName);
        }

        return obj;
    }

    public static string NotNullOrWhiteSpace(string obj, [InvokerParameterName] string paramName,
        [NonNegativeValue] int maxLength = int.MaxValue, [NonNegativeValue] int minLength = 0)
    {
        if (obj.IsNullOrWhiteSpace())
        {
            throw new ArgumentException($"{paramName} can not be null or whitespace", paramName);
        }

        if (obj.Length > maxLength)
        {
            throw new ArgumentException($"{paramName} length must be equal to or lower than {maxLength}", paramName);
        }

        if (minLength > 0 && obj.Length < minLength)
        {
            throw new ArgumentException($"{paramName} length must be equal to or bigger than {minLength}",
                paramName);
        }

        return obj;
    }

    public static string Length(string obj, [InvokerParameterName] string paramName,
        [NonNegativeValue] int maxLength, [NonNegativeValue] int minLength = 0)
    {
        if (minLength > 0)
        {
            if (obj.IsNullOrEmpty())
            {
                throw new ArgumentException($"{paramName} can not be null or empty", paramName);
            }

            if (obj.Length < minLength)
            {
                throw new ArgumentException($"{paramName} length must be equal to or bigger than {minLength}",
                    paramName);
            }
        }

        if (obj.IsNotNull() && obj.Length > maxLength)
        {
            throw new ArgumentException($"{paramName} length must be equal to or lower than {maxLength}", paramName);
        }

        return obj;
    }

    public static short Range(short obj, [InvokerParameterName] string paramName, short minimum,
        short maximum = short.MaxValue)
    {
        if (obj.InRange(minimum, maximum))
        {
            return obj;
        }

        throw new ArgumentException($"{paramName} is out of range min: {minimum} - max: {maximum}", paramName);
    }

    public static int Range(int obj, [InvokerParameterName] string paramName, int minimum,
        int maximum = int.MaxValue)
    {
        if (obj.InRange(minimum, maximum))
        {
            return obj;
        }

        throw new ArgumentException($"{paramName} is out of range min: {minimum} - max: {maximum}", paramName);
    }

    public static long Range(long obj, [InvokerParameterName] string paramName, long minimum,
        long maximum = long.MaxValue)
    {
        if (obj.InRange(minimum, maximum))
        {
            return obj;
        }

        throw new ArgumentException($"{paramName} is out of range min: {minimum} - max: {maximum}", paramName);
    }

    public static decimal Range(decimal obj, [InvokerParameterName] string paramName, decimal minimum,
        decimal maximum = decimal.MaxValue)
    {
        if (obj.InRange(minimum, maximum))
        {
            return obj;
        }

        throw new ArgumentException($"{paramName} is out of range min: {minimum} - max: {maximum}", paramName);
    }

    public static float Range(float obj, [InvokerParameterName] string paramName, float minimum,
        float maximum = float.MaxValue)
    {
        if (obj.InRange(minimum, maximum))
        {
            return obj;
        }

        throw new ArgumentException($"{paramName} is out of range min: {minimum} - max: {maximum}", paramName);
    }

    public static double Range(double obj, [InvokerParameterName] string paramName, double minimum,
        double maximum = double.MaxValue)
    {
        if (obj.InRange(minimum, maximum))
        {
            return obj;
        }

        throw new ArgumentException($"{paramName} is out of range min: {minimum} - max: {maximum}", paramName);
    }

    public static short Positive(
        short obj,
        [InvokerParameterName] string paramName)
    {
        if (obj == 0)
        {
            throw new ArgumentException($"{paramName} is equal to zero");
        }

        if (obj < 0)
        {
            throw new ArgumentException($"{paramName} is less than zero");
        }

        return obj;
    }

    public static int Positive(
        int obj,
        [InvokerParameterName] string paramName)
    {
        if (obj == 0)
        {
            throw new ArgumentException($"{paramName} is equal to zero");
        }

        if (obj < 0)
        {
            throw new ArgumentException($"{paramName} is less than zero");
        }

        return obj;
    }

    public static long Positive(
        long obj,
        [InvokerParameterName] string paramName)
    {
        if (obj == 0)
        {
            throw new ArgumentException($"{paramName} is equal to zero");
        }

        if (obj < 0)
        {
            throw new ArgumentException($"{paramName} is less than zero");
        }

        return obj;
    }

    public static decimal Positive(
        decimal obj,
        [InvokerParameterName] string paramName)
    {
        if (obj == 0)
        {
            throw new ArgumentException($"{paramName} is equal to zero");
        }

        if (obj < 0)
        {
            throw new ArgumentException($"{paramName} is less than zero");
        }

        return obj;
    }

    public static float Positive(
        float obj,
        [InvokerParameterName] string paramName)
    {
        if (obj == 0)
        {
            throw new ArgumentException($"{paramName} is equal to zero");
        }

        if (obj < 0)
        {
            throw new ArgumentException($"{paramName} is less than zero");
        }

        return obj;
    }

    public static double Positive(
        double obj,
        [InvokerParameterName] string paramName)
    {
        if (obj == 0)
        {
            throw new ArgumentException($"{paramName} is equal to zero");
        }

        if (obj < 0)
        {
            throw new ArgumentException($"{paramName} is less than zero");
        }

        return obj;
    }
}
