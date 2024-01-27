using ItemSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CInventoryManager InventoryManager { get; private set; }
    public Player player;
    public GameObject pickupWindow;
    
    private GameManager()
    {
        InventoryManager = new CInventoryManager();
    }

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
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