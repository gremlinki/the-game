using ItemSystem;
using UnityEngine;

public enum GameState
{
    PAUSED,
    IDLE,
    GATHERING,
    SPECTACLE
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CInventoryManager InventoryManager { get; private set; }
    public RelationManager relationManager { get; private set; }
    public ItemManager ItemManager { get; private set; }

    public Player player;
    [SerializeField] private ItemDefinition[] itemDefs;
    public GameObject pickupWindow; // The window that pops up when player gets near an item

    public GameState gameState = GameState.PAUSED;

    private float timer;
    private int spectacleCounter = 0;
    public int day = 1;
    private CItem[] items;
    

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
        relationManager = new RelationManager();
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

        items = InventoryManager.items();
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.PAUSED:
                break;
            case GameState.IDLE:
                if (spectacleCounter < 2)
                    StartSpectacle();
                else
                    AdvanceDay();
                break;
            case GameState.GATHERING:
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    StartSpectacle();
                    break;
                }
                break;
            case GameState.SPECTACLE:
                // Spectacle logic here?
                // Player displays all items in succession
                // Npcs do their reactions

                // Each item's values get added to corresponding stats
                foreach (CItem item in items)
                {
                    relationManager.kingAffinity += item.funFactor * (item.group == ItemGroup_e.KING ? 1 : -1);
                    relationManager.nobillityAffinity += item.funFactor * (item.group == ItemGroup_e.ROYALTY ? 1 : -1);
                    relationManager.mentalHealth += item.selfDepravation;
                    relationManager.UpdateLevels();
                }
                
                spectacleCounter++;
                gameState = GameState.IDLE;
                break;
        }
    }

    public void StartGathering()
    {
        // <-- Load Castle scene here
        gameState = GameState.GATHERING;
        timer = 30;
    }

    public void StartSpectacle()
    {
        // <-- Load Spectacle scene here
        gameState = GameState.SPECTACLE;
    }

    public void AdvanceDay()
    {
        day++;
        spectacleCounter = 0;
        // <-- Display some notes and summary of day here
    }

    public void PlayEnding(string name)
    {
        switch(name)
        {
            case "king_win":
                break;
            case "king_lose":
                break;
            case "nobillity_win":
                break;
            case "nobillity_lose":
                break;
            case "jester_win":
                break;
            case "jester_lose":
                break;
        }

        // <-- Exit game
    }
}