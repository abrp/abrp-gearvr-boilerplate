using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

  public Vector3 desiredPosition;
  private Reticle m_Reticle;

  void Awake () {
    desiredPosition = transform.position;
  }

  void Start() {
    m_Reticle = GameObject.FindObjectOfType<Reticle>();
  }
	
  void Update () {
    if (desiredPosition != transform.position) {
      transform.position = Vector3.MoveTowards (transform.position, desiredPosition, 0.1f) ;
    }
  }

  public void MoveToGaze(){
    desiredPosition = new Vector3 (m_Reticle.transform.position.x, 2.5f, m_Reticle.transform.position.z);
  }


}
