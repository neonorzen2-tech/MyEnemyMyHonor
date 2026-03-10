using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private Mover _mover;
    private Rotator _rotator;
    private float _deadZone = 0.05f;

    private string _horizontal = "Horizontal";
    private string _vertical = "Vertical";

    private Vector3 _velocity;
    private float _gravity = -2f;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mover = GetComponent<Mover>();
        _rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        GroundControl();

        Vector3 input = new Vector3(Input.GetAxisRaw(_horizontal), 0, Input.GetAxisRaw(_vertical));
       
        if (input.magnitude <= _deadZone)
            return;

        Vector3 normalized = input.normalized;

        _mover.ProcessMoveTo(normalized);
        _rotator.ProcessRotateTo(normalized);
    }



    private void GroundControl()
    {
        if (_characterController.isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2;
        }
        _velocity.y += Physics.gravity.y * Time.deltaTime;        
    }

    
}



//[SerializeField] private float _moveSpeed;
//[SerializeField] private float _rotationSpeed;

//private string _horizontal = "Horizontal";
//private string _vertical = "Vertical";

//private float _deadZone = 0.05f;

//private CharacterController _characterController;


//private void Awake()
//{
//    _characterController = GetComponent<CharacterController>();
//}

//private void Update()
//{
//    Vector3 input = new Vector3(Input.GetAxisRaw(_horizontal), 0, Input.GetAxisRaw(_vertical));

//    if (input.magnitude <= _deadZone)
//        return;

//    Vector3 normolized = input.normalized;

//    ProcessMoveTo(normolized);
//    ProcessRotateTo(normolized);
//}

//private void ProcessMoveTo(Vector3 direction)
//{
//    _characterController.Move(_moveSpeed * Time.deltaTime * direction);
//}

//private void ProcessRotateTo(Vector3 direction)
//{
//    Quaternion rotatePlayer = Quaternion.LookRotation(direction);
//    float step = _rotationSpeed * Time.deltaTime; // максимальный угол поворота за текущий кадр в градусах: Так обеспечивается одинаковая скорость при разном FPS.
//    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotatePlayer, step);
//}
