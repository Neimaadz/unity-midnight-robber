using Assets.Project;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollisionExit : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI runText;

    private DisplayMessage displayMessage = new DisplayMessage();

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnCollisionEnter(Collision collision)
    {
        if (GlobalParams.isObjectsFound)
        {
            GlobalParams.count = 0;
            GlobalParams.isObjectsFound = false;
            SceneManager.LoadScene("ScoreScene");
        }
        else
        {
            StartCoroutine(displayMessage.DisplayAndHideMessage(runText, "You didn't steal all the items !", 2.0f));
        }
    }

}