using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndState : MonoBehaviour
{

   

    // Start is called before the first frame update
    void Start()
    {
        Sprite sprite;
        if (true)
        {
            
            GetComponent<TextMeshProUGUI>().text = "Test";

            sprite = Resources.Load<Sprite>("gagnant");

            GameObject image = GameObject.Find("Image");
            image.GetComponent<Image>().sprite = sprite;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
