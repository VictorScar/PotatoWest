using PotatoWest._Player;
using PotatoWest._Player.Configs;
using UnityEngine;

namespace PotatoWest._Logic._Configs
{
    [CreateAssetMenu(menuName = "Configs/Player", fileName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private PlayerPawn playerPawnPrefab;
        [SerializeField] private CameraControllerConfig cameraControllerConfig;
        [SerializeField] private PlayerPawnConfig pawnConfig;

        public CameraControllerConfig CameraControllerConfig => cameraControllerConfig;
        public PlayerPawn PlayerPawnPrefab => playerPawnPrefab;
        public PlayerPawnConfig PawnConfig => pawnConfig;
    }
}