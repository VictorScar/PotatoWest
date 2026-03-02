using UnityEngine;

namespace PotatoWest._Logic._Level
{
    public class NPCSpawn : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private bool _isBusy = false;
        public Transform SpawnPoint => spawnPoint;
        public Transform TargetPoint => transform;

        public bool IsBusy
        {
            get => _isBusy;
            set => _isBusy = value;
        }
    }
}
