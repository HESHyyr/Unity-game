using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public bool isStart;
    public bool isQuit;
    private Material m;

	// Use this for initialization
	void Start () {
        m = GetComponent<Renderer>().material;
        m.color = Color.white;
	}

    private void OnMouseEnter()
    {
        m.color = Color.black;
    }

    private void OnMouseExit()
    {
        m.color = Color.white;
    }

    private void OnMouseDown()
    {
        m.color = Color.blue;
    }

    private void OnMouseUp()
    {
        if(isStart)
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Playground");
        }
        if(isQuit)
        {
            Application.Quit();
        }

        m.color = Color.black;
    }
}
