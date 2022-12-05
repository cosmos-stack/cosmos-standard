using System.Reflection.Emit;

namespace Cosmos.Reflection.Reflectors;

public partial class PropertyReflector
{
    private class CallPropertyReflector : PropertyReflector
    {
        public CallPropertyReflector(PropertyInfo reflectionInfo) : base(reflectionInfo) { }

        protected override Func<object, object> CreateGetter()
        {
            var dynamicMethod = new DynamicMethod($"getter-{Guid.NewGuid()}", typeof(object), new[] { typeof(object) }, _reflectionInfo.Module, true);
            var declaringType = _reflectionInfo.DeclaringType!;
            var ilGen = dynamicMethod.GetILGenerator();
            ilGen.EmitLoadArg(0);
            ilGen.EmitConvertFromObject(declaringType);
            if (declaringType.GetTypeInfo().IsValueType)
            {
                var local = ilGen.DeclareLocal(declaringType);
                ilGen.Emit(OpCodes.Stloc, local);
                ilGen.Emit(OpCodes.Ldloca, local);
            }

            ilGen.Emit(OpCodes.Call, _reflectionInfo.GetMethod!);
            if (_reflectionInfo.PropertyType.GetTypeInfo().IsValueType)
                ilGen.EmitConvertToObject(_reflectionInfo.PropertyType);
            ilGen.Emit(OpCodes.Ret);
            return (Func<object, object>)dynamicMethod.CreateDelegate(typeof(Func<object, object>));
        }

        protected override Action<object, object> CreateSetter()
        {
            var dynamicMethod = new DynamicMethod($"setter-{Guid.NewGuid()}", typeof(void), new[] { typeof(object), typeof(object) }, _reflectionInfo.Module, true);
            var declaringType = _reflectionInfo.DeclaringType!;
            var ilGen = dynamicMethod.GetILGenerator();
            ilGen.EmitLoadArg(0);
            ilGen.EmitConvertFromObject(declaringType);
            if (declaringType.GetTypeInfo().IsValueType)
            {
                var local = ilGen.DeclareLocal(declaringType);
                ilGen.Emit(OpCodes.Stloc, local);
                ilGen.Emit(OpCodes.Ldloca, local);
            }

            ilGen.EmitLoadArg(1);
            ilGen.EmitConvertFromObject(_reflectionInfo.PropertyType);
            ilGen.Emit(OpCodes.Call, _reflectionInfo.SetMethod!);
            ilGen.Emit(OpCodes.Ret);
            return (Action<object, object>)dynamicMethod.CreateDelegate(typeof(Action<object, object>));
        }
    }
}