using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingBehaviour : MonoBehaviour, IBehavior
{
    private CharacterController _characterController;
    private Mover _mover;
    private Rotator _rotator;

    [SerializeField] private NPC enemyPrefab;
    
    private Queue<Vector3> _patrollPoint;
    private Vector3 _currentTarget;
    
    private float positionMax = -7f;
    private float positionMin = 7f;

    private float _distance = 1.5f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mover = GetComponent<Mover>();
        _rotator = GetComponent<Rotator>();

        if (_characterController == null) Debug.LogError("Нет CharacterController!", this);
        if (_mover == null || _rotator == null) Debug.LogError("Нет MoverRotator!", this);

        _patrollPoint = new Queue<Vector3>();
        GeneratePatrolPoints();
        _currentTarget = CurrentPointCreator(_patrollPoint);
        Vector3 direction = Direction(_currentTarget);
    }

    void Update()
    {    
        Vector3 direction = Direction(_currentTarget);
        if (direction.magnitude <= _distance)
        {

            if (_patrollPoint.Count == 0)
            {
                GeneratePatrolPoints();
            }
            _currentTarget = CurrentPointCreator(_patrollPoint);
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
            Vector3 randomPosition = transform.position + new Vector3(Random.Range(positionMin, positionMax), 0, Random.Range(positionMin, positionMax));
            _patrollPoint.Enqueue(randomPosition);

            Debug.Log(randomPosition);
        }
        return _patrollPoint;
    }

    private Vector3 CurrentPointCreator(Queue<Vector3> patrollPoint)
    {
        _currentTarget = _patrollPoint.Dequeue();
        _patrollPoint.Enqueue(_currentTarget);
        return _currentTarget;
    }

    private Vector3 Direction(Vector3 currentTurget)
    {
        Vector3 direction = new Vector3();
        direction = currentTurget - transform.position;
        return direction;
    }

    public void Execute()
    {
        
    }
}
