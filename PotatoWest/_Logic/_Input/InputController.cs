using System.Collections;
using System.Collections.Generic;
using PotatoWest._Input.Data;
using PotatoWest._Player;
using UnityEngine;

public class InputController
{
    private PlayerInput _input;
   private MenuController _menuController;

   private InputData _inputData;

   public InputData InputData => _inputData;

    public InputController(PlayerInput input, PlayerPawn pawn, MenuController menuController)
    {
        _input = input;
      
        _menuController = menuController;
    }


    public void Update(float deltaTime)
    {
        _inputData = _input.Data;
        
        _menuController?.SetInputs(_inputData);
    }
}