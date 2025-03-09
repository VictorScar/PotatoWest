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

            inputdata.FAxis = Convert.ToInt32(Input.GetKey(positiveForwardKey)) -
                              Convert.ToInt32(Input.GetKey(negativeForwardKey));
            inputdata.RAxis = Convert.ToInt32(Input.GetKey(positiveRightKey)) -
                              Convert.ToInt32(Input.GetKey(negativeRightKey));

            inputdata.ShootInputData = GetShootInputData();

            _data = inputdata;
        }
    }

    private ShootInputData GetShootInputData()
    {
        var shootInput = new ShootInputData();
        shootInput.ScopePosition = Input.mousePosition;

        var shootBtnInfo = new KeyActionInfo();

        shootBtnInfo.IsPressed = Input.GetMouseButton(0);
        shootBtnInfo.HasBeenPressed = true;

        shootBtnInfo.HasBeenReleased = !_data.ShootInputData.ShootKeyInfo.IsPressed;

        shootInput.ShootKeyInfo = shootBtnInfo;

        return shootInput;
    }
}