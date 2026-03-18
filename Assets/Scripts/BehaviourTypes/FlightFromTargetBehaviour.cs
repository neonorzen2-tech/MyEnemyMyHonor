using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class FlightFromTargetBehaviour : IBehaviour
{
    private Transform _transformPlayer;
    
    private Mover _mover;
    private Rotator _rotator;

    private float _safetyDistance = 5f;
    private float _positionY;

    public FlightFromTargetBehaviour(Mover mover, Rotator rotator, Transform transformPlayer)
    {
        _mover = mover;
        _rotator = rotator;
        _transformPlayer = transformPlayer;
        _positionY = _transformPlayer.position.y;
    }

    public void Execute()
    {
        if (TargetDirection(_transformPlayer).magnitude < _safetyDistance)
        {
            Vector3 direction = -TargetDirection(_transformPlayer).normalized;
            _mover.ProcessMoveTo(direction);
            _rotator.ProcessRotateTo(direction);
        }
        else
            return;

        Vector3 positionEnemy = _transformPlayer.position;
        positionEnemy.y = _positionY;
        _transformPlayer.position = positionEnemy;
    }

    private Vector3 TargetDirection(Transform target)
    {
        Vector3 targetDirection = new Vector3();
        targetDirection = target.position - _transformPlayer.position;

        return targetDirection;
    }
}
