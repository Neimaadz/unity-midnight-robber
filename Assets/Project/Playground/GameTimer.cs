using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameTimer : MonoBehaviour
{
    [SerializeField]
    public float timeRemaining;

    [SerializeField]
    public TextMeshProUGUI textTimer;

    float minutes;
    float seconds;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        GlobalParams.timer = timeRemaining;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            minutes = Mathf.FloorToInt(timeRemaining / 60);
            seconds = Mathf.FloorToInt(timeRemaining % 60);
            textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            SceneManager.LoadScene("ScoreScene");
        }
    }
}
