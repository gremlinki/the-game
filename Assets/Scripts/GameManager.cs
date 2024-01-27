using ItemSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CInventoryManager InventoryManager { get; private set; }
    public ItemManager ItemManager { get; private set; }
    public Player player;
    public GameObject pickupWindow;

    [SerializeField] private ItemDefinition[] itemDefs;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        InventoryManager = new CInventoryManager();
        ItemManager = new ItemManager(itemDefs);
    }

    private void Start()
    {
        if (!player)
        {
            Debug.Log("No player was provided to Game Manager.");
        }
        if (!pickupWindow)
        {
            Debug.Log("PickupWindow wasn't provided to Game Manager.");
        }
    }
}