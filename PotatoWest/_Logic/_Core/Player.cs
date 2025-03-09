using System;
using PotatoWest._Logic._Configs;
using PotatoWest._Player;
using PotatoWest._Player.Configs;
using UnityEngine;

namespace PotatoWest._Logic._Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInput input;
        [SerializeField] private PlayerPawn _pawn;
        
        private InputController _inputController;
        private PlayerConfig _config;
        
        public void Init(PlayerConfig playerConfig)
        {
            _config = playerConfig;
            if (_pawn == null)
            {
                _pawn = CreatePawn();
            }
            
            _pawn.Init(_config.PawnConfig);
            _inputController = new InputController(input, _pawn, null);
            input.IsEnabled = true;
        }

        private PlayerPawn CreatePawn()
        {
            var pawn = Instantiate(_config.PlayerPawnPrefab, transform);
            return pawn;
        }

        private void Update()
        {
            if (_pawn != null)
            {
                _inputController?.Update(Time.deltaTime);
            }
        }
    }
}
