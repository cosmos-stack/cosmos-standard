using System;

/*
 * Reference to:
 *      Mutuduxf/Zaabee.Serializers
 *          Author: Mutuduxf
 *          Url:    https://github.com/Mutuduxf/Zaabee.Serializers
 *          MIT
 */

namespace Newtonsoft.Json
{
    /// <summary>
    /// Json ignore attribute
    /// </summary>
    public abstract class JsonIgnoreExtAttribute : Attribute
    {
        public bool Ignore { get; }

        public JsonIgnoreExtAttribute(bool ignore)
        {
            Ignore = ignore;
        }
    }
}
