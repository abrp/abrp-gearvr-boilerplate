using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class MoveableArea : MonoBehaviour {
	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Gaze m_Gaze;

	private bool m_GazeOver;

	private void Awake(){
		m_InteractiveItem = gameObject.AddComponent<VRInteractiveItem> ();
		m_Gaze = Camera.main.GetComponent<Gaze> ();
	}

	private void OnEnable(){
		m_InteractiveItem.OnClick += HandleClick;
	}

	private void HandleClick(){
		m_Gaze.MoveToGaze ();
	}
}
