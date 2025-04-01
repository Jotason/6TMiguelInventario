using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class PlayerData
{
    [SerializeField] string name;
    [SerializeField] int life;
    [SerializeField] int money;

    public string Name { get => name; set => name = value; }
    public int Life { get => life; set => life = value; }
    public int Money { get => money; set => money = value; }
}
