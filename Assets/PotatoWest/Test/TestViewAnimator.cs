using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class TestViewAnimator
{
    [SerializeField] protected float duration;
    [SerializeField] public float df;
}

[Serializable]
public class ConcreteAnimator : TestViewAnimator
{
    public string Desc;
}

