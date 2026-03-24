using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPCBehaviourChoise : MonoBehaviour
{

    [SerializeField] private NPCBehaviourTypes npcBehaviorTypes;
    [SerializeField] private NPCBehaviourTypes npcBehaviorTypes2;

    [SerializeField] private Transform _playerControllerTransform;

    private Mover _mover;
    private Rotator _rotator;
    private NPC _npc;
    private GameObject _npcGameObject;
    

    private void Awake()
    {
        _npcGameObject = GetComponent<GameObject>();
        
        //_mover = GetComponent<Mover>();
        //_playerController = GetComponent<PlayerController>();
        //_rotator = GetComponent<Rotator>();
        _npc = GetComponent<NPC>();
    }

    //∆ен€, вот не понимаю эту часть с NPC nps  в 
    //public IBehaviour BehaviourChoise(NPCBehaviourTypes nPCBehaviorTypes, NPC npc) 
    // и тут
    //public IBehaviour GetIdleBehaviour(NPC npc)
    //{
    //    return BehaviourChoise(nPCBehaviorTypes, npc);
    //}
    // и в классе NPC 
    //  public void SetIdleBehaviour(IBehaviour behaviour)
    //{
    //    behaviour = npcBehaviourChoise.BehaviourChoise(„“ќ “”“ «ј√ќЌя“№ ¬ ѕј–ћ≈“–џ);

    //    € предполагаю, както можно к примеру из списка NPC,  который в SPAWNER получаю  на выходе 
    //  в методе SPAWNTO
    ////// —обственно что  ты в комментарии писал:
    //  ... "ѕри этом в методе прокидываетс€ инстанс NPC.» вот с него можно будет через 
    //    GetComponent выт€гивать Mover, Rotator кому надо и т.п....
    //


public IBehaviour BehaviourChoise(NPCBehaviourTypes nPCBehaviorTypes, NPC npc)
    {

        switch (nPCBehaviorTypes)
        {

            case NPCBehaviourTypes.Idle:

                return new IdleBehaviour();


            case NPCBehaviourTypes.Patrolling:
                return new PatrollingBehaviour(_mover, _rotator, transform);


            case NPCBehaviourTypes.CrazyWalking:
                return new CrazyWalkingBehaviour(_mover, _rotator);


            case NPCBehaviourTypes.FlightFromTarget:

                return new FlightFromTargetBehaviour(_mover, _rotator, _playerControllerTransform);

            case NPCBehaviourTypes.AttackOnTarget:
                return new AttackOnTargetBehaviour(_mover, _rotator, _playerControllerTransform);

            case NPCBehaviourTypes.FrightAndDead:
                return new FrightAndDeadBehaviour(_npcGameObject);

            default:
                Debug.Log("нет такого типа поведени€");
                return null;

        }
    }

    public IBehaviour GetIdleBehaviour(NPC npc)
    {
       return BehaviourChoise(npcBehaviorTypes, npc);
    }

   // !!!! вот это скопировал, пыталс€ пон€ть, но пока не пон€л, может сможешь объ€снить?
    public IBehaviour GetAggroBehaviour(NPC npc) => BehaviourChoise(npcBehaviorTypes2, npc);

}

