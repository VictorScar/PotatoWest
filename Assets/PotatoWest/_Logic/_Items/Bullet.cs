using System;
using System.Collections;
using System.Collections.Generic;
using PotatoWest._Logic._Interactables;
using PotatoWest._Logic._Items;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;

    private MainWeaponBase _weapon;

    public void Init(MainWeaponBase weapon)
    {
        _weapon = weapon;
    }
    
    private void Update()
    {
        rb.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IShootTarget>(out var target))
        {
            target.OnHit(_weapon);
        }
        
        Destroy(gameObject);
    }
}
