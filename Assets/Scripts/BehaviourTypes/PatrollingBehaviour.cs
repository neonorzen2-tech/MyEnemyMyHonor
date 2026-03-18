using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PatrollingBehaviour : IBehaviour
{
    private CharacterController _characterController;
    private Mover _mover;
    private Rotator _rotator;
    private Transform _transform;

    private Queue<Vector3> _patrollPoint;
    private Vector3 _currentTarget;
    
    private float positionMax = 7f;
    private float positionMin = -7f;

    private float _distance = 1.5f;
    public PatrollingBehaviour(Mover mover, Rotator rotator, Transform transform)
    {
        _mover = mover;
        _rotator = rotator;
        _transform = transform;

         _patrollPoint = new Queue<Vector3>();
        GeneratePatrolPoints();
        _currentTarget = CurrentPointCreator(_patrollPoint);        
    }

    public void Execute()
    {
         Vector3 direction = Direction(_currentTarget);
        if (direction.magnitude <= _distance)
        {
            _currentTarget = CurrentPointCreator(_patrollPoint);
            direction = Direction(_currentTarget);
        }
        direction = direction.normalized;
        _mover.ProcessMoveTo(direction);
        _rotator.ProcessRotateTo(direction);
    }    

    private Queue<Vector3> GeneratePatrolPoints()
    {

        int numberOfPoints = 5;
        for (int i = 0; i < numberOfPoints; i++)
        {
            Vector3 randomPosition = _transform.position + new Vector3(Random.Range(positionMin, positionMax), 0, Random.Range(positionMin, positionMax));
            _patrollPoint.Enqueue(randomPosition);

            Debug.Log(randomPosition);
        }
        return _patrollPoint;
    }

    private Vector3 CurrentPointCreator(Queue<Vector3> patrollPoint)
    {
        Vector3 point = patrollPoint.Dequeue();
        patrollPoint.Enqueue(point);
        return point;
    }

    private Vector3 Direction(Vector3 currentTurget)
    {
        //Vector3 direction = new Vector3();
        //direction = currentTurget - _transform.position;
        //return direction;
        return currentTurget - _transform.position;
    }
}
