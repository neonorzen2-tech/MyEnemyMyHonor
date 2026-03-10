using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class FlightFromTargetBehaviour : MonoBehaviour, IBehavior
{
    private CharacterController _characterController;
    private PlayerController _target;
    private Mover _mover;
    private Rotator _rotator;

    private float _safetyDistance = 5f;

    private float _positionY;

    private void Awake()
    { 

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            _target = playerObject.GetComponent<PlayerController>();
        }
        
        _characterController = GetComponent<CharacterController>();
        _mover = GetComponent<Mover>();
        _rotator = GetComponent<Rotator>();

        if (_characterController == null || _mover == null || _rotator == null)
            Debug.LogError("Нет какогото компонента");
        _positionY = transform.position.y;

       
    }

    private void Update()
    {        
        if (TargetDirection(_target).magnitude < _safetyDistance)
        {
            Vector3 direction = -TargetDirection(_target).normalized;
            _mover.ProcessMoveTo(direction);
            _rotator.ProcessRotateTo(direction);
        }
        else 
            return;

        Vector3 positionEnemy = transform.position;
        positionEnemy.y = _positionY;
        transform.position = positionEnemy;
    }

    private Vector3 TargetDirection(PlayerController target)
    {
        Vector3 targetDirection = new Vector3();
        targetDirection = target.transform.position - transform.position;
        
        return targetDirection;
    }

    public void Execute()
    {
        
    }
}
