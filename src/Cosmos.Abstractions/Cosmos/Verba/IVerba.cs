using System;

namespace Cosmos.Verba {
    /// <summary>
    /// Verba Meta Interface<br />
    /// Cosmos Verba 元接口<br />
    /// 本接口将在下阶段被 Cosmos.I18N 取代<br />
    /// 在第二阶段，将基于 Cosmos.I18N 推出独立的 Cosmos.Verba
    /// </summary>
    [Obsolete("将会被 Cosmos.I18N 取代")]
    public interface IVerba {
        /// <summary>
        /// Gets verba name<br />
        /// 获取 Verba 名称
        /// </summary>
        string VerbaName { get; }
    }
}