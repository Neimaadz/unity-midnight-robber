using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Goals: MonoBehaviour {
  [SerializeField]
  public Light light;

  private int count;

  // Start is called before the first frame update
  void Start() {}

  // Update is called once per frame
  void Update() {
    if (count == 3) {
      StaticTimer.objectsFound = true;
      light.color = Color.green;
    }
  }

  private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.name.Equals("dollars")) {
      Destroy(collision.gameObject);
      count++;
    } else if (collision.gameObject.name.Equals("smartphone")) {
      Destroy(collision.gameObject);
      count++;
    } else if (collision.gameObject.name.Equals("paint_sheep")) {
      Destroy(collision.gameObject);
      count++;
    }
  }
}
