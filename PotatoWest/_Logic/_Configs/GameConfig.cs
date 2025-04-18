using PotatoWest._Logic._Core;
using PotatoWest._Player;
using PotatoWest._Player.Configs;
using UnityEngine;
using UnityEngine.Serialization;

namespace PotatoWest._Logic._Configs
{
    [CreateAssetMenu(menuName = "Configs/GameConfig", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private Game gamePrefab;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private LevelsConfig levelsConfig;
      
        public Game GamePrefab => gamePrefab;
        public PlayerConfig PlayerConfig => playerConfig;
        public LevelsConfig LevelsConfig => levelsConfig;
    }
}