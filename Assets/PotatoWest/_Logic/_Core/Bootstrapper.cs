using System;
using PotatoWest._Logic._Configs;
using UnityEngine;

namespace PotatoWest._Logic._Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameConfig gameConfig;
        private Game _game;

        private void Start()
        {
            Boot();
        }

        private void Boot()
        {
            _game = Instantiate(gameConfig.GamePrefab);
            _game.Init(gameConfig);
        }

        public void Reboot()
        {
            if (_game != null)
            {
                Destroy(_game.gameObject);
            }

            Boot();
        }
    }
}