using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PotatoWest._Logic._Scenarios
{
    public abstract class GameScenarioBase<TScenarioData> : MonoBehaviour where TScenarioData: IScenarioData
    {
        protected CancellationTokenSource _internalTokenSource;
        protected TScenarioData Data;
        
        public void Init(TScenarioData scenarioData)
        {
            Data = scenarioData;
            OnInit(scenarioData);
        }

        protected virtual void OnInit(TScenarioData scenarioData)
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

    public interface IScenarioData
    {
        
    }
}