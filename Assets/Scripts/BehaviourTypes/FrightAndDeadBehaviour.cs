using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class FrightAndDeadBehaviour : Destroer, IBehaviour
{
    private float _currentScale;
    private float _currentScaleTwo;
    private float _currentScaleResult;
    private float _rotateSpeed = 33;
    private Destroer _destroer;
    private GameObject _gameObject;



    public FrightAndDeadBehaviour(GameObject gameObject, Destroer destroer)
    {
        _destroer = destroer;
        _gameObject = gameObject;
        _currentScale = _gameObject.transform.localScale.y;
    }

    public void Execute()
    {
        if (_currentScale < 0)
            _destroer.DestroyMethod(_gameObject);
        _gameObject.transform.Rotate(0, _rotateSpeed, 0);
        _currentScale -= Time.deltaTime / 5;
        _currentScaleTwo += Time.deltaTime / 8;
        _currentScaleResult = Random.Range(_currentScale, _currentScaleTwo);
        _gameObject.transform.localScale = new Vector3(_currentScaleResult, _currentScaleResult, _currentScaleResult);
    }

    //[SerializeField] private ParticleSystem _particleSisPrefab;


    
        
        //_particleSisPrefab = GetComponent<ParticleSystem>();
        //_particleSisPrefab.transform.position = transform.position;

   
}

public class Destroer: MonoBehaviour
{
    public void DestroyMethod(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}

