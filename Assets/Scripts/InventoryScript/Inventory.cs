using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    Dictionary<int, int> _items = new() {
        {8 , 50 },
        {2 , 15 },
        {0 , 1 }
    };

    public Dictionary<int, int> Items { get => _items; set => _items = value; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SaveItem(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SaveItem(1, 1);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SaveItem(2, 1);
        }
    }

    public void SaveItem(int id, int amount)
    {
        if (Items.ContainsKey(id))
        {
            Items[id] += amount;
        }
        else
        {
            Items.Add(id, amount);
        }

        ShowInventory();
    }
    public void ShowInventory()
    {
        foreach (var item in Items)
        {
            Debug.Log("Cantidad " + item.Key + " Cantidad" + item.Value);
        }
    }

}
