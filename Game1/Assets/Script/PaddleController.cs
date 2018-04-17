using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {
        move();
    }

    void move()
    {
        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.D) && transform.position[0] + transform.localScale[0] / 2 <= 1.9)
            input += Vector3.right;
        if (Input.GetKey(KeyCode.A) && transform.position[0] - transform.localScale[0] / 2 >= -1.9)
            input += Vector3.left;

        rb.MovePosition(rb.position + input * Time.deltaTime);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("BadBall"))
        {
            if (transform.localScale[0] > 0.1f)
                transform.localScale -= new Vector3(0.1f, 0.0f, 0.0f);
        }
    }
}
