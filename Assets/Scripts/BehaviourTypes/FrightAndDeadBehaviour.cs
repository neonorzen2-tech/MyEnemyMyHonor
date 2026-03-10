using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class FrightAndDeadBehaviour : MonoBehaviour
{
    private float _currentScale;
    private float _currentScaleTwo;
    private float _currentScaleResult;
    private float _rotateSpeed = 33;
    //[SerializeField] private ParticleSystem _particleSisPrefab;


    private void Awake()
    {
        _currentScale = transform.localScale.y;
        //_particleSisPrefab = GetComponent<ParticleSystem>();
        //_particleSisPrefab.transform.position = transform.position;

    }
    private void Update()
    {
        if(_currentScale<0)
            Destroy(gameObject);
        transform.Rotate(0, _rotateSpeed, 0);
        _currentScale -= Time.deltaTime/5;
        _currentScaleTwo += Time.deltaTime/8;
        _currentScaleResult = Random.Range(_currentScale, _currentScaleTwo);
        transform.localScale = new Vector3(_currentScaleResult, _currentScaleResult, _currentScaleResult);
    }
}

//private CharacterController _characterController;
//    private PlayerController _target;
//    private Mover _mover;
//    private Rotator _rotator;

//    private Vector3 _patrollPoint;

//    private List<Vector3> directions;

//    private float _safetyDistance = 5f;

//    private float _positionY;

//    private void Awake()
//{

//    GameObject playerObject = GameObject.FindWithTag("Player");
//    if (playerObject != null)
//    {
//        Debug.Log("2 good");
//        _target = playerObject.GetComponent<PlayerController>();
//    }
//    else
//        Debug.Log("5 good");

//    _characterController = GetComponent<CharacterController>();
//    _mover = GetComponent<Mover>();
//    _rotator = GetComponent<Rotator>();

//    if (_characterController == null || _mover == null || _rotator == null)
//        Debug.LogError("Нет какогото компонента");
//    _positionY = transform.position.y;


//}

//private void Update()
//{
//    if (Direction().magnitude < _safetyDistance)
//    {
//        Debug.Log("1 good");
//        Vector3 direction = Direction().normalized;
//        _mover.ProcessMoveTo(direction);
//        _rotator.ProcessRotateTo(direction);
//    }
//    else
//        return;

//    Vector3 positionEnemy = transform.position;
//    positionEnemy.y = _positionY;
//    transform.position = positionEnemy;
//}

//private Queue<Vector3> GeneratePatrolPoints()
//{
//    int numberOfPoints = 5;
//    for (int i = 0; i < numberOfPoints; i++)
//    {
//        Vector3 randomPosition = transform.localPosition + new Vector3(Random.Range(positionMin, positionMax), 0, Random.Range(positionMin, positionMax));
//        _patrollPoint.Enqueue(randomPosition);

//        Debug.Log(randomPosition);
//    }
//    Debug.Log(" очередь сформирована");
//    return _patrollPoint;
//}

//private Vector3 CurrentPointCreator(Queue<Vector3> patrollPoint)
//{
//    _currentTarget = _patrollPoint.Dequeue();
//    _patrollPoint.Enqueue(_currentTarget);
//    Debug.Log(" Точка найдена");
//    return _currentTarget;
//}

//private Vector3 Direction(Vector3 currentTurget)
//{
//    Vector3 direction = new Vector3();
//    direction = currentTurget - transform.position;
//    Debug.Log(" направление есть");
//    return direction;
//}