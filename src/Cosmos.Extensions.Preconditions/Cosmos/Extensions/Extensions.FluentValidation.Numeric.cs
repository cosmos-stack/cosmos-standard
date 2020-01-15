using FluentValidation;

namespace Cosmos.Extensions {
    /// <summary>
    /// Extensions for fluent validation
    /// </summary>
    public static partial class FluentValidationExtensions {

        #region Less Than or Equal to Zero

        /// <summary>
        /// Raise exception if less than or equal to zero.
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThanOrEqualToZero<T>(this IRuleBuilder<T, int> ruleBuilder, (long, string, string) error)
            => ruleBuilder.RaiseExceptionIfLessThanOrEqualTo(0, error);

        /// <summary>
        /// Raise exception if less than or equal to zero
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThanOrEqualToZero<T>(this IRuleBuilder<T, long> ruleBuilder, (long, string, string) error)
            => ruleBuilder.RaiseExceptionIfLessThanOrEqualTo(0, error);

        /// <summary>
        /// Raise exception if less than or equal to zero
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThanOrEqualToZero<T>(this IRuleBuilder<T, double> ruleBuilder, (long, string, string) error)
            => ruleBuilder.RaiseExceptionIfLessThanOrEqualTo(0, error);

        /// <summary>
        /// Raise exception if less than or equal to zero
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThanOrEqualToZero<T>(this IRuleBuilder<T, string> ruleBuilder, (long, string, string) error)
            => ruleBuilder.RaiseExceptionIfLessThanOrEqualTo("0", error);

        /// <summary>
        /// Raise exception if less than zero
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThanZero<T>(this IRuleBuilder<T, int> ruleBuilder, (long, string, string) error)
            => ruleBuilder.RaiseExceptionIfLessThan(0, error);

        /// <summary>
        /// Raise exception if less than zero
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThanZero<T>(this IRuleBuilder<T, long> ruleBuilder, (long, string, string) error)
            => ruleBuilder.RaiseExceptionIfLessThan(0, error);

        /// <summary>
        /// Raise exception if less than zero
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThanZero<T>(this IRuleBuilder<T, double> ruleBuilder, (long, string, string) error)
            => ruleBuilder.RaiseExceptionIfLessThan(0, error);

        /// <summary>
        /// Raise exception if less than zero
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThanZero<T>(this IRuleBuilder<T, string> ruleBuilder, (long, string, string) error)
            => ruleBuilder.RaiseExceptionIfLessThan("0", error);

        #endregion

        #region Greater than or Equal to Zero

