using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviorVersion : MonoBehaviour

{
    //[SerializeField] private PlayerController playerController;

    //private float _interactDistance = 10;

    //[SerializeField] private NPCBehabiorChoise _idle;
    //[SerializeField] private NPCBehabiorChoise _patrolling;
    //[SerializeField] private NPCBehabiorChoise _crazyWalking;
    //[SerializeField] private NPCBehabiorChoise _flightFromTarget;
    //[SerializeField] private NPCBehabiorChoise _attackOnTarget;
    //[SerializeField] private NPCBehabiorChoise _frightAndDead;






}

//мне нужны скрипты поведения.
//через swith/case я, к примеру, их привожу в действие. связываю енам с поведением.
//ТУТ пишу через свитч, предположим, а в NPCBehabiorChoise логику взаимодействия прорабатываю
//КАК через выпадающий список сделать(точнее связать выбранный вариант со скриптом)?. попробую, если нет, загляну в ИИшку.
//надо логика поведения зависящая от расстояния, если не через тригер.
//ИЛИ ВОЗМОЖНО ХОРОШИЙ/ПРАВИЛЬНЫЙ ВАРИАНТ ЭТО ТОЖЕ ВСЁ сделать в спавнере, как в уроке.






//private void Awake()
//{
//    playerController = GetComponent<PlayerController>();
//}
//public void Interact(NPCBehaviorTypes nPCBehaviorTypes1)
//{


//    if ((playerController.transform.position - transform.position).magnitude > _interactDistance)
//        GetComponent<NPCBehaviorTypes>();

//    //else
//    //    nPCBehaviorTypes1;


//}

//public enum NPCBehaviorTypes
//{
//    Idle = 1,
//    Patrolling = 2,
//    CrazyWalking = 3,
//    FlightFromTarget = 4,
//    AttackOnTarget = 5,
//    FrightAndDead = 6,
//}
//public enum NPCBehaviorTypes2
//{
//    Idle = 1,
//    Patrolling = 2,
//    CrazyWalking = 3,
//    FlightFromTarget = 4,
//    AttackOnTarget = 5,
//    FrightAndDead = 6,
//}



//void Start()
//{
//    //Debug.Log("Выбрано качество: " + currentQuality);
//}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NPCBehaviorVersion : MonoBehaviour, IBehavior
//{
//    [SerializeField] private NPCBehabiorChoise _idle;
//    [SerializeField] private NPCBehabiorChoise _patrolling;
//    [SerializeField] private NPCBehabiorChoise _crazyWalking;
//    [SerializeField] private NPCBehabiorChoise _flightFromTarget;
//    [SerializeField] private NPCBehabiorChoise _attackOnTarget;
//    [SerializeField] private NPCBehabiorChoise _frightAndDead;
//    public void Interact(NPCBehaviorTypes nPCBehaviorTypes1, NPCBehaviorTypes nPCBehaviorTypes2)
//    {
//        switch (nPCBehaviorTypes1)
//        {
//            case NPCBehaviorTypes.Idle:
//                Instantiate(_idle);
//                break;

//            case NPCBehaviorTypes.Patrolling:
//                Instantiate(_patrolling);
//                break;

//            case NPCBehaviorTypes.CrazyWalking:
//                Instantiate(_crazyWalking);
//                break;

//            default:
//                Debug.LogError("Данный тип поведения не назначен");
//                break;
//        }
//        switch (nPCBehaviorTypes2)
//        {
//            case NPCBehaviorTypes.FlightFromTarget:
//                Instantiate(_flightFromTarget);
//                break;

//            case NPCBehaviorTypes.AttackOnTarget:
//                Instantiate(_attackOnTarget);
//                break;

//            case NPCBehaviorTypes.FrightAndDead:
//                Instantiate(_frightAndDead);
//                break;

//            default:
//                Debug.LogError("Данный тип поведения не назначен");
//                break;
//        }
//    }
//}
