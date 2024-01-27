using UnityEngine;

namespace ItemSystem
{
    [CreateAssetMenu(fileName = "ItemDefinition", menuName = "Definitions/ItemDefinition", order = 1)]
    public class ItemDefinition : ScriptableObject
    {
        public Sprite icon;

        public enum itemid_e
        {
            CARROT = 1 << 0,
            SHOVEL = 1 << 1,
            SWORD = 1 << 2,
            SHIELD = 1 << 3,
            COATOFARMS = 1 << 4,
            BEERMUG = 1 << 5,
            APPLE = 1 << 6,
            BOOK = 1 << 7,
            HAMMER = 1 << 8
        }
        public itemid_e id;
        public ItemDefinition_t data;
    }
}