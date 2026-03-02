using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace PotatoWest._Logic._Level
{
    public class NPCSpawn : MonoBehaviour
    {
        [SerializeField] private SpawnerData spawnerData;
        [SerializeField] private bool _isBusy = false;

        public Transform SpawnPoint => transform;

        public Transform TargetPoint
        {
            get { return GetRandomTargetAtSpawner(); }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => _isBusy = value;
        }

        private Transform GetRandomTargetAtSpawner()
        {
            var targets = spawnerData.Targets;
            
            if (targets != null && targets.Length > 0)
            {
                return targets[Random.Range(0, targets.Length)];
            }

            return null;
        }
    }

    [Serializable]
    public struct SpawnerData
    {
        public Transform[] Targets;
    }
}