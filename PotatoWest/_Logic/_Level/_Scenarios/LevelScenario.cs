using System.Threading;
using Cysharp.Threading.Tasks;
using PotatoWest._Logic._Scenarios;
using UnityEngine;

namespace PotatoWest._Logic._Level._Scenarios
{
    public class LevelScenario : GameScenarioBase
    {
        [SerializeField] private Sprite scopeIcon;
        private Vector2 scopeOffset = new Vector2(62.5f,62.5f);
        [SerializeField] private LevelScenarioPart[] scenarioParts;
        protected LevelScenarioData _data;

        public void Init(LevelScenarioData levelScenarioData)
        {
            _data = levelScenarioData;

            if (scenarioParts != null)
            {
                foreach (var part in scenarioParts)
                {
                    part.Init(levelScenarioData);
                }
            }
        }

        protected override async UniTask RunInternal(CancellationToken token)
        {
            Cursor.SetCursor(scopeIcon.texture, scopeOffset, CursorMode.Auto);
            if (scenarioParts != null)
            {
                foreach (var part in scenarioParts)
                {
                    await part.Run(token);
                }
            }
        }

        protected override void OnScenarioEnd()
        {
         
        }
    }
}