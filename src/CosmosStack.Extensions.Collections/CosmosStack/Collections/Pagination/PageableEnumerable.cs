using System;
using System.Collections.Generic;
using Cosmos.Collections.Pagination;

namespace CosmosStack.Collections.Pagination
{
    /// <summary>
    /// EnumerablePage collection <br />
    /// 分页集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageableEnumerable<T> : PageableSetBase<T>
    {
        private readonly IEnumerable<T> _enumerable;

        // ReSharper disable once UnusedMember.Local
        private PageableEnumerable() { }

        internal PageableEnumerable(IEnumerable<T> enumerable, int pageSize, int realPageCount, int realMemberCount)
            : base(pageSize, realPageCount, realMemberCount)
        {
            _enumerable = enumerable;
        }

        internal PageableEnumerable(IEnumerable<T> enumerable, int pageSize, int realPageCount, int realMemberCount, int limitedMembersCount)
            : base(pageSize, realPageCount, realMemberCount, limitedMembersCount)
        {
            _enumerable = enumerable;
        }

        /// <summary>
        /// Get special page <br />
        /// 获得指定的页
        /// </summary>
        /// <param name="currentPageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="realMemberCount"></param>
        /// <returns></returns>
        protected override Lazy<IPage<T>> GetSpecifiedPage(int currentPageNumber, int pageSize, int realMemberCount)
        {
            return new(() => new EnumerablePage<T>(_enumerable, currentPageNumber, pageSize, realMemberCount));
        }
    }
}