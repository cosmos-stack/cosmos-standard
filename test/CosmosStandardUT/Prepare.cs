﻿#if !NETFRAMEWORK
namespace CosmosStandardUT
{
    public abstract class Prepare
    {
        protected Prepare()
        {
            NatashaInitializer.Preheating();
        }
    }
}
#endif