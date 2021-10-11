﻿using System;
using System.Reflection.Emit;

namespace TinyMapper.CodeGenerators.Emitters
{
    internal sealed class EmitReturn : IEmitterType
    {
        private readonly IEmitterType _returnValue;

        private EmitReturn(IEmitterType returnValue, Type returnType)
        {
            ObjectType = returnType ?? returnValue.ObjectType;
            _returnValue = returnValue;
        }

        public Type ObjectType { get; }

        public void Emit(CodeGenerator generator)
        {
            _returnValue.Emit(generator);
            if (ObjectType == _returnValue.ObjectType)
            {
                generator.Emit(OpCodes.Ret);
            }
            else
            {
                generator.CastType(_returnValue.ObjectType, ObjectType)
                   .Emit(OpCodes.Ret);
            }
        }

        public static IEmitterType Return(IEmitterType returnValue, Type returnType = null)
        {
            return new EmitReturn(returnValue, returnType);
        }
    }
}