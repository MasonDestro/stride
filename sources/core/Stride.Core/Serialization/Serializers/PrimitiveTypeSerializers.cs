// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
#pragma warning disable SA1402 // File may only contain a single class
#pragma warning disable SA1649 // File name must match first type name

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Stride.Core.Reflection;

namespace Stride.Core.Serialization.Serializers;

/// <summary>
/// Data serializer for string.
/// </summary>
[DataSerializerGlobal(typeof(UriSerializer))]
public class UriSerializer : DataSerializer<Uri>
{
    /// <inheritdoc/>
    public override void Serialize(ref Uri obj, ArchiveMode mode, SerializationStream stream)
    {
        if (mode == ArchiveMode.Serialize)
        {
            var text = obj.ToString();
            stream.Serialize(ref text);
        }
        else
        {
            string text = null!;
            stream.Serialize(ref text);
            obj = new Uri(text);
        }
    }
}

/// <summary>
/// Data serializer for string.
/// </summary>
[DataSerializerGlobal(typeof(StringSerializer))]
public class StringSerializer : DataSerializer<string>
{
    /// <inheritdoc/>
    public override void Serialize(ref string obj, ArchiveMode mode, SerializationStream stream)
    {
        stream.Serialize(ref obj);
    }
}

/// <summary>
/// Data serializer for bool.
/// </summary>
[DataSerializerGlobal(typeof(BoolSerializer))]
public class BoolSerializer : DataSerializer<bool>
{
    /// <inheritdoc/>
    public override void Serialize(ref bool obj, ArchiveMode mode, SerializationStream stream)
    {
        stream.Serialize(ref obj);
    }
}

/// <summary>
/// Data serializer for float.
/// </summary>
[DataSerializerGlobal(typeof(SingleSerializer))]
public class SingleSerializer : DataSerializer<float>
{
    /// <inheritdoc/>
    public override bool IsBlittable => true;

    /// <inheritdoc/>
    public override void Serialize(ref float obj, ArchiveMode mode, SerializationStream stream)
    {
        stream.Serialize(ref obj);
    }
}

/// <summary>
/// Data serializer for double.
/// </summary>
[DataSerializerGlobal(typeof(DoubleSerializer))]
public class DoubleSerializer : DataSerializer<double>
{
    /// <inheritdoc/>
    public override bool IsBlittable => true;

    /// <inheritdoc/>
    public override void Serialize(ref double obj, ArchiveMode mode, SerializationStream stream)
    {
        stream.Serialize(ref obj);
    }
}

/// <summary>
/// Data serializer for char.
/// </summary>
[DataSerializerGlobal(typeof(CharSerializer))]
public class CharSerializer : DataSerializer<char>
{
    /// <inheritdoc/>
    public override void Serialize(ref char obj, ArchiveMode mode, SerializationStream stream)
    {
        stream.Serialize(ref obj);
    }
}

/// <summary>
/// Data serializer for byte.
/// </summary>
[DataSerializerGlobal(typeof(ByteSerializer))]
public class ByteSerializer : DataSerializer<byte>
{
    /// <inheritdoc/>
    public override bool IsBlittable => true;

    /// <inheritdoc/>
    public override void Serialize(ref byte obj, ArchiveMode mode, SerializationStream stream)
    {
        stream.Serialize(ref obj);
    }
}

/// <summary>
/// Data serializer for sbyte.
/// </summary>
[DataSerializerGlobal(typeof(SByteSerializer))]
public class SByteSerializer : DataSerializer<sbyte>
{
    /// <inheritdoc/>
    public override bool IsBlittable => true;

    /// <inheritdoc/>
    public override void Serialize(ref sbyte obj, ArchiveMode mode, SerializationStream stream)
    {
        stream.Serialize(ref obj);
    }
}

/// <summary>
/// Data serializer for short.
/// </summary>
[DataSerializerGlobal(typeof(Int16Serializer))]
public class Int16Serializer : DataSerializer<short>
{
    /// <inheritdoc/>
    public override bool IsBlittable => true;

    /// <inheritdoc/>
    public override void Serialize(ref short obj, ArchiveMode mode, SerializationStream stream)
    {
        stream.Serialize(ref obj);
    }
}

/// <summary>
/// Data serializer for ushort.
/// </summary>
[DataSerializerGlobal(typeof(UInt16Serializer))]
public class UInt16Serializer : DataSerializer<ushort>
{
    /// <inheritdoc/>
    public override bool IsBlittable => true;

    /// <inheritdoc/>
    public override void Serialize(ref ushort obj, ArchiveMode mode, SerializationStream stream)
    {
        stream.Serialize(ref obj);
    }
}

/// <summary>
/// Data serializer for int.
/// </summary>
[DataSerializerGlobal(typeof(Int32Serializer))]
public class Int32Serializer : DataSerializer<int>
{
    /// <inheritdoc/>
    public override bool IsBlittable => true;

    /// <inheritdoc/>
    public override void Serialize(ref int obj, ArchiveMode mode, SerializationStream stream)
    {
        stream.Serialize(ref obj);
    }
}

/// <summary>
/// Data serializer for uint.
/// </summary>
[DataSerializerGlobal(typeof(UInt32Serializer))]
public class UInt32Serializer : DataSerializer<uint>
{
    /// <inheritdoc/>
    public override bool IsBlittable => true;

