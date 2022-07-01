using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndState : MonoBehaviour
{

    [SerializeField]
    private Sprite winImage;

    [SerializeField]
    private Sprite loseImage;

    float minutes;
    float seconds;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(StaticTimer.timer);
        float timeLeft = StaticTimer.timer; // Time remaining
        if (timeLeft > 0)   // Win
        {
            minutes = Mathf.FloorToInt(timeLeft / 60);
            seconds = Mathf.FloorToInt(timeLeft % 60);
            GetComponent<TextMeshProUGUI>().text = string.Format("You win !\nYou had {0:00}:{1:00} left !", minutes, seconds);

            GameObject image = GameObject.Find("Image");
            image.GetComponent<Image>().sprite = winImage;

        } else // Lose
        {
            GetComponent<TextMeshProUGUI>().text = "You lose :(";

            GameObject image = GameObject.Find("Image");
            image.GetComponent<Image>().sprite = loseImage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
