using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CosmosStack.Collections.Pagination
{
    /// <summary>
    /// Abstract page base <br />
    /// 抽象的页基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PageBase<T> : IPage<T>
    {
        /// <summary>
        /// Member list <br />
        /// 成员项列表
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected IList<IPageMember<T>> _memberList;

        /// <summary>
        /// Initialize action <br />
        /// 初始化动作
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected Action _initializeAction;

        private bool _mHasInitialized;

        /// <summary>
        /// Page base <br />
        /// 页基类
        /// </summary>
        /// <param name="sourceIsFull"></param>
        protected PageBase(bool sourceIsFull) => SourceIsFull = sourceIsFull;

        /// <inheritdoc />
        public IEnumerator<IPageMember<T>> GetEnumerator()
        {
            CheckOrInitializePage();
            return _memberList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Offset mode <br />
        /// 偏移量模式
        /// </summary>
        protected bool SourceIsFull { get; private set; }

        /// <inheritdoc />
        public int TotalPageCount { get; protected set; }

        /// <inheritdoc />
        public int TotalMemberCount { get; protected set; }

        /// <inheritdoc />
        public int CurrentPageNumber { get; protected set; }

        /// <inheritdoc />
        public int PageSize { get; protected set; }

        /// <inheritdoc />
        public int CurrentPageSize { get; protected set; }

        /// <inheritdoc />
        public bool HasPrevious { get; protected set; }

        /// <inheritdoc />
        public bool HasNext { get; protected set; }

        /// <inheritdoc />
        public IPageMember<T> this[int index]
        {
            get
            {
                CheckOrInitializePage();
                return _memberList[index];
            }
        }

        /// <inheritdoc />
        public PageMetadata GetMetadata() => new(this);

        /// <inheritdoc />
        public IEnumerable<T> ToOriginalItems()
        {
            CheckOrInitializePage();
            return _memberList.Select(x => x.Value);
        }

        private void CheckOrInitializePage()
        {
            if (!_mHasInitialized)
            {
                _initializeAction?.Invoke();
                _mHasInitialized = true;
            }
        }
    }
}