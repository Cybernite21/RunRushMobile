using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public float forwardSpeed = 1000;
    public float maxVelocityForward = 500f;
    public float moveSpeed = 1500f;

    public Slider movementSlider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementSlider = GameObject.FindGameObjectWithTag("movementSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * forwardSpeed * Time.deltaTime, ForceMode.Acceleration);
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxVelocityForward, maxVelocityForward), Mathf.Clamp(rb.velocity.y, -maxVelocityForward, maxVelocityForward), Mathf.Clamp(rb.velocity.z, -maxVelocityForward, maxVelocityForward));
        //rb.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
        //rb.MovePosition(transform.position + transform.forward * forwardSpeed * Time.deltaTime);
        if(movementSlider.value != 0)
        {
            //rb.AddForce(transform.right * movementSlider.value * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
            rb.MovePosition(new Vector3(transform.position.x, transform.position.y, movementSlider.value));
        }
    }

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obsticle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
