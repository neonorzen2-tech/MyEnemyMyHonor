using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCBehabiorChoise : MonoBehaviour
{
    [SerializeField] private IdleBehaviour _idleBehaviour;
    [SerializeField] private FrightAndDeadBehaviour _frightAndDeadBehaviour;
    [SerializeField] private FlightFromTargetBehaviour _flightFromTargetBehaviour;
    //[SerializeField] private AttackOnTargetBehaviour _attackOnTargetBehaviour;
    [SerializeField] private PatrollingBehaviour _patrollingBehaviour;
    [SerializeField] private CrazyWalkingBehaviour _crazyWalkingBehaviour;

    [SerializeField] private NPCBehaviorTypes nPCBehaviorTypes;

    private bool _scriptIsFinded;

    private void Awake()
    {
        _idleBehaviour.enabled = false;
        _frightAndDeadBehaviour.enabled = false;
        _flightFromTargetBehaviour.enabled = false;
        _patrollingBehaviour.enabled = false;
        _crazyWalkingBehaviour.enabled = false;
        ////тут получается если они в начале, то не найдены скрипты. если после геткомпонент, то они все срабатывают

        //_idleBehaviour = GetComponent<IdleBehaviour>();
        //_frightAndDeadBehaviour = GetComponent<FrightAndDeadBehaviour>();
        //_flightFromTargetBehaviour = GetComponent<FlightFromTargetBehaviour>();
        ////_attackOnTargetBehaviour = GetComponent<AttackOnTargetBehaviour>();|| _attackOnTargetBehaviour == null 
        //_patrollingBehaviour = GetComponent<PatrollingBehaviour>();
        //_crazyWalkingBehaviour = GetComponent<CrazyWalkingBehaviour>();



        //if (_idleBehaviour == null || _frightAndDeadBehaviour == null || _flightFromTargetBehaviour == null || _patrollingBehaviour == null || _crazyWalkingBehaviour == null)
        //{
        //    Debug.Log(" Скрипт поведения не найден! Какой - сам разбересся");
        //    return;
        //}

        BehaviourChoise(nPCBehaviorTypes);
    }
    //_scriptIsFinded == true
    private void BehaviourChoise(NPCBehaviorTypes nPCBehaviorTypes)
    {
        switch (nPCBehaviorTypes)
        {

            case NPCBehaviorTypes.Idle:
                
                _idleBehaviour.enabled = true;
                break;

            case NPCBehaviorTypes.Patrolling:
                _patrollingBehaviour.enabled = true;
                break;

            case NPCBehaviorTypes.CrazyWalking:
                _crazyWalkingBehaviour.enabled = true;
                break;

            case NPCBehaviorTypes.FlightFromTarget:
                _flightFromTargetBehaviour.enabled = true;
                break;

            //case NPCBehaviorTypes.AttackOnTarget:
            //    _attackOnTargetBehaviour.enabled = true;
            //    break;

            case NPCBehaviorTypes.FrightAndDead:

                _frightAndDeadBehaviour.enabled = true;
                break;

            default:
                Debug.Log("нет такого типа поведения");
                return;
        }

    }
}
