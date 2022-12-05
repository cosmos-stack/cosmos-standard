using System.Reflection.Emit;

// ReSharper disable VirtualMemberCallInConstructor

namespace Cosmos.Reflection.Reflectors;

// ReSharper disable once RedundantExtendsListEntry
public partial class FieldReflector : MemberReflector<FieldInfo>
{
    protected readonly Func<object, object> _getter;
    protected readonly Action<object, object> _setter;

    protected FieldReflector(FieldInfo reflectionInfo) : base(reflectionInfo)
    {
        _getter = CreateGetter();
        _setter = CreateSetter();
    }

    protected virtual Func<object, object> CreateGetter()
    {
        var dynamicMethod = new DynamicMethod($"getter-{Guid.NewGuid()}", typeof(object), new[] { typeof(object) }, _reflectionInfo.Module, true);
        var ilGen = dynamicMethod.GetILGenerator();
        ilGen.EmitLoadArg(0);
        ilGen.EmitConvertFromObject(_reflectionInfo.DeclaringType!);
        ilGen.Emit(OpCodes.Ldfld, _reflectionInfo);
        ilGen.EmitConvertToObject(_reflectionInfo.FieldType);
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
        ilGen.EmitConvertFromObject(_reflectionInfo.FieldType);
        ilGen.Emit(OpCodes.Stfld, _reflectionInfo);
        ilGen.Emit(OpCodes.Ret);
        return (Action<object, object>)dynamicMethod.CreateDelegate(typeof(Action<object, object>));
    }

    public virtual object GetValue(object instance)
    {
        ArgumentNullException.ThrowIfNull(instance);
        return _getter(instance);
    }

    public virtual void SetValue(object instance, object value)
    {
        ArgumentNullException.ThrowIfNull(instance);
        _setter(instance, value);
    }

    public virtual object GetStaticValue()
        => throw new InvalidOperationException($"Field {_reflectionInfo.Name} must be static to call this method. For get instance field value, call 'GetValue'.");

    public virtual void SetStaticValue(object value)
        => throw new InvalidOperationException($"Field {_reflectionInfo.Name} must be static to call this method. For set instance field value, call 'SetValue'.");
}