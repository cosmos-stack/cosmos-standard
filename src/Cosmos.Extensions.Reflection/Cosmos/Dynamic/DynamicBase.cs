namespace Cosmos.Dynamic;
/*
 * Reference: https://github.com/liyanjie8712/BuildingBlocks
 *      Author: liyanjie8712
 *      License: MIT
 */

public abstract class DynamicBase
{
    private readonly Type _type;

    protected DynamicBase()
    {
        _type = GetType();
    }

    /// <summary>
    /// Get property value
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public object GetPropertyValue(string name)
    {
        return _type.GetProperty(name).GetReflector().GetValue(this);
    }

    /// <summary>
    /// Set property value
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void SetPropertyValue(string name, object value)
    {
        _type.GetProperty(name).GetReflector().SetValue(this, value);
    }
}