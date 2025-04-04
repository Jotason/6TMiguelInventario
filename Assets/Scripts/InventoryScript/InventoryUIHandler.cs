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

    private void Start()
    {
        InstantiateItems();
    }


    public void InstantiateItems()
    {
        foreach (var item in inventory.Items)
        {
            ItemDataSO itemData = itemDataBase.SearchById(item.Key);



            GameObject instantiateButton = Instantiate(prefabItemButtom, scrollItems.content);

            instantiateButton.transform.Find("Icon").GetComponent<Image>().sprite = itemData.Icon;
            instantiateButton.transform.Find("Icon/Amount").GetComponent<TextMeshProUGUI>().text = item.Value.ToString();
            //instantiateButton.transform.Find("Icon/Amount").GetComponent<TMP_Text>().text = itemData.Id.ToString();

            instantiateButton.GetComponent<Button>().onClick.AddListener(delegate
             {
                 ShowItemPreview(itemData, item.Value);
             }
            );
        }

    }

    public void ShowItemPreview(ItemDataSO itemData, int amount)
    {
        itemNamePreviewText.text = itemData.ItemName;
        itemIconPreviewImage.sprite = itemData.Icon;
        itemAmountPreviewText.text = amount.ToString();

    }


    public void DeleteItem()
    {

    }
}
