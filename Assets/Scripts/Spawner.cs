using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint _spawnPointPrefab; 
    
    [SerializeField] private NPC _enemyPrefab;

    //У него есть ссылка на префаб NPC.Можно ему прокинуть ссылки в
    //явном виде на NPCBehabiorChoise на сцене
    //(сделать List<NPCBehabiorChoise> с[SerializeField}
    //и в инспекторе на сцене прокинуть)
    //ВОТ ЭТО НЕ ДОГОНЯЮ ТОЖЕ, как прокинуть ссылки на NPCBehabiorChoise, т.е. он висит на вытянутых объектах
    // инстансах спавнпоинтов и спавнпоинты закидывать в лист?
    [SerializeField] private  List<NPCBehaviourChoise> npcBehaviourChoises;

    private Queue<SpawnPoint> _prefabPosition = new Queue<SpawnPoint>();
    private float offSetY = 4;

    private List<NPC> _spawnedEnemies;

    private void Start()    
    {        
        FindSpawnPoint();
        SpawnTo();
    }

    public List<NPC> SpawnTo()
    {
        _spawnedEnemies = new List<NPC>();
        while (_prefabPosition.Count > 0)
        {
            SpawnPoint spawnPoint = _prefabPosition.Dequeue();
            Vector3 spawnPointPosition = spawnPoint.transform.position;
            spawnPointPosition.y -= offSetY;
            NPC newEnemy = Instantiate(_enemyPrefab, spawnPointPosition, Quaternion.identity);

            _spawnedEnemies.Add(newEnemy);
        }
        Debug.Log(_spawnedEnemies.Count + "Count");
        return _spawnedEnemies;
    }

    private void FindSpawnPoint()
    {
    
        // ВОТ ТУТ НЕ ПОНИМАЮ...
        SpawnPoint[] spawnPointsPrefab = Object.FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None);
        foreach (var spawnPoint in spawnPointsPrefab)
        {
            SpawnPoint spawnPointPosition = spawnPoint;
            _prefabPosition.Enqueue(spawnPointPosition);
        }
    }
}

