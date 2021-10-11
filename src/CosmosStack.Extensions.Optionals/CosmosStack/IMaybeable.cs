using System;
using CosmosStack.Optionals;

namespace CosmosStack
{
    /// <summary>
    /// Interface for Maybe <br />
    /// MayBe 组件接口
    /// </summary>
    public interface IMaybeable
    {
        /// <summary>
        /// Maybe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Maybe<T> AsOptionals<T>();

        /// <summary>
        /// Maybe
        /// </summary>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Maybe<T> AsOptionals<T>(Func<T, bool> condition);

        /// <summary>
        /// Maybe
        /// </summary>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Maybe<T> AsOptionals<T>(T defaultVal);

        /// <summary>
        /// Maybe
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Maybe<T> AsOptionals<T>(Func<T, bool> condition, T defaultVal);

        /// <summary>
        /// Maybe value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T MaybeValue<T>();

        /// <summary>
        /// Maybe value
        /// </summary>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T MaybeValue<T>(Func<T, bool> condition);

        /// <summary>
        /// Maybe value
        /// </summary>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T MaybeValue<T>(T defaultVal);

        /// <summary>
        /// Maybe value
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T MaybeValue<T>(Func<T, bool> condition, T defaultVal);
    }
}