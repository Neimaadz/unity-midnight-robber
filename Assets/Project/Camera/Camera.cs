using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called after all action are done
    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 6, -4);
        transform.eulerAngles = new Vector3(50, 0, 0);
    }
}
