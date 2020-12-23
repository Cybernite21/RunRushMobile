using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public float forwardSpeed = 1000f;
    public float moveSpeed = 1500f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * forwardSpeed * Time.deltaTime, ForceMode.Acceleration);
        rb.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, ForceMode.Acceleration);
    }

    void FixedUpdate()
    {
        
    }
}
