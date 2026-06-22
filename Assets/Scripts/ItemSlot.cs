using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // ITEM DATA
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    [SerializeField] int maxItems;

    // ITEM SLOT
    [SerializeField] TMP_Text quantityText;
    [SerializeField] Image itemImage;

    // ITEM DESCRIPTION DATA
    public Image descriptionImage;
    public TMP_Text descriptionNameText;
    public TMP_Text descriptionText;

    // SLOT SELECTION
    public GameObject selectedShader;
    public bool isSelected;

    // INVENTORY MANAGER
    InventoryManager inventoryManager;
    
    void Start()
    {
        inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        // Check if slot is full
        if (isFull)
        {
            return quantity;
        }

        // Updaye NAME
        this.itemName = itemName;

        // Update IMAGE
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        itemImage.gameObject.SetActive(true);

        // Update DESCRIPTION
        this.itemDescription = itemDescription;

        // Update QUANTITY
        this.quantity += quantity;
        if(this.quantity >= maxItems)
        {
            // IF quantity is higher than max, set quantity to full
            quantityText.text = maxItems.ToString();
            quantityText.gameObject.SetActive(true);
            isFull = true;

            // Calculate leftovers
            int extraItems = this.quantity - maxItems;
            this.quantity = maxItems;
            return extraItems;
        }
        quantityText.text = this.quantity.ToString();
        quantityText.gameObject.SetActive(true);

        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        isSelected = true;
        descriptionNameText.text = itemName;
        descriptionText.text = itemDescription;
        descriptionImage.sprite = itemSprite;
        
        if(descriptionImage.sprite == null)
        {
            descriptionImage.sprite = emptySprite;
        }
    }

    public void OnRightClick()
    {
        
    }
}
