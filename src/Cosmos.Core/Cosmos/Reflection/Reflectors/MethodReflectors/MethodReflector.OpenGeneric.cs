namespace Cosmos.Reflection.Reflectors;

public partial class MethodReflector
{
    private class OpenGenericMethodReflector : MethodReflector
    {
        public OpenGenericMethodReflector(MethodInfo reflectionInfo) : base(reflectionInfo) { }

        protected override Func<object, object[], object> CreateInvoker() => null!;

        public override object Invoke(object instance, params object[] parameters)
            => throw new InvalidOperationException("Late bound operations cannot be performed on types or methods for which ContainsGenericParameters is true.");

        public override object StaticInvoke(params object[] parameters)
            => throw new InvalidOperationException("Late bound operations cannot be performed on types or methods for which ContainsGenericParameters is true.");
    }
}