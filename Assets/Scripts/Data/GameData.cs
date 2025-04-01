using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]

public class GameData
{
    [SerializeField] List<PlayerData> _player = new List<PlayerData>();
    [SerializeField] List<InfoWorld> _world = new List<InfoWorld>();

    public List<PlayerData> Player { get => _player; set => _player = value; }
    public List<InfoWorld> World { get => _world; set => _world = value; }
}
