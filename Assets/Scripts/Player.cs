using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem;

public class Player : MonoBehaviour
{
    Vector3 input; // The axis for movement input [wsad]
    float movementSpeed = 10;

    [SerializeField] Collider2D itemPickupArea;
    CItemWrapper currentItem; // Current item the player is looking at
    GameObject pickupWindow; // The window that pops up when player gets near item
    GameManager gameManager;

    new Rigidbody2D rigidbody;  

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;

        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.freezeRotation = true;

        pickupWindow = gameManager.pickupWindow;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Is the player near an item?
            if (currentItem)
            {
                Debug.Log("Item picked up");
                gameManager.InventoryManager.addItem(currentItem.item(), 0); // <-- TO CHANGE, currently picks up to slot zero
                Destroy(currentItem.gameObject);
                currentItem = null;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement:
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input = input.normalized;
        rigidbody.velocity = input * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CItemWrapper item = collision.gameObject.GetComponent<CItemWrapper>();
        if (!item)
            return;

        currentItem = item;
        pickupWindow.SetActive(true);
        pickupWindow.transform.position = collision.gameObject.transform.position + new Vector3(0, 1, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentItem = null;
        pickupWindow.SetActive(false);
    }
}
