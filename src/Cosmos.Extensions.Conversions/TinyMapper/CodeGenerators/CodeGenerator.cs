using System;
using System.Reflection;
using System.Reflection.Emit;
using Cosmos.Reflection;
using TinyMapper.CodeGenerators.Emitters;
using TinyMapper.Core;
using TinyMapper.Core.Extensions;

namespace TinyMapper.CodeGenerators
{
    internal sealed class CodeGenerator
    {
        private readonly ILGenerator _ilGenerator;

        public CodeGenerator(ILGenerator ilGenerator)
        {
            _ilGenerator = ilGenerator;
        }

        public CodeGenerator CastType(Type stackType, Type targetType)
        {
            if (stackType == targetType)
            {
                return this;
            }

            if (Types.IsValueType(stackType) == false && targetType == typeof(object))
            {
                return this;
            }

            if (Types.IsValueType(stackType) && !Types.IsValueType(targetType))
            {
                _ilGenerator.Emit(OpCodes.Box, stackType);
            }
            else if (!Types.IsValueType(stackType) && Types.IsValueType(targetType))
            {
                _ilGenerator.Emit(OpCodes.Unbox_Any, targetType);
            }
            else
            {
                _ilGenerator.Emit(OpCodes.Castclass, targetType);
            }

            return this;
        }

        public LocalBuilder DeclareLocal(Type type)
        {
            return _ilGenerator.DeclareLocal(type);
        }

        public void Emit(OpCode opCode)
        {
            _ilGenerator.Emit(opCode);
        }

        public void Emit(OpCode opCode, int value)
        {
            _ilGenerator.Emit(opCode, value);
        }

        public void Emit(OpCode opCode, Type value)
        {
            _ilGenerator.Emit(opCode, value);
        }

        public void Emit(OpCode opCode, FieldInfo value)
        {
            _ilGenerator.Emit(opCode, value);
        }

        public void EmitCall(MethodInfo method, IEmitterType invocationObject, params IEmitterType[] arguments)
        {
            ParameterInfo[] actualArguments = method.GetParameters();
            if (arguments.IsNull())
            {
                arguments = new IEmitterType[0];
            }

            if (arguments.Length != actualArguments.Length)
            {
                throw new ArgumentException();
            }

            if (invocationObject.IsNotNull())
            {
                invocationObject.Emit(this);
            }

            for (var i = 0; i < arguments.Length; i++)
            {
                arguments[i].Emit(this);
                CastType(arguments[i].ObjectType, actualArguments[i].ParameterType);
            }

            EmitCall(method);
        }

        public void EmitNewObject(ConstructorInfo ctor)
        {
            _ilGenerator.Emit(OpCodes.Newobj, ctor);
        }

        private void EmitCall(MethodInfo method)
        {
            if (method.IsVirtual)
            {
                _ilGenerator.Emit(OpCodes.Callvirt, method);
            }
            else
            {
                _ilGenerator.Emit(OpCodes.Call, method);
            }
        }
    }
}