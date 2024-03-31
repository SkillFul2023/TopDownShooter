using System;
using TopDownShooter.Enums;

namespace TopDownShooter.Gameplay
{
    [Serializable]
    public struct ItemStats
    {
        public ItemNameEnum name;
        public int countItem;
        public int idItem;
        public int dropChance;
    }
}