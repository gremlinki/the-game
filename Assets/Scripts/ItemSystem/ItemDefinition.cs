using UnityEngine;

namespace ItemSystem
{
    [CreateAssetMenu(fileName = "ItemDefinition", menuName = "Definitions/ItemDefinition", order = 1)]
    public class ItemDefinition : ScriptableObject
    {
        public Sprite icon;
        
        public itemid_e id;
        public ItemDefinition_t data;
    }
}