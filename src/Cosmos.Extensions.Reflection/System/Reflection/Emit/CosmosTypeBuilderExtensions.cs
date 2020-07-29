namespace System.Reflection.Emit
{
    /// <summary>
    /// Cosmos <see cref="TypeBuilder"/> extensions.
    /// </summary>
    public static class CosmosTypeBuilderExtensions
    {
        /// <summary>
        /// Property set and property get methods require a special set of attributes.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private const MethodAttributes PROPERTY_GET_SET_METHOD_ATTRIBUTES = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;

        /// <summary>
        /// Define auto implemented property
        /// </summary>
        /// <param name="typeBuilder"></param>
        /// <param name="name"></param>
        /// <param name="propertyType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static (PropertyBuilder PropertyBuilder, FieldBuilder FieldBuilder) DefineAutoImplementedProperty(this TypeBuilder typeBuilder, string name, Type propertyType)
        {
            if (typeBuilder is null)
                throw new ArgumentNullException(nameof(typeBuilder));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (propertyType is null)
                throw new ArgumentNullException(nameof(propertyType));

            // Create the field.
            // Create something that isn't normally accessible through C# or other languages.
            var fieldBuilder = typeBuilder.DefineField($"_${name}$", propertyType, FieldAttributes.Private);

            // Create the property.
            var propertyBuilder = typeBuilder.DefineProperty(name, PropertyAttributes.HasDefault, propertyType, null);

            // Get the get and set methods.
            var getMethodBuilder = typeBuilder.DefineAutoImplementedPropertyGetMethodBuilder(name, propertyType, fieldBuilder);
            var setMethodBuilder = typeBuilder.DefineAutoImplementedPropertySetMethodBuilder(name, propertyType, fieldBuilder);

            // Set the methods for the property accessors.
            propertyBuilder.SetGetMethod(getMethodBuilder);
            propertyBuilder.SetSetMethod(setMethodBuilder);

            // Return the property and the field builders.
            return (propertyBuilder, fieldBuilder);
        }

        private static MethodBuilder DefineAutoImplementedPropertyGetMethodBuilder(this TypeBuilder typeBuilder, string name, Type propertyType, FieldBuilder fieldBuilder)
        {
            if (typeBuilder is null)
                throw new ArgumentNullException(nameof(typeBuilder));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (propertyType is null)
                throw new ArgumentNullException(nameof(propertyType));
            if (fieldBuilder is null)
                throw new ArgumentNullException(nameof(fieldBuilder));

            var methodBuilder = typeBuilder.DefineMethod($"get_{name}", PROPERTY_GET_SET_METHOD_ATTRIBUTES, propertyType, Type.EmptyTypes);
            var il = methodBuilder.GetILGenerator();

            // Emit the IL necessary for getting a field.
            // Load "this" to the stack,
            il.Emit(OpCodes.Ldarg_0);
            // Load the field specified from this onto the stack.
            il.Emit(OpCodes.Ldfld, fieldBuilder);
            // Return the top of the stack.
            il.Emit(OpCodes.Ret);

            // Return the method builder.
            return methodBuilder;
        }

        private static MethodBuilder DefineAutoImplementedPropertySetMethodBuilder(this TypeBuilder typeBuilder, string name, Type propertyType, FieldBuilder fieldBuilder)
        {
            if (typeBuilder is null)
                throw new ArgumentNullException(nameof(typeBuilder));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (propertyType is null)
                throw new ArgumentNullException(nameof(propertyType));
            if (fieldBuilder is null)
                throw new ArgumentNullException(nameof(fieldBuilder));

            var methodBuilder = typeBuilder.DefineMethod($"set_{name}", PROPERTY_GET_SET_METHOD_ATTRIBUTES, null, new[] { propertyType });
            var il = methodBuilder.GetILGenerator();

            // Emit the IL for setting a field.
            // Load this
            il.Emit(OpCodes.Ldarg_0);
            // Load the value.
            il.Emit(OpCodes.Ldarg_1);
            // Set the value for the field on this.
            il.Emit(OpCodes.Stfld, fieldBuilder);
            // Return.
            il.Emit(OpCodes.Ret);

            // Return the method builder.
            return methodBuilder;
        }

    }
}
