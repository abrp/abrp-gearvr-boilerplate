using UnityEngine;
using System.Collections;

/***
 * Script for gazing at objects
 * by Anders Bjørn Rørbæk Pedersen
 ***/

public class Gaze : MonoBehaviour {

	[SerializeField] private Reticle m_reticle;

	// debug rays
	private bool m_showDebugRay = true;
	private float m_rayLenght = 100;
	public Vector3 desiredPosition;

	void Awake () {
		if (m_reticle != null) {
			m_reticle = Instantiate (m_reticle, new Vector3 (0, 0, 0), Quaternion.identity) as Reticle;
		}

		desiredPosition = transform.position;

	}

	void Update () {
		EyeRaycast ();

		if (desiredPosition != transform.position) {
			transform.position = Vector3.MoveTowards (transform.position, desiredPosition, 0.1f) ;
		}
	}

	public void MoveToGaze(){
		desiredPosition = new Vector3 (m_reticle.transform.position.x, 2.5f, m_reticle.transform.position.z);
	}


	private void EyeRaycast(){

		// start position for raycast
		Vector3 startPosition = transform.position; 

		// direction for raycast
		Vector3 direction = transform.forward;

		// the ray
		Ray ray = new Ray (startPosition, direction);

		// debug ray in editor mode
		if (m_showDebugRay) {
			Debug.DrawRay (ray.origin, ray.direction * m_rayLenght, Color.red);
		}

		// raycasthit information
		RaycastHit hit;

		if (Physics.Raycast(startPosition,direction * m_rayLenght, out hit,m_rayLenght)){
			m_reticle.SetPosition (hit.point);
		}
	}
}

