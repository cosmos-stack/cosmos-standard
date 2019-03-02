using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

/*
 * Reference to:
 *      Mutuduxf/Zaabee.Serializers
 *          Author: Mutuduxf
 *          Url:    https://github.com/Mutuduxf/Zaabee.Serializers
 *          MIT
 */

namespace Cosmos.Json
{
    internal class JsonContractResolver : DefaultContractResolver
    {
        private readonly IEnumerable<string> _props;
        private readonly bool _toLowerCaseCamel;

        public JsonContractResolver(IEnumerable<string> props, bool toLowerCamel = false)
        {
            _props = props;
            _toLowerCaseCamel = toLowerCamel;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var listProp = base.CreateProperties(type, memberSerialization);
            if (_props == null)
                return listProp;

            var jsAttr = Attribute.GetCustomAttributes(type).OfType<JsonIgnoreExtAttribute>().FirstOrDefault();
            if (jsAttr != null && !jsAttr.Ignore)
                return listProp;

            return listProp.Where(p => !string.IsNullOrWhiteSpace(p.PropertyName)
                                       && _props.Where(g => !string.IsNullOrWhiteSpace(g))
                                           .Any(g => g.Split(',')
                                               .Where(q => !string.IsNullOrWhiteSpace(q))
                                               .Select(q => q.ToUpper().Trim())
                                               .Contains(p.PropertyName.ToUpper().Trim()))).ToList();
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            return _toLowerCaseCamel ? GetCamelCaseName(propertyName) : propertyName;
        }

        private static string GetCamelCaseName(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || char.IsLower(s[0]))
                return s;

            var chArray = s.ToCharArray();
            for (var i = 0; i < chArray.Length; i++)
            {
                var flag = (i + 1) < chArray.Length;
                if (i > 0 && flag && char.IsLower(chArray[i + 1]))
                    break;

                chArray[i] = char.ToLower(chArray[i], CultureInfo.InvariantCulture);
            }

            return new string(chArray);
        }
    }
}
