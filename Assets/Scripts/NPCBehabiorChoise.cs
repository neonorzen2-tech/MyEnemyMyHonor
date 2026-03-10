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
    [SerializeField] private NPCBehaviorTypes nPCBehaviorTypes2;

    [SerializeField] private PlayerController _playerController;
     
    private float _distanceForChangeBehaviour = 10;

    private void Awake()
    {
        //_playerController = GetComponent<PlayerController>();
        _idleBehaviour.enabled = false;
        _frightAndDeadBehaviour.enabled = false;
        _flightFromTargetBehaviour.enabled = false;
        _patrollingBehaviour.enabled = false;
        _crazyWalkingBehaviour.enabled = false;
        //тут получается если они в начале, то не найдены скрипты. если после геткомпонент, то они все срабатывают
        //|| _attackOnTargetBehaviour == null

        if (_idleBehaviour == null || _frightAndDeadBehaviour == null || _flightFromTargetBehaviour == null || _patrollingBehaviour == null || _crazyWalkingBehaviour == null)
        {
            Debug.Log(" Скрипт поведения не найден! Какой - сам разбересся");
            return;
        }
    }

    private void Update()
    {
        SwitchBehaviour(nPCBehaviorTypes, nPCBehaviorTypes2, _playerController);
    }
    
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

    private void SwitchBehaviour(NPCBehaviorTypes nPCBehavior, NPCBehaviorTypes nPCBehavior1, Component target)
    {

        Vector3 distanceToTarget = target.transform.position - transform.position;
        if (distanceToTarget.magnitude > _distanceForChangeBehaviour)
            BehaviourChoise(nPCBehaviorTypes);
        else
            BehaviourChoise(nPCBehaviorTypes2);
    }
}
