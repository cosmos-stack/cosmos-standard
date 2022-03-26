namespace Cosmos.Collections.Pagination;

/// <summary>
/// Pageable settings manager <br />
/// 分页配置管理器
/// </summary>
public static class PageableSettingsManager
{
    // ReSharper disable once InconsistentNaming
    private static PageableSettings _settingsCache { get; set; }

    static PageableSettingsManager()
        => _settingsCache = new PageableSettings();

    /// <summary>
    /// Get pageable settings <br />
    /// 获取分页配置
    /// </summary>
    public static PageableSettings Settings
        => _settingsCache;

    /// <summary>
    /// Update pageable settings <br />
    /// 更新分页配置
    /// </summary>
    /// <param name="settings"></param>
    public static void UpdateSettings(PageableSettings settings)
        => _settingsCache = settings ?? throw new ArgumentNullException(nameof(settings));
}