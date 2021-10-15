using System.Collections.Generic;
using System.Linq;

namespace CosmosStack.Collections.Pagination.Internals
{
    /// <summary>
    /// Page member factory
    /// </summary>
    internal static class PageMemberFactory
    {
        /// <summary>
        /// Create a new instance of <see cref="PageMember{T}"/>
        /// </summary>
        /// <param name="memberValue"></param>
        /// <param name="offset"></param>
        /// <param name="startIndex"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static PageMember<T> Create<T>(T memberValue, int offset, ref int startIndex)
            => new(memberValue, offset, ref startIndex);

        /// <summary>
        /// Create a new instance of <see cref="PageMember{T}"/>
        /// </summary>
        /// <param name="memberColl"></param>
        /// <param name="index"></param>
        /// <param name="offset"></param>
        /// <param name="startIndex"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static PageMember<T> Create<T>(IEnumerable<T> memberColl, int index, int offset, ref int startIndex)
            => new(memberColl.ElementAt(index), offset, ref startIndex);

        /// <summary>
        /// Create a new instance of <see cref="PageMember{T}"/>
        /// </summary>
        /// <param name="state"></param>
        /// <param name="offset"></param>
        /// <param name="startIndex"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static PageMember<T> Create<T>(IQueryEntryState<T> state, int offset, ref int startIndex)
            => new(state, offset, ref startIndex);
    }
}