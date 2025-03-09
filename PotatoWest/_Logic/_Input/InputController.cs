using System.Collections;
using System.Collections.Generic;
using PotatoWest._Player;
using UnityEngine;

public class InputController
{
    private PlayerInput _input;
    private PlayerPawn _pawn;
    private MenuController _menuController;

    public InputController(PlayerInput input, PlayerPawn pawn, MenuController menuController)
    {
        _input = input;
        _pawn = pawn;
        _menuController = menuController;
    }


    public void Update(float deltaTime)
    {
        var inputData = _input.Data;
        _pawn?.SetInputs(inputData);
        _menuController?.SetInputs(inputData);
    }
}