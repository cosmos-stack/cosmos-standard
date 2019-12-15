using System;

namespace Cosmos.Date.Chinese {
    /// <summary>
    /// Chinese Animal Helper<br />
    /// 中国生肖辅助类
    /// </summary>
    public static class ChineseAnimalHelper {
        // ReSharper disable once InconsistentNaming
        private static readonly string[] ANIMALS = {"鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪"};

        // ReSharper disable once InconsistentNaming
        private static readonly string[] ANIMALZ = {"鼠", "牛", "虎", "兔", "龍", "蛇", "馬", "羊", "猴", "雞", "狗", "豬"};

        private const int ANIMAL_START_YEAR = 1900; //1900年为鼠年

        private static int Index(DateTime dt) {
            var offset = dt.Year - ANIMAL_START_YEAR;
            return (offset % 12);
        }

        /// <summary>
        /// Get<br />
        /// 获得生肖值
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="traditionalChineseCharacters"></param>
        /// <returns></returns>
        public static string Get(DateTime dt, bool traditionalChineseCharacters = false) {
            var animals = traditionalChineseCharacters ? ANIMALZ : ANIMALS;
            return animals[Index(dt)];
        }
    }
}