using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : MonoBehaviour
{
    [SerializeField] private Transform targetCube;
    [SerializeField] private float force = 30;
    [SerializeField] private float rotationForce = 300;
    private Rigidbody rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>(); 

    }

    private void FixedUpdate() 
    {
        if(targetCube != null)
        {
        Vector3 direction = targetCube.position - rb.position;
        direction.Normalize();
        Vector3 rotationAmount = Vector3.Cross(transform.forward,direction);
        rb.angularVelocity = rotationAmount * rotationForce;
        rb.velocity = transform.forward * force;
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        Destroy(collision.collider.gameObject);
        Destroy(gameObject);
    }
}
