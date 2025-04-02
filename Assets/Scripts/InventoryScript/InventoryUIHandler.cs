using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;

public class InventoryUIHandler : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] ItemDataBaseSO itemDataBase;

    [SerializeField] ScrollRect scrollItems;
    [SerializeField] GameObject prefabItemButtom;


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
        }

    }
}
