using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goals : MonoBehaviour
{
    private int count;

    [SerializeField]
    public TextMeshProUGUI runText;

    [SerializeField]
    public TextMeshProUGUI sheepText;

    [SerializeField]
    public TextMeshProUGUI phoneText;

    [SerializeField]
    public TextMeshProUGUI dollarText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 3)
        {
            StaticTimer.objectsFound = true;
            runText.text = "Time to go, RUN !!";
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("dollars"))
        {
            Destroy(collision.gameObject);
            count++;
            dollarText.text = "";
        }
        else if (collision.gameObject.name.Equals("smartphone"))
        {
            Destroy(collision.gameObject);
            count++;
            phoneText.text = "";
        }
        else if (collision.gameObject.name.Equals("paint_sheep"))
        {
            Destroy(collision.gameObject);
            count++;
            sheepText.text = "";
        }
    }
}
