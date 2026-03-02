using System.Collections.Generic;
using PotatoWest._Logic._AI;
using PotatoWest._Logic._Configs;
using ScarFramework.Button;
using UnityEngine;

namespace PotatoWest._Logic._Level
{
    public class NPCSpawner : MonoBehaviour
    {
        [SerializeField] private NPCSpawn[] spawns;

        private SpawnerConfig _spawnerConfig;
        private List<CharacterAI> _pendingSpawns;
        private Level _level;
        private Dictionary<CharacterAI, NPCSpawn> _spawnedActorsData = new Dictionary<CharacterAI, NPCSpawn>();

        public void Init(Level level, SpawnerConfig spawnerConfig)
        {
            _level = level;
            _spawnerConfig = spawnerConfig;

            ClearSpawnedActors();

            var spawnDatas = _spawnerConfig.AISpawnData;

            if (spawnDatas != null && spawnDatas.Length > 0)
            {
                _pendingSpawns = new List<CharacterAI>();

                foreach (var spawnData in spawnDatas)
                {
                    if (spawnData.Chance > 0)
                    {
                        for (int i = 0; i < spawnData.Chance; i++)
                        {
                            _pendingSpawns.Add(spawnData.CharacterAI);
                        }
                    }
                }
            }
        }


        [Button("Clear")]
        public void ClearSpawnedActors()
        {
            if (_spawnedActorsData != null)
            {
                foreach (var data in _spawnedActorsData)
                {
                    RemoveActor(data.Key);
                }

                _spawnedActorsData.Clear();
            }
        }

        [Button("SpawnNPC")]
        public void Spawn()
        {
            SpawnActor();
        }

        public bool SpawnActor()
        {
            if (GetRandomFreeSpawn(out var spawn))
            {
                var actorPrefab = GetPrefab();

                if (actorPrefab != null)
                {
                    spawn.IsBusy = true;
                    var actor = Instantiate(actorPrefab, spawn.transform.position, spawn.transform.rotation, transform);
                    actor.Init(_level, new SpawnData{EntrancePoint = spawn.TargetPoint.position});
                    actor.onRemove += RemoveActor;
                    _spawnedActorsData.Add(actor, spawn);
                    Debug.Log("Spawn Actor!");
                    return true;
                }
                else
                {
                    Debug.LogError("No prefabs to spawn!");
                    return false;
                }
            }
            else
            {
                Debug.Log("No free spawns");
                return false;
            }
        }

        private void RemoveActor(CharacterAI actor)
        {
            actor.onRemove -= RemoveActor;

            var actorData = _spawnedActorsData[actor];
            actorData.IsBusy = false;

            if (actor)
            {
               Destroy((actor.gameObject));
               //actor.gameObject.SetActive(false);
               //actor.
            }
        }

        private CharacterAI GetPrefab()
        {
            if (_pendingSpawns != null && _pendingSpawns.Count > 0)
            {
                var index = Random.Range(0, _pendingSpawns.Count);
                return _pendingSpawns[index];
            }

            return null;
        }

        private bool GetRandomFreeSpawn(out NPCSpawn spawn)
        {
            if (spawns != null && spawns.Length > 0)
            {
                var spawnIndex = Random.Range(0, spawns.Length);

                if (!spawns[spawnIndex].IsBusy)
                {
                    spawn = spawns[spawnIndex];
                    return true;
                }

                for (int i = spawnIndex; i < spawns.Length; i++)
                {
                    if (!spawns[i].IsBusy)
                    {
                        spawn = spawns[i];
                        return true;
                    }
                }

                for (int i = spawnIndex; i >= 0; i--)
                {
                    if (!spawns[i].IsBusy)
                    {
                        spawn = spawns[i];
                        return true;
                    }
                }
            }

            spawn = null;
            return false;
        }
    }
    
    public struct SpawnData
    {
        public Vector3 EntrancePoint;
    }
}