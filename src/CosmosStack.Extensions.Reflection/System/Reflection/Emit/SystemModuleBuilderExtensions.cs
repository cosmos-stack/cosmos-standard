using System.Collections.Generic;
using System.Linq;

// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace System.Reflection.Emit
{
    /// <summary>
    /// CosmosStack <see cref="ModuleBuilder"/> extensions.
    /// </summary>
    public static class SystemModuleBuilderExtensions
    {
        /// <summary>
        /// Define POCO
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="name"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static TypeBuilder DefinePOCO(this ModuleBuilder builder, string name,
            params KeyValuePair<string, Type>[] properties) => builder.DefinePOCO(name, properties.AsEnumerable());

        /// <summary>
        /// Define POCO
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="name"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static TypeBuilder DefinePOCO(this ModuleBuilder builder, string name, IEnumerable<KeyValuePair<string, Type>> properties)
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (properties is null)
                throw new ArgumentNullException(nameof(properties));

            var typeBuilder = builder.DefineType(name, TypeAttributes.Public);

            ISet<string> propertyNames = new HashSet<string>(StringComparer.Ordinal);

#if NETFRAMEWORK || NETSTANDARD2_0
            foreach (var property in properties)
            {
                var propertyName = property.Key;
                var type = property.Value;
#else
            foreach (var (propertyName, type) in properties)
            {
#endif
                if (propertyNames.Contains(propertyName))
                    throw new InvalidOperationException($"Encountered a duplicate property name of \"{propertyName}\"");

                typeBuilder.DefineAutoImplementedProperty(propertyName, type);
                propertyNames.Add(propertyName);
            }

            return typeBuilder;
        }
    }
}