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

	void Awake () {
		if (m_reticle != null) {
			m_reticle = Instantiate (m_reticle, new Vector3 (0, 0, 0), Quaternion.identity) as Reticle;
		}
	}

	void Update () {
		EyeRaycast ();
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

