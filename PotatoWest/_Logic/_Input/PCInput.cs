using System;
using System.Collections;
using System.Collections.Generic;
using PotatoWest._Input.Data;
using UnityEngine;

public class PCInput : PlayerInput
{
    [Header("Move Inputs")] [SerializeField]
    private KeyCode positiveForwardKey = KeyCode.W;

    [SerializeField] private KeyCode negativeForwardKey = KeyCode.S;
    [SerializeField] private KeyCode positiveRightKey = KeyCode.D;
    [SerializeField] private KeyCode negativeRightKey = KeyCode.A;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    [Header("Utill Inputs")] [SerializeField]
    private KeyCode openMenuKey = KeyCode.Q;

    [SerializeField] private InputData _data;
    private bool isEnabled = false;

    public override bool IsEnabled
    {
        set => isEnabled = value;
    }

    public override InputData Data => _data;

    private void Update()
    {
        if (isEnabled)
        {
            var inputdata = new InputData();
            inputdata.MoveInput = new Vector2();

            inputdata.MoveInput.x = Convert.ToInt32(Input.GetKey(positiveForwardKey)) -
                                  Convert.ToInt32(Input.GetKey(negativeForwardKey));
            inputdata.MoveInput.y = Convert.ToInt32(Input.GetKey(positiveRightKey)) -
                                     Convert.ToInt32(Input.GetKey(negativeRightKey));

            inputdata.ShootInputData = GetShootInputData();
            inputdata.JumpKeyData = GetKeyData(jumpKey);
            _data = inputdata;
        }
    }

    private KeyActionInfo GetKeyData(KeyCode keyCode)
    {
        var keyActionInfo = new KeyActionInfo();

        keyActionInfo.IsPressed = Input.GetKey(keyCode);
        keyActionInfo.HasBeenPressed = keyActionInfo.IsPressed;

        keyActionInfo.HasBeenReleased = !_data.JumpKeyData.IsPressed;

        return keyActionInfo;
    }

    private ShootInputData GetShootInputData()
    {
        var shootInput = new ShootInputData();
        shootInput.ScopePosition = Input.mousePosition;

        var shootBtnInfo = new KeyActionInfo();

        shootBtnInfo.IsPressed = Input.GetMouseButton(0);
        shootBtnInfo.HasBeenPressed = shootBtnInfo.IsPressed;

        shootBtnInfo.HasBeenReleased = !_data.ShootInputData.ShootKeyInfo.IsPressed;

        shootInput.ShootKeyInfo = shootBtnInfo;

        return shootInput;
    }
}