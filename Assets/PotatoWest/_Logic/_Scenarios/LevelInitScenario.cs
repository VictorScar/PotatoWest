using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using PotatoWest._Logic._Level._Scenarios;
using UnityEngine;

public class LevelInitScenario : LevelScenarioPart
{
    protected override UniTask RunInternal(CancellationToken token)
    {
       return UniTask.CompletedTask;
    }
}
