using System.Reflection.Emit;

// ReSharper disable VirtualMemberCallInConstructor

namespace Cosmos.Reflection.Reflectors;

public partial class PropertyReflector : MemberReflector<PropertyInfo>
{
    protected readonly Func<object, object> _getter;
    protected readonly Action<object, object> _setter;

    private PropertyReflector(PropertyInfo reflectionInfo) : base(reflectionInfo)
    {
        _getter = reflectionInfo.CanRead ? CreateGetter() : _ => throw new InvalidOperationException($"Property {_reflectionInfo.Name} does not define get accessor.");
        _setter = reflectionInfo.CanWrite ? CreateSetter() : (_, _) => throw new InvalidOperationException($"Property {_reflectionInfo.Name} does not define get accessor.");
    }

    protected virtual Func<object, object> CreateGetter()
    {
        var dynamicMethod = new DynamicMethod($"getter-{Guid.NewGuid()}", typeof(object), new[] { typeof(object) }, _reflectionInfo.Module, true);
        var ilGen = dynamicMethod.GetILGenerator();
        ilGen.EmitLoadArg(0);
        ilGen.EmitConvertFromObject(_reflectionInfo.DeclaringType!);
        ilGen.Emit(OpCodes.Callvirt, _reflectionInfo.GetMethod!);
        if (_reflectionInfo.PropertyType.GetTypeInfo().IsValueType)
            ilGen.EmitConvertToObject(_reflectionInfo.PropertyType);
        ilGen.Emit(OpCodes.Ret);
        return (Func<object, object>)dynamicMethod.CreateDelegate(typeof(Func<object, object>));
    }

    protected virtual Action<object, object> CreateSetter()
    {
        var dynamicMethod = new DynamicMethod($"setter-{Guid.NewGuid()}", typeof(void), new[] { typeof(object), typeof(object) }, _reflectionInfo.Module, true);
        var ilGen = dynamicMethod.GetILGenerator();
        ilGen.EmitLoadArg(0);
        ilGen.EmitConvertFromObject(_reflectionInfo.DeclaringType!);
        ilGen.EmitLoadArg(1);
        ilGen.EmitConvertFromObject(_reflectionInfo.PropertyType);
        ilGen.Emit(OpCodes.Callvirt, _reflectionInfo.SetMethod!);
        ilGen.Emit(OpCodes.Ret);
        return (Action<object, object>)dynamicMethod.CreateDelegate(typeof(Action<object, object>));
    }

    public virtual object GetValue(object instance)
        => instance is null ? throw new ArgumentNullException(nameof(instance)) : _getter.Invoke(instance);

    public virtual void SetValue(object instance, object value)
    {
        ArgumentNullException.ThrowIfNull(instance);
        _setter(instance, value);
    }

    public virtual object GetStaticValue()
        => throw new InvalidOperationException($"Property {_reflectionInfo.Name} must be static to call this method. For get instance property value, call 'GetValue'.");


    public virtual void SetStaticValue(object value)
        => throw new InvalidOperationException($"Property {_reflectionInfo.Name} must be static to call this method. For set instance property value, call 'SetValue'.");
}