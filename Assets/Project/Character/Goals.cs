using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using TMPro;
using Assets.Project;

public class Goals : MonoBehaviour
{
    [SerializeField]
    public new Light light;

    [SerializeField]
    public TextMeshProUGUI runText;

    [SerializeField]
    public TextMeshProUGUI sheepText;

    [SerializeField]
    public TextMeshProUGUI phoneText;

    [SerializeField]
    public TextMeshProUGUI dollarText;

    [SerializeField]
    public TextMeshProUGUI tooltipText;

    private Dictionary<string, TextMeshProUGUI> objectNames = new Dictionary<string, TextMeshProUGUI>();
    private DisplayMessage displayMessage = new DisplayMessage();
    private RandomPosition randomPosition = new RandomPosition();
    private bool isPlayerInRange = false;
    private GameObject currentObjectInterracting;
    private TextMeshProUGUI textToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        objectNames = new Dictionary<string, TextMeshProUGUI>
        {
            { "dollars", dollarText },
            { "smartphone", phoneText },
            { "paint_sheep", sheepText }
        };

        GameObject paint_sheep = GameObject.Find("paint_sheep");
        GameObject dollars = GameObject.Find("dollars");
        GameObject smartphone = GameObject.Find("smartphone");
        //randomPosition.RandomizePosition(paint_sheep, 3.4f, 6.5f);
        randomPosition.RandomObjectPosition(paint_sheep);
        randomPosition.RandomObjectPosition(dollars);
        randomPosition.RandomObjectPosition(smartphone);

        tooltipText.text = "Press 'E' to steal";
        tooltipText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartInteraction(currentObjectInterracting, textToDisplay);

        // When all items have been found, display once a message
        if (GlobalParams.count == 3 && GlobalParams.isObjectsFound == false)
        {
            light.color = Color.green;
            GlobalParams.isObjectsFound = true;
            StartCoroutine(displayMessage.DisplayAndHideMessage(runText, "Time to go, RUN !!", 5.0f));
        }
    }

    // To use this method, set trigger checkbox of Box Collider to true in unity inspector
    private void OnTriggerEnter(Collider collision)
    {
        objectNames.TryGetValue(collision.gameObject.name, out TextMeshProUGUI value);
        isPlayerInRange = value != null ? true : false;
        textToDisplay = value;

        if (isPlayerInRange)
        {
            tooltipText.gameObject.SetActive(true);
            currentObjectInterracting = collision.gameObject;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("Player exited collision with interactable object.");
        isPlayerInRange = false;
        tooltipText.gameObject.SetActive(false);
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        objectNames.TryGetValue(collision.gameObject.name, out TextMeshProUGUI value);
        isPlayerInRange = value != null ? true : false;
        textToDisplay = value;

        if (isPlayerInRange)
        {
            tooltipText.gameObject.SetActive(true);
            currentObjectInterracting = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Player exited collision with interactable object.");
        isPlayerInRange = false;
        tooltipText.gameObject.SetActive(false);
    }
    */

    private void StartInteraction(GameObject gameObject, TextMeshProUGUI textMesh)
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            tooltipText.gameObject.SetActive(false);
            Destroy(gameObject);
            Destroy(textMesh);
            GlobalParams.count++;
        }
    }
}
