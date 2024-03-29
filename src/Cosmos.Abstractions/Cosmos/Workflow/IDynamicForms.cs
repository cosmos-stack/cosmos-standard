﻿namespace Cosmos.Workflow;

/// <summary>
/// Dynamic Forms Interface<br />
/// 动态表单接口<br />
/// 本接口用于 Cosmos.Core.Walker 与 Cosmos.Core.Flower
/// </summary>
public interface IDynamicForms
{
    /// <summary>
    /// Dynamic Forms Design<br />
    /// 动态表单设计稿
    /// </summary>
    IDynamicFormsDesign Design { get; }

    /// <summary>
    /// Title<br />
    /// 动态表单标题
    /// </summary>
    string Title { get; }
}