﻿using System.Reflection.Emit;

namespace Cosmos.Reflection.Reflectors;

// ReSharper disable once RedundantExtendsListEntry
public partial class FieldReflector : MemberReflector<FieldInfo>
{
    private class StaticFieldReflector : FieldReflector
    {
        public StaticFieldReflector(FieldInfo reflectionInfo) : base(reflectionInfo) { }

        protected override Func<object, object> CreateGetter()
        {
            var dynamicMethod = new DynamicMethod($"getter-{Guid.NewGuid()}", typeof(object), new[] { typeof(object) }, _reflectionInfo.Module, true);
            var ilGen = dynamicMethod.GetILGenerator();
            ilGen.Emit(OpCodes.Ldsfld, _reflectionInfo);
            ilGen.EmitConvertToObject(_reflectionInfo.FieldType);
            ilGen.Emit(OpCodes.Ret);
            return (Func<object, object>)dynamicMethod.CreateDelegate(typeof(Func<object, object>));
        }

        protected override Action<object, object> CreateSetter()
        {
            var dynamicMethod = new DynamicMethod($"setter-{Guid.NewGuid()}", typeof(void), new[] { typeof(object), typeof(object) }, _reflectionInfo.Module, true);
            var ilGen = dynamicMethod.GetILGenerator();
            ilGen.EmitLoadArg(1);
            ilGen.EmitConvertFromObject(_reflectionInfo.FieldType);
            ilGen.Emit(OpCodes.Stsfld, _reflectionInfo);
            ilGen.Emit(OpCodes.Ret);
            return (Action<object, object>)dynamicMethod.CreateDelegate(typeof(Action<object, object>));
        }

        public override object GetValue(object instance) => _getter(null!);

        public override void SetValue(object instance, object value) => _setter(null!, value);

        public override object GetStaticValue() => _getter(null!);

        public override void SetStaticValue(object value) => _setter(null!, value);
    }
}