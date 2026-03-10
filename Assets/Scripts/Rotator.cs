using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float _rotationSpeed = 360;
    
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void ProcessRotateTo(Vector3 normalized)
    {
        Quaternion objectRotation = Quaternion.LookRotation(normalized);

        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, objectRotation, step);
    }
}
