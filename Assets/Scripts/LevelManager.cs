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

    public float waitToShowTheEndScreenInterface=1f;
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
        StartCoroutine(EndLevelCoroutine());
    }

    IEnumerator EndLevelCoroutine()
    {
        yield return new WaitForSeconds(waitToShowTheEndScreenInterface);
        float minutes = Mathf.FloorToInt(timer / 60f);
        float seconds = Mathf.FloorToInt(timer % 60);

        UIController.Instance.endTimeText.text = minutes.ToString() + " mins " + seconds.ToString("00" + " secs");
        UIController.Instance.levelEndInterface.SetActive(true);
    }
}
