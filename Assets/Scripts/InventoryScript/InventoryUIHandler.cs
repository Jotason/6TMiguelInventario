using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine.Events;
using static UnityEditor.Experimental.GraphView.Port;

public class InventoryUIHandler : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] ItemDataBaseSO itemDataBase;

    [SerializeField] ScrollRect scrollItems;
    [SerializeField] GameObject prefabItemButtom;

    [SerializeField] TextMeshProUGUI itemNamePreviewText;
    [SerializeField] TextMeshProUGUI itemAmountPreviewText;
    [SerializeField] Image itemIconPreviewImage;

    int itemSelectedId = -1;
    List<GameObject> instantiateButtons = new();

    [SerializeField] CanvasGroup previewPanel;

    ItemsFactory factory;


    private void Start()
    {

        factory = gameObject.AddComponent<ItemsFactory>();
        factory.Initialize(itemDataBase);
        //factory.CreateItem(0, Vector3.zero, null);


        SetInventory(inventory);
        InstantiateButtons();
        ShowItems();
    }

    public void SetInventory(Inventory newInventory)
    {
        //ME DESUSCRIBO DE LOS EVENTOS DEL INVENTARIO ANTERIOR
        if (inventory != null)
        {
            inventory.ItemAdded -= ShowItems;

            inventory.ItemRemoved -= ShowItems;
            inventory.ItemRemoved -= HidePreviewPanel;

            inventory.ItemUpdated -= ShowItems;
            inventory.ItemUpdated -= UpdateAmountPreview;

        }
        //CAMBIO EL INVENTARIO 
        inventory = newInventory;


        // ME SUSCRIBO A LOS EVENTOS DEL NUEVO INVENTARIO
        inventory.ItemAdded += ShowItems;

        inventory.ItemRemoved += ShowItems;
        inventory.ItemRemoved += HidePreviewPanel;

        inventory.ItemUpdated += ShowItems;
        inventory.ItemUpdated += UpdateAmountPreview;



    }

    public void InstantiateButtons()
    {
        for (int i = 0; i < itemDataBase.Items.Count; i++)
        {
            GameObject instantiateButton = Instantiate(prefabItemButtom, scrollItems.content);
            instantiateButton.SetActive(false);
            instantiateButtons.Add(instantiateButton);
        }
    }


    public void ShowItems()
    {

        for (int i = 0; i < instantiateButtons.Count; i++)
        {
            instantiateButtons[i].SetActive(false);
        }

        foreach (var item in inventory.Items)
        {
            ItemDataSO itemData = itemDataBase.SearchById(item.Key);

            //GameObject searchedButton = Instantiate(prefabItemButtom, scrollItems.content);

            GameObject searchedButton = instantiateButtons.Find(x => x.activeSelf == false);
            searchedButton.SetActive(true);
            searchedButton.transform.Find("Icon").GetComponent<Image>().sprite = itemData.Icon;
            searchedButton.transform.Find("Icon/Amount").GetComponent<TextMeshProUGUI>().text = item.Value.ToString();
            //searchedButton.transform.Find("Icon/Amount").GetComponent<TMP_Text>().text = itemData.Id.ToString();

            searchedButton.GetComponent<Button>().onClick.AddListener(delegate
             {
                 ShowPreviewPanel();
                 ShowItemPreview(itemData, item.Value);
             }
            );
        }

    }

    public void ShowItemPreview(ItemDataSO itemData, int amount)
    {
        itemSelectedId = itemData.Id;
        itemNamePreviewText.text = itemData.ItemName;
        itemIconPreviewImage.sprite = itemData.Icon;
        itemAmountPreviewText.text = amount.ToString();

    }


    public void DeleteItem()
    {
        inventory.RemoveItem(itemSelectedId, 1);
        //ShowItems();
    }

    public void DropItem()
    {
        DeleteItem();
        factory.CreateItem(itemSelectedId, Vector3.zero, null);

    }

    private void UpdateAmountPreview()
    {
        if (itemSelectedId >= 0)
        {
            itemAmountPreviewText.text = inventory.Items[itemSelectedId].ToString();

        }
    }

    private void ShowPreviewPanel()
    {
        previewPanel.alpha = 1;
        previewPanel.interactable = true;
        previewPanel.blocksRaycasts = true;

    }
    private void HidePreviewPanel()
    {
        previewPanel.alpha = 0;
        previewPanel.interactable = false;
        previewPanel.blocksRaycasts = false;

    }
}
