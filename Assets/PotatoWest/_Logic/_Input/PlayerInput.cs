using System.Collections;
using System.Collections.Generic;
using PotatoWest._Input.Data;
using UnityEngine;

public abstract class PlayerInput : MonoBehaviour
{
    public abstract bool IsEnabled { set; }
    public abstract InputData Data { get; }
}