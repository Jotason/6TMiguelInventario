using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryUIHandler : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] ItemDataBaseSO itemDataBase;

    [SerializeField] ScrollRect scrollItems;
    [SerializeField] GameObject prefabItemButtom;

    public void InstantiateItems()
    {
        foreach (var item in inventory.Items)
        {
            Instantiate(prefabItemButtom, scrollItems.content);
        }

    }
}
