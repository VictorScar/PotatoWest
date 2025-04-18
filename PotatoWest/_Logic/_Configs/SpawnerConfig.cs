using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PotatoWest._Logic._Configs
{
   [Serializable]
    public struct SpawnerConfig
    {
        [FormerlySerializedAs("aiCharacters")] [SerializeField] private SpawnAIInfo[] aiSpawnData;

        public SpawnAIInfo[] AISpawnData => aiSpawnData;
    }

    [Serializable]
    public struct SpawnAIInfo
    {
        public CharacterAI CharacterAI;
        public int Chance;
    }
}