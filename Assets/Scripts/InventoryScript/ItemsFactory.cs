using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsFactory : MonoBehaviour
{
    ItemDataBaseSO database;
    public ItemsFactory(ItemDataBaseSO database)
    {
        this.database = database;
    }
    public void CreateItem(int id, Vector3 position, Transform parent)
    {
        ItemDataSO searchedItem = database.SearchById(id);
        GameObject instantiateItem = Instantiate(searchedItem.Prefab, parent);
        instantiateItem.transform.position = position;
    }

    public void Initialize(ItemDataBaseSO database)
    {
        this.database = database;
    }
}
