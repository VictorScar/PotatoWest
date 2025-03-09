using PotatoWest._Player;
using PotatoWest._Player.Configs;
using UnityEngine;

namespace PotatoWest._Logic._Configs
{
    [CreateAssetMenu(menuName = "Configs/GameConfig", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private PlayerConfig playerConfig;
        //[SerializeField] private CameraControllerConfig cameraConfig;
       
        public PlayerConfig PlayerConfig => playerConfig;
    }
}