﻿using System;
using System.Reflection.Emit;
using TinyMapper.Core;

namespace TinyMapper.CodeGenerators.Emitters
{
    internal sealed class EmitBox : IEmitterType
    {
        private readonly IEmitterType _value;

        private EmitBox(IEmitterType value)
        {
            _value = value;
            ObjectType = value.ObjectType;
        }

        public Type ObjectType { get; }

        public void Emit(CodeGenerator generator)
        {
            _value.Emit(generator);

            if (Helpers.IsValueType(ObjectType))
            {
                generator.Emit(OpCodes.Box, ObjectType);
            }
        }

        public static IEmitterType Box(IEmitterType value)
        {
            return new EmitBox(value);
        }
    }
}