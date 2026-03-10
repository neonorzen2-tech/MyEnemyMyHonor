using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPointPrefab _spawnPointPrefab; // точка спавна, по идее для того, чтобы определить куда будет спавниться враг
    // с него надо будет трансформ, если с фонарями, то минус по Y.
    [SerializeField] private NPC _enemyPrefab; // просто префаб врага, который будет спавниться( ВОЗМОЖНО) как раз в нем и сделать выбор поведения, но хз.
    private Queue<Vector3> _prefabPosition = new Queue<Vector3>();
    private float offSetY = 5;

    private void Start()
    //Awake() - поменял эвэйк на старт, так ии написал:
    //Почему Start обычно безопаснее для поиска других объектов:
    // еще не доготовлено чтото будет на Awake() ...
    // Awake вызывается, даже если компонент (скрипт) выключен, Start даст более предсказуемый результат. 
    // Если вы ищете объекты, которые сами динамически создают свой контент в Awake. Например, если скрипт «Генератор» создает врагов в своем Awake, то ваш скрипт поиска найдет их только в Start.

    // в эвэйке, когда я размещу перед стартом игры надо будет чтобы в каждой точке
    // где стоит спавн поинт, вызвался враг.
    // т.е. мне тут надо прошерстить сцену, найти трансформы спавнпоинтов и их в список зарядить

    //у них уже к этому моменту должна быть заряжены два типа поведения, т.е. наверное отделным монобех скриптом я могу это навесить на этот скрипт
    //!!!! тут я прописываю, вроде, метод спавна, а что-то должно быть на другом объекте?
    {
        //найти на сцене точки спавна.
        //или можно было бы каждый объект, но это если через инстншиэйт, присваивать переменную... но не мой вариант.

        FindSpawnPoint();
        SpawnTo();
    }

    private void SpawnTo()
    {
        while (_prefabPosition.Count > 0)
        {
            Vector3 spawnPoint = _prefabPosition.Dequeue();
            spawnPoint = new Vector3(spawnPoint.x, spawnPoint.y - offSetY, spawnPoint.z);
            Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity);
        }
    }

    private void FindSpawnPoint()
    {
        SpawnPointPrefab[] spawnPointsPrefab = Object.FindObjectsByType<SpawnPointPrefab>(FindObjectsSortMode.None);
        foreach (var spawnPoint in spawnPointsPrefab)
        {
            Vector3 spawnPointPosition = spawnPoint.transform.position;
            _prefabPosition.Enqueue(spawnPointPosition);
        }
    }
}
//foreach (var pos in _prefabPosition)
//{
//    Vector3 spawnPoint = new Vector3(pos.x, pos.y - offSetY, pos.z);
//    Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity);
//}

//private List<Transform> transformList;
//    [SerializeField] private Transform _spawnPointPrefab;
//[SerializeField] private PlayerController _playerController;
//[SerializeField] private NPC _enemyPrefab;

//private float offSetY = -5;


//private void Awake()
//{
//    transformList = new List<Transform>();
//    //_spawnPointPrefab = GetComponent<SpawnPointPrefab>();
//}

//public void SpawnEnemy()
//{
//    Vector3 SpawnPoint = new Vector3(_spawnPointPrefab.position.x, _spawnPointPrefab.position.y - offSetY, _spawnPointPrefab.position.z);
//    NPC enemy = Instantiate(_enemyPrefab, SpawnPoint, Quaternion.identity);
//    enemy.GetComponent<PlayerController>
//    }

//private List<Transform> SpawnPoints()
//{ return transformList; }
