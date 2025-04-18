using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using PotatoWest._Logic._Level;
using UnityEngine;

public class LevelScenario : MonoBehaviour
{
    private LevelScenarioData _data;

    public void Init(LevelScenarioData levelScenarioData)
    {
        _data = levelScenarioData;
    }

    public async UniTask Run(CancellationToken token)
    {
        await UniTask.WaitForSeconds(5f, cancellationToken: token);
        _data.NpcSpawner.SpawnActor();
        // _data.
    }
}