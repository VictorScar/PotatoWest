using System;
using System.Collections;
using System.Collections.Generic;
using PotatoWest._Logic._Level;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public struct LevelConfigData
{
    [SerializeField] private Level levelPrefab;

    
    public Level LevelPrefab => levelPrefab;
}