using System;
using PotatoWest._Logic._Configs;
using UnityEngine;
using UnityEngine.Serialization;

namespace PotatoWest._Logic._Core
{
    public class MainGameController : MonoBehaviour
    {
        [SerializeField] private GameConfig config;
       [SerializeField] private PlayerController playerController;
        private string serviceProvider;
        
        public static MainGameController I { get; private set; }

        private void Awake()
        {
            if (I == null)
            {
                I = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            
            playerController.Init(config.PlayerConfig);
        }
        
        

        public void Init()
        {
            
        }
    }
}
