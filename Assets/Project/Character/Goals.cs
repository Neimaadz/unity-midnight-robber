using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goals : MonoBehaviour
{
    private int count;

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
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("dollars"))
        {
            Destroy(collision.gameObject);
            count++;
        }
        else if (collision.gameObject.name.Equals("smartphone"))
        {
            Destroy(collision.gameObject);
            count++;
        }
        else if (collision.gameObject.name.Equals("paint_sheep"))
        {
            Destroy(collision.gameObject);
            count++;
        }
    }
}
