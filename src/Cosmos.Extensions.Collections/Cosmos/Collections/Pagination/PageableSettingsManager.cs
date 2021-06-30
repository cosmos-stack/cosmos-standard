using System;

namespace Cosmos.Collections.Pagination
{
    public static class PageableSettingsManager
    {
        // ReSharper disable once InconsistentNaming
        private static PageableSettings _settingsCache { get; set; }

        static PageableSettingsManager()
            => _settingsCache = new PageableSettings();

        /// <summary>
        /// Get pageable settings
        /// </summary>
        public static PageableSettings Settings
            => _settingsCache;

        /// <summary>
        /// Update pageable settings
        /// </summary>
        /// <param name="settings"></param>
        public static void UpdateSettings(PageableSettings settings)
            => _settingsCache = settings ?? throw new ArgumentNullException(nameof(settings));
    }
}