using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class InfoWorld
{
    [SerializeField] List<InfoLevel> _levels = new List<InfoLevel>();
    [SerializeField] bool _complete;

    public List<InfoLevel> Levels { get => _levels; set => _levels = value; }
    public bool Complete { get => _complete; set => _complete = value; }
}
