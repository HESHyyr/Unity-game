using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBallController : MonoBehaviour {

    public float speed;
    public Rigidbody rb;
    private GameObject brother;
    private GameObject paddle;
    private float Dtime;

	void Start () {

        rb = GetComponent<Rigidbody>();
        SetSpeed(Random.Range(-2f, 2f));
        brother = GameObject.Find("Good Ball");
        paddle = GameObject.Find("Paddle");
        Dtime = 0.0f;
	}

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeathWall"))
            speed += 0.2f;
        
        if (collision.gameObject.CompareTag("GoodBall"))
        {
            collision.gameObject.SetActive(false);
            Dtime = Time.time;
        }
        
        rb.velocity *= speed / Mathf.Sqrt(Mathf.Pow(rb.velocity[0], 2) + Mathf.Pow(rb.velocity[2], 2)) * 15 * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if(!brother.activeSelf)
        {
            if (Time.time - Dtime > 2.0f)
            {
                Dtime = 0.0f;
                brother.SetActive(true);
                brother.transform.position = new Vector3(paddle.transform.position.x, 0.1f, -1.5f);
                brother.GetComponent<GoodBallController>().SetSpeed(Random.Range(-2f, 2f));
            }
        }
    }

    void SetSpeed(float newXSpeed)
    {
        rb.velocity = new Vector3(newXSpeed, 0, Mathf.Sqrt(Mathf.Pow(speed, 2) - Mathf.Pow(newXSpeed, 2))) * 10 * Time.deltaTime;
    }
}
