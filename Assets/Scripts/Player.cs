using Dbg;
using UnityEngine;
using ItemSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Vector3 input; // The axis for movement input [wsad]
    [SerializeField] private float movementSpeed = 3f;

    [SerializeField] Collider2D itemPickupArea;
    private Animator pomniAnimator;
    CItemWrapper currentItem; // Current item the player is looking at
    GameObject pickupWindow; // The window that pops up when player gets near item
    GameManager gameManager;

    // list z opisami itemów
    public GameObject GO_ListItems;
    [SerializeField]
    private ListLogic ListItems;

    new Rigidbody2D rigidbody;
    private static readonly int Direction = Animator.StringToHash("direction"),
        Velocity = Animator.StringToHash("moving");

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;

        pomniAnimator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.freezeRotation = true;

        pickupWindow = gameManager.pickupWindow;
        if(SceneManager.GetActiveScene().name != "Spectacle"){
            ListItems = GO_ListItems.GetComponent<ListLogic>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Is the player near an item?
            if (currentItem)
            {
                Debug.Log("Item picked up");
                gameManager.InventoryManager.addItem(currentItem.item);
                Destroy(currentItem.gameObject);
                currentItem = null;
            }
        }

        if (Input.anyKey)
        {
            if(SceneManager.GetActiveScene().name != "Spectacle"){
                // On any key input && if list open == true zamyka list 'bezpowrotnie'
                if (ListItems.isListOpen == true)
                {
                    ListItems.isListOpen = false;
                }
            }

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().name != "Spectacle"){
            //Movement:
            if (ListItems.isListOpen == false)
            {
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");
                input = input.normalized;
                rigidbody.velocity = input * movementSpeed;

                if (rigidbody.velocity.x < 0 && rigidbody.velocity.y != 0) pomniAnimator.SetFloat(Direction, -1f);
                else if (rigidbody.velocity.x > 0 && rigidbody.velocity.y != 0) pomniAnimator.SetFloat(Direction, 1f);
                else if (rigidbody.velocity.x < 0) pomniAnimator.SetFloat(Direction, -1f);
                else if (rigidbody.velocity.x > 0) pomniAnimator.SetFloat(Direction, 1f);
                else pomniAnimator.SetFloat(Direction, -1f);
                
                if (rigidbody.velocity.x != 0 || rigidbody.velocity.y != 0) pomniAnimator.SetBool(Velocity, true);
                else pomniAnimator.SetBool(Velocity, false);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CItemWrapper item = collision.gameObject.GetComponent<CItemWrapper>();
        if (!item) return;

        currentItem = item;
        pickupWindow.SetActive(true);
        pickupWindow.transform.position = collision.gameObject.transform.position + new Vector3(0, 0.7f, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CItemWrapper item = collision.gameObject.GetComponent<CItemWrapper>();
        if (!item) return;
        
        currentItem = null;
        pickupWindow.SetActive(false);
    }
}