        /// <summary>
        /// Raise exception if greater than or equal to zero.
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThanOrEqualToZero<T>(this IRuleBuilder<T, int> ruleBuilder, (long, string, string) error) {
            ruleBuilder.LessThan(0).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if greater than or equal to zero
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThanOrEqualToZero<T>(this IRuleBuilder<T, long> ruleBuilder, (long, string, string) error) {
            ruleBuilder.LessThan(0).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if greater than or equal to zero
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThanOrEqualToZero<T>(this IRuleBuilder<T, double> ruleBuilder, (long, string, string) error) {
            ruleBuilder.LessThan(0).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if greater than or equal to zero
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThanOrEqualToZero<T>(this IRuleBuilder<T, string> ruleBuilder, (long, string, string) error) {
            ruleBuilder.Must((t, v) => !v.IsNumeric() || v.CastToDecimal() < 0).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if greater than zero
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThanZero<T>(this IRuleBuilder<T, int> ruleBuilder, (long, string, string) error) {
            ruleBuilder.GreaterThanOrEqualTo(0).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if greater than zero
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThanZero<T>(this IRuleBuilder<T, long> ruleBuilder, (long, string, string) error) {
            ruleBuilder.GreaterThanOrEqualTo(0).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if greater than zero
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThanZero<T>(this IRuleBuilder<T, double> ruleBuilder, (long, string, string) error) {
            ruleBuilder.GreaterThanOrEqualTo(0).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if greater than zero
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThanZero<T>(this IRuleBuilder<T, string> ruleBuilder, (long, string, string) error) {
            ruleBuilder.Must((t, v) => !v.IsNumeric() || v.CastToDecimal() < 0).RaiseInternal(error);
        }

        #endregion

        #region Less Than or Equal to ...

        /// <summary>
        /// Raise exception if less than or equal to ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThanOrEqualTo<T>(this IRuleBuilder<T, int> ruleBuilder, int value, (long, string, string) error) {
            ruleBuilder.GreaterThan(value).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if less than or equal to ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThanOrEqualTo<T>(this IRuleBuilder<T, long> ruleBuilder, long value, (long, string, string) error) {
            ruleBuilder.GreaterThan(value).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if less than or equal to ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThanOrEqualTo<T>(this IRuleBuilder<T, double> ruleBuilder, double value, (long, string, string) error) {
            ruleBuilder.GreaterThan(value).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if less than or equal to ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThanOrEqualTo<T>(this IRuleBuilder<T, string> ruleBuilder, string value, (long, string, string) error) {
            ruleBuilder.Must((t, v) => !v.IsNumeric() || v.CastToDecimal() > value.CastToDecimal()).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if less than ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThan<T>(this IRuleBuilder<T, int> ruleBuilder, int value, (long, string, string) error) {
            ruleBuilder.GreaterThanOrEqualTo(value).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if less than ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThan<T>(this IRuleBuilder<T, long> ruleBuilder, long value, (long, string, string) error) {
            ruleBuilder.GreaterThanOrEqualTo(value).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if less than ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThan<T>(this IRuleBuilder<T, double> ruleBuilder, double value, (long, string, string) error) {
            ruleBuilder.GreaterThanOrEqualTo(value).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if less than ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfLessThan<T>(this IRuleBuilder<T, string> ruleBuilder, string value, (long, string, string) error) {
            ruleBuilder.Must((t, v) => !v.IsNumeric() || v.CastToDecimal() >= value.CastToDecimal()).RaiseInternal(error);
        }

        #endregion

        #region Great Than or Equal to ...

        /// <summary>
        /// Raise exception if greater than or equal to ....
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThanOrEqualTo<T>(this IRuleBuilder<T, int> ruleBuilder, int value, (long, string, string) error) {
            ruleBuilder.LessThan(value).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if greater than or equal to ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThanOrEqualTo<T>(this IRuleBuilder<T, long> ruleBuilder, long value, (long, string, string) error) {
            ruleBuilder.LessThan(value).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if greater than or equal to ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThanOrEqualTo<T>(this IRuleBuilder<T, double> ruleBuilder, double value, (long, string, string) error) {
            ruleBuilder.LessThan(value).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if greater than or equal to ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThanOrEqualTo<T>(this IRuleBuilder<T, string> ruleBuilder, string value, (long, string, string) error) {
            ruleBuilder.Must((t, v) => !v.IsNumeric() || v.CastToDecimal() < value.CastToDecimal()).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if greater than ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThan<T>(this IRuleBuilder<T, int> ruleBuilder, int value, (long, string, string) error) {
            ruleBuilder.GreaterThanOrEqualTo(value).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if greater than ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThan<T>(this IRuleBuilder<T, long> ruleBuilder, long value, (long, string, string) error) {
            ruleBuilder.GreaterThanOrEqualTo(value).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if greater than ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThan<T>(this IRuleBuilder<T, double> ruleBuilder, double value, (long, string, string) error) {
            ruleBuilder.GreaterThanOrEqualTo(value).RaiseInternal(error);
        }

        /// <summary>
        /// Raise exception if greater than ...
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfGreaterThan<T>(this IRuleBuilder<T, string> ruleBuilder, string value, (long, string, string) error) {
            ruleBuilder.Must((t, v) => !v.IsNumeric() || v.CastToDecimal() < value.CastToDecimal()).RaiseInternal(error);
        }

        #endregion

    }
}