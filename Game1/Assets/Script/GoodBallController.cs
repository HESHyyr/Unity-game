using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodBallController : MonoBehaviour
{

    public float force;
    public Rigidbody rb;
    public float speed;
    public Text GameOver;
    private int brickCount;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetSpeed(Random.Range(-1f, 1f));
        brickCount = 0;
        GameOver.text = "";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speed = speed + 0.2f;
            SetSpeed((collision.contacts[0].point[0] - collision.gameObject.transform.position[0]) / collision.gameObject.transform.localScale.x * 10.0f);
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("1pointBrick"))
        {
            collision.gameObject.SetActive(false);
            ++brickCount;
        }

        if (collision.gameObject.CompareTag("DeathWall"))
        {
            GameOver.text = "You Lose!";
            Time.timeScale = 0;
        }

        if (brickCount == 23)
        {
            GameOver.text = "You Win!";
            Time.timeScale = 0;
        }
    }
            

    public  void SetSpeed(float newXSpeed)
    {
        rb.velocity = new Vector3(newXSpeed, 0, Mathf.Sqrt(Mathf.Pow(speed, 2) - Mathf.Pow(newXSpeed, 2)));
        rb.velocity *= 10 * Time.deltaTime;
    }


}