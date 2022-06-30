using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        var currentPosition = this.gameObject.transform.position;
        var velocity = Vector3.Distance(currentPosition, lastPosition);
        GetComponent<Animator>().SetFloat("forwardSpeed", 0);
        GetComponent<Animator>().SetFloat("backwardSpeed", 0);

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z))
        {
            GetComponent<Animator>().SetFloat("forwardSpeed", velocity);
            this.gameObject.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().SetFloat("backwardSpeed", velocity);
            this.gameObject.transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            this.gameObject.transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotationSpeed * speed);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotationSpeed * speed);
        }

        lastPosition = currentPosition;
    }
}
