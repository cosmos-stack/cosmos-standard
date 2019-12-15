// Description: Async extension methods for LINQ (Language Integrated Query).
// Website & Documentation: https://github.com/zzzprojects/LINQ-Async
// Forum: https://github.com/zzzprojects/LINQ-Async/issues
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

/*
 * Reference to:
 *  ZZZProjects/LINQ-Async
 *  Author: JonathanMagnan
 *  URL: https://github.com/zzzprojects/LINQ-Async
 *  MIT
 */

namespace System.Linq.Async {
    /// <summary>
    /// Linq Async Manager
    /// </summary>
    public static class LinqAsyncManager {
        static LinqAsyncManager() {
            DefaultValue.OrderByPredicateCompletion = false;
            DefaultValue.StartPredicateConcurrently = false;
        }

        /// <summary>
        /// Default value
        /// </summary>
        public static class DefaultValue {
            /// <summary>
            /// Order By Predicate Completion
            /// </summary>
            public static bool OrderByPredicateCompletion { get; set; }

            /// <summary>
            /// Start Predicate Concurrently
            /// </summary>
            public static bool StartPredicateConcurrently { get; set; }
        }
    }
}