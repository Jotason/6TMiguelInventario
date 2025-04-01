using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InfoLevel
{
    [SerializeField] bool _complete;
    [SerializeField] int _bestScore;

    public bool Complete { get => _complete; set => _complete = value; }
    public int BestScore { get => _bestScore; set => _bestScore = value; }
}
