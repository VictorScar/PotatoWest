using Cysharp.Threading.Tasks;
using PotatoWest._Logic._AI.Components._AIStates;
using PotatoWest._Logic._Items;
using PotatoWest._Logic._Player._Components;
using PotatoWest._Logic._Player._Components._Inventory;
using UnityEngine;

namespace PotatoWest._Logic._AI
{
    public class EnemyAI : CharacterAI
    {
        [SerializeField] private EquipManager equipManager;
        [SerializeField] private CharacterInventory inventory;
        [SerializeField] private AIShootSystem shootingController;


        protected override void OnInit()
        {
            shootingController.Init(new AIShootSystemData
                { ShootDelay = 2f, EquipManager = equipManager, Mover = _mover });
            stateController.Init(new AIStateContext{ShootController = shootingController, Mover = _mover, Animator = _animator, Level = _level, Parameters = parameters});
        }

        protected override UniTask DoAction()
        {
            stateController.SetState<DefaultAiState>();
            stateController.SetState<AttackAIState>();
            return UniTask.CompletedTask;
        }

        public override void OnHit(MainWeaponBase mainWeapon)
        {
            base.OnHit(mainWeapon);
            Debug.Log("Hit enemy!");
        }
    }
}