using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPC : MonoBehaviour
{
    private IBehaviour _behaviour1;

    private IBehaviour _behaviour2;

    [SerializeField] private Transform _playerController;

    private NPCBehaviourChoise npcBehaviourChoise;
   
   
    private float _distanceForChangeBehaviour = 10;

    private void Awake()
    {
        NPCBehaviourChoise nPCBehaviourChoise = GetComponent<NPCBehaviourChoise>();
    }
    private void Update()
    {
        SwitchBehaviour();
    }
    private void SwitchBehaviour()
    {
        Vector3 distanceToTarget = _playerController.transform.position - transform.position;
        if (distanceToTarget.magnitude > _distanceForChangeBehaviour)
            BehaviourChoise(_behaviour1);
        else
            BehaviourChoise(_behaviour2);
    }

    public void SetIdleBehaviour(IBehaviour behaviour)
    {
        behaviour = npcBehaviourChoise.BehaviourChoise();
    }
    public void SetAggroBehaviour(IBehaviour behaviour)
    {

    }

}


