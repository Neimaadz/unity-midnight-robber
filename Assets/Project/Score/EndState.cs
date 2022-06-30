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

    // Start is called before the first frame update
    void Start()
    {
        int timeLeft = 0; // Stub before we get the time
        if (timeLeft > 0)   // Win
        {
            GetComponent<TextMeshProUGUI>().text = "You win !!";

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
