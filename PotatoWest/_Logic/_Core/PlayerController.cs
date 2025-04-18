using System;
using PotatoWest._Logic._Configs;
using PotatoWest._Player;
using PotatoWest._Player.Configs;
using UnityEngine;

namespace PotatoWest._Logic._Core
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInput input;
        [SerializeField] private PlayerPawn _pawn;
        
        private InputController _inputController;
        private PlayerConfig _config;
        
        public void Init(PlayerConfig playerConfig)
        {
            _config = playerConfig;
            
            _inputController = new InputController(input, _pawn, null);
            input.IsEnabled = true;
        }

        public PlayerPawn SpawnPawn(Vector3 spawnPosition, Quaternion spawnRotation, Transform parent)
        {
            _pawn = Instantiate(_config.PlayerPawnPrefab, parent);
            _pawn.transform.position = spawnPosition;
            _pawn.transform.rotation = spawnRotation;
            return _pawn;
        }

        private void Update()
        {
            if (_pawn != null)
            {
                _inputController?.Update(Time.deltaTime);
                _pawn.SetInputs(_inputController.InputData);
            }
        }
    }
}
