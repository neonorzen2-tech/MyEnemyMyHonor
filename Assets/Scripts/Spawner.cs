using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //ТУТ ЕЩЕ БУДУ ДОДЕЛЫВАТЬ, РАЗБИРАТЬСЯ.
    [SerializeField] private NPCBehaviourChoise _spawnPointPrefab; 
    
    [SerializeField] private NPC _enemyPrefab;

    //У него есть ссылка на префаб NPC.Можно ему прокинуть ссылки в
    //явном виде на NPCBehabiorChoise на сцене
    //(сделать List<NPCBehabiorChoise> с[SerializeField}
    //и в инспекторе на сцене прокинуть)
    //ВОТ ЭТО НЕ ДОГОНЯЮ ТОЖЕ, как прокинуть ссылки на NPCBehabiorChoise, т.е. он висит на вытянутых объектах
    // инстансах спавнпоинтов и спавнпоинты закидывать в лист?
    [SerializeField] private  List<NPCBehaviourChoise> npcBehaviourChoises;

    private Queue<NPCBehaviourChoise> _prefabPosition = new Queue<NPCBehaviourChoise>();
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
            NPCBehaviourChoise spawnPoint = _prefabPosition.Dequeue();
            Vector3 spawnPointPosition = spawnPoint.transform.position;
            spawnPointPosition.y -= offSetY;
            NPC newEnemy = Instantiate(_enemyPrefab, spawnPointPosition, Quaternion.identity);

            
           IBehaviour idle = _spawnPointPrefab.GetIdleBehaviour(newEnemy);
            IBehaviour aggro = _spawnPointPrefab.GetAggroBehaviour(newEnemy);
            newEnemy.SetIdleBehaviour(idle);
            newEnemy.SetAggroBehaviour(aggro);
            _spawnedEnemies.Add(newEnemy);
        }
        Debug.Log(_spawnedEnemies.Count + "Count");
        return _spawnedEnemies;
    }

    private void FindSpawnPoint()
    {

        // ВОТ ТУТ НЕ ПОНИМАЮ... вроде ты писал что это не использовать, тогда просто забросить все точки через инспектора?
        NPCBehaviourChoise[] spawnPointsPrefab = Object.FindObjectsByType<NPCBehaviourChoise>(FindObjectsSortMode.None);
        foreach (var spawnPoint in spawnPointsPrefab)
        {
            NPCBehaviourChoise spawnPointPosition = spawnPoint;
            _prefabPosition.Enqueue(spawnPointPosition);
        }
    }
}

