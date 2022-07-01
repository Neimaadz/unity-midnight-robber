using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameTimer : MonoBehaviour
{
    [SerializeField]
    public float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        } else
        {
            StaticTimer.timer = timeRemaining;
            SceneManager.LoadScene("ScoreScene");
        }
    }
}
