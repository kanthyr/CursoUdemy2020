using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool usePhysicsEngine;
    
    public float moveForce = 10f;
    public float rotateTorque = 20f;
    
    public float moveSpeed = 10f;
    public float rotateSpeed = 20f;
    
    private float _zInput;
    private float _xInput;

    private Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _zInput = Input.GetAxis("Vertical");
        _xInput = Input.GetAxis("Horizontal");

        if (usePhysicsEngine)
        {
            /*
            * Si se utiliza la fisica,
            * AddForce sobre el rigidbody para realizar movimiento lineal,
            * AddTorque sobre el rigidbody para realizar giro angular.
            */
            _rigidbody.constraints = RigidbodyConstraints.None;
            _rigidbody.AddForce(Vector3.forward * (moveForce * Time.deltaTime * _zInput), ForceMode.Force);
            _rigidbody.AddTorque(Vector3.up * (rotateTorque * Time.deltaTime * _xInput), ForceMode.Force);
        }
        else
        {
            /* 
            * Si no se utiliza la fisica,
            * Translate sobre el transform para mover,
            * Rotate sobre el transform para girar.
            */
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime * _zInput));
            transform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime * _xInput));
        }
    }
}
