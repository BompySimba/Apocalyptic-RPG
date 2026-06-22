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

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.gameObject.SetActive( true);
        itemImage.sprite = itemSprite;
        itemImage.gameObject.SetActive(true);
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
    }

    public void OnRightClick()
    {
        
    }
}
