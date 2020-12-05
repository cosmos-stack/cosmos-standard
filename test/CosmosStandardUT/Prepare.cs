namespace CosmosStandardUT
{
    public abstract class Prepare
    {
        protected Prepare()
        {
#if !NETFRAMEWORK
            NatashaInitializer.InitializeAndPreheating();
#endif
        }
    }
}