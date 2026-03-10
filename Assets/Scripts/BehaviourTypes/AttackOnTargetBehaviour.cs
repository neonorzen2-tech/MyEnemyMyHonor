using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AttackOnTargetBehaviour : MonoBehaviour
{
   //private CharacterController _characterController;
   // [SerializeField] private PlayerController _target;
   // private Mover _mover;
   // private Rotator _rotator;

   // private float _positionY;

   // private void Awake()
   // {
   //     _characterController = GetComponent<CharacterController>();        
   //     _mover = GetComponent<Mover>();
   //     _rotator = GetComponent<Rotator>();

   //     if (_characterController == null || _mover == null || _rotator == null)
   //         Debug.LogError("Нет какогото компонента");
   //    _positionY = transform.position.y;

   // }

   // private void Update()
   // {
   //     _mover.ProcessMoveTo(TargetDirection(_target));
   //     _rotator.ProcessRotateTo(TargetDirection(_target));

   //     Vector3 positionEnemy = transform.position;
   //     positionEnemy.y = _positionY;
   //     transform.position = positionEnemy;
   // }

   // private Vector3 TargetDirection(PlayerController target)
   // {
   //     Vector3 targetDirection = new Vector3();
   //     targetDirection = target.transform.position - transform.position;
        
   //     return targetDirection.normalized;
   // }
}
