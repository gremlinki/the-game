using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemSystem
{
    public class CItemWrapper : MonoBehaviour
    {
        private static int[] values =
        {
            -20, -15, -10, -5, 5, 10, 15, 20
        };
        
        public CItem item
        {
            get
            {
                return m_pItem;
            }

            set
            {
                m_pItem = value;
            }
        }

        public void init(ItemID_e allowedItems)
        {
            ItemDefinition def = GameManager.instance.ItemManager.getRandomItem(allowedItems);

            int[] stats = generateItemStats();
            CItem item = new CItem(def, m_eItemGroup, stats[0], stats[1], stats[2]);
            m_pItem = item;
            GetComponent<SpriteRenderer>().sprite = def.icon;
        }

        [SerializeField] private ItemGroup_e m_eItemGroup = ItemGroup_e.KING;
        private CItem m_pItem;
        public int KingNumber, NobleNumber, PSYNumber;

        public int[] generateItemStats()
        {
            int minModifier = 0, maxModifier = 0;
            int rand = Random.Range(0, 7);
            int king = values[rand];

            if (rand < 4)
                minModifier = 5 - rand;
            else
                maxModifier = rand - 5;

            rand = Random.Range(minModifier, 7 - maxModifier);
            int nobillity = values[rand];

            if (rand < 4)
            {
                minModifier += 5 - rand;
                maxModifier += rand - 5;
                if (maxModifier < 0)
                    maxModifier = 0;
            }
            else
            {
                maxModifier += rand - 5;
                minModifier += 5 - rand;
                if (minModifier < 0)
                    minModifier = 0;
            }

            rand = Random.Range(minModifier, 7 - maxModifier);
            int sanity = values[rand];

            return new int[]{king, nobillity, sanity};
        }
    }
}