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
        _transform  = transform;
        _mover = mover;
        _rotator = rotator;

        _positionY = transform.position.y;

    }
 public void Execute()
    {
        _mover.ProcessMoveTo(TargetDirection(_target));
        _rotator.ProcessRotateTo(TargetDirection(_target));

        Vector3 positionEnemy = _transform.position;
        positionEnemy.y = _positionY;
        _transform.position = positionEnemy;
    }
    
    private Vector3 TargetDirection(PlayerController target)
    {
        Vector3 targetDirection = new Vector3();
        targetDirection = target.transform.position - _transform.position;

        return targetDirection.normalized;
    }
   
}
