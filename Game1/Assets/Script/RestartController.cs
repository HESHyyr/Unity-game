﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour {

    public void restart()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
