using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PotatoWest._Logic._Scenarios
{
    public abstract class GameScenarioBase : MonoBehaviour
    {
        protected CancellationTokenSource _internalTokenSource;
        
        public void Init()
        {
            OnInit();
        }

        protected virtual void OnInit()
        {
            
        }

        public async UniTask Run(CancellationToken token)
        {
            _internalTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token);
            await OnBeforeScenario(_internalTokenSource.Token);
            await RunInternal(_internalTokenSource.Token);
            OnScenarioEnd();
        }

        protected abstract UniTask RunInternal(CancellationToken token);
  

        protected virtual UniTask OnBeforeScenario(CancellationToken token)
        {
            return UniTask.CompletedTask;
        }

        public void EndScenario()
        {
            OnScenarioEnd();
        }

        protected virtual void OnScenarioEnd()
        {
            
        }
    }
}