using System;
using Cosmos.IdUtils.GuidImplements;

namespace Cosmos.IdUtils {
    /// <summary>
    /// Guid provider
    /// </summary>
    public static partial class GuidProvider {
        /// <summary>
        /// Create random style guid
        /// </summary>
        /// <returns></returns>
        // ReSharper disable once RedundantArgumentDefaultValue
        public static Guid CreateRandom() => Create(GuidStyle.BasicStyle);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="style"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static Guid Create(GuidStyle style = GuidStyle.BasicStyle, NoRepeatMode mode = NoRepeatMode.Off) {
            switch (style) {
                //Creates a random (version 4) GUID.
                case GuidStyle.BasicStyle:
                    return Guid.NewGuid();

                case GuidStyle.CombStyle:
                    return TimeStampStyleProvider.Create(mode);

                case GuidStyle.TimeStampStyle:
                    return TimeStampStyleProvider.Create(mode);

                case GuidStyle.UnixTimeStampStyle:
                    return UnixTimeStampStyleProvider.Create(mode);

                case GuidStyle.LegacySqlTimeStampStyle:
                    return mode == NoRepeatMode.On
                        ? CombImplements.InternalCombImplementProxy.LegacyWithNoRepeat.Create()
                        : CombImplements.InternalCombImplementProxy.Legacy.Create();

                case GuidStyle.SqlTimeStampStyle:
                    return mode == NoRepeatMode.On
                        ? CombImplements.InternalCombImplementProxy.MsSqlWithNoRepeat.Create()
                        : CombImplements.InternalCombImplementProxy.MsSql.Create();

                case GuidStyle.PostgreSqlTimeStampStyle:
                    return mode == NoRepeatMode.On
                        ? CombImplements.InternalCombImplementProxy.PostgreSqlWithNoRepeat.Create()
                        : CombImplements.InternalCombImplementProxy.PostgreSql.Create();

                case GuidStyle.SequentialAsStringStyle:
                    return SequentialStylesProvider.Create(SequentialGuidTypes.SequentialAsString, mode);

                case GuidStyle.SequentialAsBinaryStyle:
                    return SequentialStylesProvider.Create(SequentialGuidTypes.SequentialAsBinary, mode);

                case GuidStyle.SequentialAsEndStyle:
                    return SequentialStylesProvider.Create(SequentialGuidTypes.SequentialAsEnd, mode);

                case GuidStyle.EquifaxStyle:
                    return EquifaxStyleProvider.Create(mode);

                //Creates a random (version 4) GUID.
                default:
                    return Guid.NewGuid();
            }
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="secureTimestamp"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static Guid Create(DateTime secureTimestamp, GuidStyle style = GuidStyle.TimeStampStyle) {
            switch (style) {
                case GuidStyle.BasicStyle:
                    return Guid.NewGuid();

                case GuidStyle.CombStyle:
                    return TimeStampStyleProvider.Create(secureTimestamp);

                case GuidStyle.TimeStampStyle:
                    return TimeStampStyleProvider.Create(secureTimestamp);

                case GuidStyle.UnixTimeStampStyle:
                    return UnixTimeStampStyleProvider.Create(secureTimestamp);

                case GuidStyle.LegacySqlTimeStampStyle:
                    return CombImplements.InternalCombImplementProxy.Legacy.Create(secureTimestamp);

                case GuidStyle.SqlTimeStampStyle:
                    return CombImplements.InternalCombImplementProxy.MsSql.Create(secureTimestamp);

                case GuidStyle.PostgreSqlTimeStampStyle:
                    return CombImplements.InternalCombImplementProxy.PostgreSql.Create(secureTimestamp);

                case GuidStyle.SequentialAsStringStyle:
                    return SequentialStylesProvider.Create(secureTimestamp, SequentialGuidTypes.SequentialAsString);

                case GuidStyle.SequentialAsBinaryStyle:
                    return SequentialStylesProvider.Create(secureTimestamp, SequentialGuidTypes.SequentialAsBinary);

                case GuidStyle.SequentialAsEndStyle:
                    return SequentialStylesProvider.Create(secureTimestamp, SequentialGuidTypes.SequentialAsEnd);

                case GuidStyle.EquifaxStyle:
                    return EquifaxStyleProvider.Create(secureTimestamp);

                default:
                    return TimeStampStyleProvider.Create(secureTimestamp);
            }
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="endianGuidBytes"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static Guid Create(byte[] endianGuidBytes, GuidBytesStyle style) {
            switch (style) {
                case GuidBytesStyle.LittleEndianByteArray:
                    return LittleEndianByteArrayProvider.Create(endianGuidBytes);

                case GuidBytesStyle.BigEndianByteArray:
                    return BigEndianByteArrayProvider.Create(endianGuidBytes);

                //Creates a random (version 4) GUID.
                default:
                    return Guid.NewGuid();
            }
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static Guid Create(Guid @namespace, byte[] name, GuidVersion version) {
            switch (version) {
                //Creates a random (version 4) GUID.
                case GuidVersion.Random:
                    return CreateRandom();

                //Creates a named, MD5-based (version 3) GUID.
                case GuidVersion.NameBasedMd5:
                    return NamedGuidProvider.Create(@namespace, name, GuidVersion.NameBasedMd5);

                //Creates a named, SHA1-based (version 5) GUID.
                case GuidVersion.NameBasedSha1:
                    return NamedGuidProvider.Create(@namespace, name, GuidVersion.NameBasedSha1);

                case GuidVersion.TimeBased:
                    return Create(CombStyle.NormalStyle);

                //Creates a random (version 4) GUID.
                default:
                    return Guid.NewGuid();
            }
        }
    }
}