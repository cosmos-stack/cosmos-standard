#if !NET451

/*
 * Author: LanX
 * 2020.01.03
 */

namespace Cosmos {
    internal readonly struct CtorMatchedResult {

        public CtorMatchedResult(object[] values, int index) {
            Values = values;
            Index = index;
        }

        public readonly object[] Values;

        public readonly int Index;
    }
}

#endif