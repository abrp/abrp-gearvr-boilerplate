using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour {

	private Camera m_sceneCamera;
	[SerializeField] private float m_smoothing = 0.1f;
	// Use this for initialization
	void Start () {
		m_sceneCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		LookAt (m_sceneCamera.transform.position);
	}

	public void SetPosition(Vector3 newPosition){
		Vector3 desiredPosition = newPosition;
		float distance = Vector3.Distance (desiredPosition, transform.position);
		if (desiredPosition != transform.position) {
			transform.position = Vector3.MoveTowards (transform.position, desiredPosition, distance * m_smoothing) ;
		}
	}
		
	private void LookAt(Vector3 position){
		transform.LookAt (position);
	}
}
