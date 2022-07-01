using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goals : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("dollars"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name.Equals("smartphone"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name.Equals("paint_sheep"))
        {
            Destroy(collision.gameObject);
        }
    }
}
