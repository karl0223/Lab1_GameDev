using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float jumpForce;
    private Rigidbody rb;
    private int jumpCount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //movement of the player forward and backwards
        transform.Translate(new Vector3(0, 0, -Input.GetAxis("Vertical")) * Time.deltaTime * moveSpeed);
        //transform.Translate(new Vector3(-Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * moveSpeed);

        //rotation of the player
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0) * Time.deltaTime * rotationSpeed);

        //jump of the player
        if (Input.GetButtonDown("Jump"))
        {

            Jump();
        }
    }
    private void Jump()
    {
        jumpCount += 1;
        if (jumpCount < 2)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            jumpCount = 0;
        }
    }

   
}
