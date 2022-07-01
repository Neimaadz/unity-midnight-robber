using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float backwardCamValue;
    [SerializeField] private float upCamValue;
    [SerializeField] private float camTransition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called after all action are done
    void LateUpdate()
    {
        var playerCamPos = player.transform.position - (player.transform.forward * backwardCamValue)  + (Vector3.up * upCamValue);
        // transition camera between current and future position with the delay
        transform.position = Vector3.Lerp(transform.position, playerCamPos, camTransition);
        transform.LookAt(player.transform.position);
    }
}
