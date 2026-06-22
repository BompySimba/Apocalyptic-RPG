using JetBrains.Annotations;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] string itemName;
    [SerializeField] int quantity;
    [SerializeField] Sprite itemSprite;
    [TextArea] [SerializeField] string itemDescription;
    
    InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventoryManager.AddItem(itemName, quantity, itemSprite, itemDescription);
            Destroy(gameObject);
        }
    }
}
