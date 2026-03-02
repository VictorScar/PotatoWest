using UnityEngine;

namespace PotatoWest._Logic._Configs
{
    [CreateAssetMenu(menuName = "Configs/LevelDatas", fileName = "LevelData")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private SpawnerConfig spawnerConfig;
        [SerializeField] private string[] stages;

        public SpawnerConfig SpawnerConfig => spawnerConfig;
    }
}
