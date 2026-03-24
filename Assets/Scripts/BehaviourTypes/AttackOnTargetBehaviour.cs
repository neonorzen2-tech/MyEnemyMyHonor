using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AttackOnTargetBehaviour : IBehaviour
{
    private Transform _transform;
    [SerializeField] private PlayerController _target;
    private Mover _mover;
    private Rotator _rotator;

    private float _positionY;

    public AttackOnTargetBehaviour(Mover mover, Rotator rotator, Transform transform)
    {
        _transform = transform;
        _mover = mover;
        _rotator = rotator;

        _positionY = transform.position.y;

    }
    public void Execute()
    {
        _mover.ProcessMoveTo(TargetDirection(_transform));
        _rotator.ProcessRotateTo(TargetDirection(_transform));

        Vector3 positionEnemy = _transform.position;
        positionEnemy.y = _positionY;
        _transform.position = positionEnemy;
    }

    private Vector3 TargetDirection(Transform target)
    {
        Vector3 targetDirection = new Vector3();
        targetDirection = target.transform.position - _transform.position;

        return targetDirection.normalized;
    }
    //TargetDirection(Transform target)
    //_mover.ProcessMoveTo(TargetDirection(_transform));
    //_rotator.ProcessRotateTo(TargetDirection(_transform));
    // тут был PlayerController _target;, я поменял, коммент жени от 19.03. если вдруг работать не будет
}
