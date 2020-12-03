namespace CosmosStandardUT
{
    public abstract class Prepare
    {
        protected Prepare()
        {
#if !NET452
            NatashaInitializer.InitializeAndPreheating();
#endif
        }
    }
}