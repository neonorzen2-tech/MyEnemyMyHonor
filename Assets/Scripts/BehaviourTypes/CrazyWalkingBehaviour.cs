using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyWalkingBehaviour : IBehaviour
{
    private CharacterController _characterController;
    private Mover _mover;
    private Rotator _rotator;

    private Vector3 _currentTarget;

    private float _timeForTurn = 1f;
    private float _time;

    public CrazyWalkingBehaviour(Mover mover, Rotator rotator)
    {
        _mover = mover;
        _rotator = rotator;

        _currentTarget = Direction();
    }
    public void Execute()
    {
        _time += Time.deltaTime;
        if (_time >= _timeForTurn)
        {
            _currentTarget = Direction();
            _time = 0;
        }
        if (_currentTarget != Vector3.zero)
        {
            _mover.ProcessMoveTo(_currentTarget.normalized / 5);
            _rotator.ProcessRotateTo(_currentTarget.normalized);
        }
    }
       
    private Vector3 Direction()
    {
        Vector2 randomPoint = Random.insideUnitCircle;
        return new Vector3(randomPoint.x, 0, randomPoint.y).normalized;
        //Vector3 direction = new Vector3(Random.Range(0, 360)* Random.Range(8,50), 0, Random.Range(0, 360)* Random.Range(8, 50));
        //return direction;
    }
}
