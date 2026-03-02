using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    private Collider col;

    public event Action<Collider> onEnter;
    public event Action<Collider> onExit;
    public event Action<Collider> onStay;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnEnter");
        onEnter?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
      //  Debug.Log("OnExit");
        onExit?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("OnStay");
        onStay?.Invoke(other);
    }
}