using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.Judgments
{
    public static class AssertionJudgment
    {
        public static void Require<TException>(bool assertion, string message) where TException : Exception
        {
            if (assertion)
                return;

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            var exception = Types.CreateInstance<TException>(message);
            throw exception;
        }

        public static void Require2<TException>(bool assertion, params object[] exceptionParams) where TException : Exception
        {
            if (assertion)
                return;

            var exception = Types.CreateInstance<TException>(exceptionParams);
            throw exception;
        }

        public static void Require3<TException>(bool assertion, CosmosExceptionOptions options) where TException : CosmosException
        {
            if (assertion)
                return;

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var exception = Types.CreateInstance<TException>(options);
            throw exception;
        }
    }
}
