using PotatoWest._Input.Data;
using PotatoWest._Logic._Configs;
using PotatoWest._Logic._Items;
using PotatoWest._Logic._Player._Components;
using PotatoWest._Logic._Player._Components._Inventory;
using PotatoWest._Player._Components;
using PotatoWest._Player.Configs;
using UnityEngine;

namespace PotatoWest._Player
{
    public class PlayerPawn : MonoBehaviour
    {
        [SerializeField] private PlayerCameraController camController;
        [SerializeField] private PlayerMover mover;
        [SerializeField] private EquipManager equipManager;
        [SerializeField] private CharacterInventory inventory;
        [SerializeField] private PlayerShootingController shootingController;
        [SerializeField] private CharacterController characterController;
        private PlayerPawnConfig _playerConfig;

        public void Init(PlayerPawnConfig config)
        {
            _playerConfig = config;
            camController?.Init(null);
            mover?.Init(characterController);
            inventory?.Init(config.StartItems, config.InventorySize);
            equipManager.Init(inventory);
            shootingController?.Init(camController.PlayerCamera, equipManager);
        }

        public void SetInputs(InputData inputData)
        {
            mover.Move(inputData.MoveInput.x, _playerConfig.MoveSpeed);
            mover.Rotate(inputData.MoveInput.y, _playerConfig.RotateSpeed);

            if (inputData.JumpKeyData.IsPressed && inputData.JumpKeyData.HasBeenReleased)
            {
                mover.Jump(_playerConfig.JumpForce);
            }

            shootingController.SetInputs(inputData.ShootInputData);
        }
    }
}