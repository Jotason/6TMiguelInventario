using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] HealthSystem _health;
    [SerializeField] Inventory inventory;

    public HealthSystem Health { get => _health; set => _health = value; }

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item)) {
            inventory.AddItem(item.Id, 1);
            Destroy(item.gameObject);
        }
    }
}