    /// <inheritdoc/>
    public override void Serialize(ref uint obj, ArchiveMode mode, SerializationStream stream)
    {
        stream.Serialize(ref obj);
    }
}

/// <summary>
/// Data serializer for long.
/// </summary>
[DataSerializerGlobal(typeof(Int64Serializer))]
public class Int64Serializer : DataSerializer<long>
{
    /// <inheritdoc/>
    public override bool IsBlittable => true;

    /// <inheritdoc/>
    public override void Serialize(ref long obj, ArchiveMode mode, SerializationStream stream)
    {
        stream.Serialize(ref obj);
    }
}

/// <summary>
/// Data serializer for ulong.
/// </summary>
[DataSerializerGlobal(typeof(UInt64Serializer))]
public class UInt64Serializer : DataSerializer<ulong>
{
    /// <inheritdoc/>
    public override bool IsBlittable => true;

    /// <inheritdoc/>
    public override void Serialize(ref ulong obj, ArchiveMode mode, SerializationStream stream)
    {
        stream.Serialize(ref obj);
    }
}

/// <summary>
/// Data serializer for Enum.
/// </summary>
public class EnumSerializer : DataSerializer<Enum>
{
    /// <inheritdoc/>
    public override void Serialize(ref Enum obj, ArchiveMode mode, SerializationStream stream)
    {
        if (mode == ArchiveMode.Serialize)
        {
            stream.Write(obj != null ? obj.GetType().AssemblyQualifiedName! : string.Empty);
            stream.Write(Convert.ToInt32(obj));
        }
        else if (mode == ArchiveMode.Deserialize)
        {
            var type = AssemblyRegistry.GetType(stream.ReadString());
            var value = stream.ReadInt32();
            if (type != null)
                obj = (Enum)Enum.ToObject(type, value);
        }
    }
}

/// <summary>
/// Data serializer for typed enum.
/// </summary>
public unsafe class EnumSerializer<T> : DataSerializer<T> where T : struct
{
    private int enumSize;

    public override void Initialize(SerializerSelector serializerSelector)
    {
        // Use Marshal SizeOf to avoid AOT issues on iOS
        enumSize = Marshal.SizeOf(Enum.GetUnderlyingType(typeof(T)));
    }

    /// <inheritdoc/>
    public override void Serialize(ref T obj, ArchiveMode mode, SerializationStream stream)
    {
        // For now, 1 and 2 bytes enum are stored as 4 bytes for previous binary compatibility.
        // Future, 2 choices if we decide to drop it and have more compact formats for small enum:
        // - Dump as-is from/to memory (not so resistant to structure size changes)
        // - Use 7bit encoded integer
        switch (enumSize)
        {
            case 1:
            {
                ref var @ref = ref Unsafe.As<T, byte>(ref obj);
                uint value = @ref;
                stream.Serialize(ref value);
                @ref = (byte)value;
                break;
            }
            case 2:
            {
                ref var @ref = ref Unsafe.As<T, ushort>(ref obj);
                uint value = @ref;
                stream.Serialize(ref value);
                @ref = (ushort)value;
                break;
            }
            case 4:
            {
                ref var @ref = ref Unsafe.As<T, uint>(ref obj);
                stream.Serialize(ref @ref);
                break;
            }
            case 8:
            {
                ref var @ref = ref Unsafe.As<T, ulong>(ref obj);
                stream.Serialize(ref @ref);
                break;
            }
            default:
                throw new InvalidOperationException();
        }
    }
}

/// <summary>
/// Data serializer for Guid.
/// </summary>
[DataSerializerGlobal(typeof(GuidSerializer))]
public class GuidSerializer : DataSerializer<Guid>
{
    /// <inheritdoc/>
    public override bool IsBlittable => true;

    /// <inheritdoc/>
    public override void Serialize(ref Guid obj, ArchiveMode mode, SerializationStream stream)
    {
        if (mode == ArchiveMode.Serialize || mode == ArchiveMode.Deserialize) {
            var span = MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref obj, 1));
            stream.Serialize(span);
        }
    }
}

/// <summary>
/// Data serializer for TimeSpan.
/// </summary>
[DataSerializerGlobal(typeof(TimeSpanSerializer))]
public class TimeSpanSerializer : DataSerializer<TimeSpan>
{
    public override void Serialize(ref TimeSpan timeSpan, ArchiveMode mode, SerializationStream stream)
    {
        if (mode == ArchiveMode.Serialize)
        {
            stream.Write(timeSpan.Ticks);
        }
        else if (mode == ArchiveMode.Deserialize)
        {
            timeSpan = new TimeSpan(stream.ReadInt64());
        }
    }
}

[DataSerializerGlobal(typeof(DateTimeSerializer))]
public class DateTimeSerializer : DataSerializer<DateTime>
{
    public override void Serialize(ref DateTime dateTime, ArchiveMode mode, SerializationStream stream)
    {
        if (mode == ArchiveMode.Serialize)
        {
            stream.Write(dateTime.Ticks);
        }
        else if (mode == ArchiveMode.Deserialize)
        {
            dateTime = new DateTime(stream.ReadInt64());
        }
    }
}
