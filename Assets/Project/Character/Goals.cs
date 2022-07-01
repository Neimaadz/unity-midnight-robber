using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goals : MonoBehaviour
{
    [SerializeField] GameObject objectToFind_1;
    [SerializeField] GameObject objectToFind_2;
    [SerializeField] GameObject objectToFind_3;

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
        if (collision.gameObject.Equals(objectToFind_1))
        {
            Destroy(objectToFind_1);
        }
        else if (collision.gameObject.Equals(objectToFind_2))
        {
            Destroy(objectToFind_2);
        }
        else if (collision.gameObject.Equals(objectToFind_3))
        {
            Destroy(objectToFind_3);
        }
    }
}
