using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Util;

namespace ItemSystem
{
    public class ItemManager
    {
        private List<ItemDefinition> itemDefinitions;

        public ItemManager(ItemDefinition[] defs)
        {
            itemDefinitions = new List<ItemDefinition>(defs);
        }

        public ItemDefinition getRandomItem()
        {
            return itemDefinitions[Random.Range(0, itemDefinitions.Count)];
        }

        public ItemDefinition getRandomItem(ItemID_e include)
        {
            while (true)
            {
                ItemDefinition def = getRandomItem();
                if (BitUtil.hasFlags((int)def.id, (int)include)) return def;
            }
        }

        public ItemDefinition getItem(string name)
        {
            foreach (ItemDefinition def in itemDefinitions) if (def.name == name) return def;

            return itemDefinitions[0];
        }
    }
}