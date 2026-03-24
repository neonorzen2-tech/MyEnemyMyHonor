using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPC : MonoBehaviour
{
    private IBehaviour _idleBehaviour;
    private IBehaviour _aggroBehaviour;

    [SerializeField] private Transform _playerController;
          
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
            _idleBehaviour?.Execute(); 
        else
            _aggroBehaviour?.Execute();
    }

    public void SetIdleBehaviour(IBehaviour behaviour)
    {
        _idleBehaviour = behaviour;
    }
    public void SetAggroBehaviour(IBehaviour behaviour)
    {
        _aggroBehaviour = behaviour;
    }

}
// вот тут € как раз не могу пон€ть как оно срабатывает, как работает логика 
//_idleBehaviour?.Execute();  оно ссылаетс€ на интерфейс јйЅих. запускает метод экзекуции через јпдейт этого класса
// т.е. оно просто как поворот ключа запуска конкретного поведени€. Ќѕ— клас выполн€ет функцию включени€ класса, у которого
// ест јйЅех » Ёкзекьют, любого - это полиморфизм

//сейчас пока не пон€тно где, в какой момент обрабатываютс€ методы SetIdleBehaviour и SetAggroBehaviour
//они вроде не где не запускаютс€, но они публичные, ѕќ—ћќ“–≈“№ в других классах.
// 13.03 жен€ писал
// ѕри этом прокидывать их можно через публичные методы (пр€м завести SetIdleBehaviour
// (IBehaviour behaviour) и SetAggroBehaviour(IBehaviour behaviour) )
// - это и будет стратеги€, потому что тогда в NPC будет использование только IBehaviour, без конкретики,
// и тогда при добавлении новых IBehaviour вообще не надо будет мен€ть класс NPC никак
// Ё“ќ —“–ј“≈√»я, но не понимаю почему, ѕ≈–≈—ћќ“–≈“№ ¬»ƒќ— ѕ–ќ —“–ј“≈√»ё

//” инстанса NPC вызываешь SetIdleBehaviour и SetAggroBehaviour, передава€ нужные поведени€ 
// в конце комментари€ жени от 19.03.
// их в апдейт отправл€ю. ѕќѕџ“ј“№—я ѕќЌя“№  ј  » «ј„≈ћ. думать надо.


