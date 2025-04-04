using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    Dictionary<int, int> _items = new() {
        {8 , 50 },
        {2 , 15 }
        //{0 , 1 }
    };

    public Dictionary<int, int> Items { get => _items; set => _items = value; }


    private void Start()
    {
        ShowInventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SaveItem(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RemoveItem(2, 5);
        }
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    SaveItem(2, 1);
        //}
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

    public void RemoveItem(int id, int amount)
    {
        if (_items.ContainsKey(id))
        {
            _items[id] -= amount;
            if (_items[id] <= 0)
            {
                _items.Remove(id);
            }
        }

        ShowInventory();
    }

    

}
