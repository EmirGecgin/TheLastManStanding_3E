using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    private bool isGameActive;
    public float timer;
    void Start()
    {
        isGameActive = true;
    }

    
    void Update()
    {
        if (isGameActive == true)
        {
            timer += Time.deltaTime;
            UIController.Instance.UpdateTimer(timer);
        }
    }

    public void EndLevel()
    {
        isGameActive = false;
    }
}
