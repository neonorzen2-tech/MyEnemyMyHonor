using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _moveSpeed = 7;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    

    public void ProcessMoveTo(Vector3 normalized)
    {
        _characterController.Move(normalized * _moveSpeed * Time.deltaTime);
    }

   
}
