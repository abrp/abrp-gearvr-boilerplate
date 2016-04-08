using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class MoveableArea : MonoBehaviour {
	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private MoveController m_MoveController;

	private bool m_GazeOver;

	private void Awake(){
		if (m_InteractiveItem == null) {
			m_InteractiveItem = gameObject.AddComponent<VRInteractiveItem> ();
		}
    m_MoveController = Camera.main.GetComponentInParent<MoveController> ();
	}

	private void OnEnable(){
		m_InteractiveItem.OnClick += HandleClick;
    //m_InteractiveItem.OnDoubleClick += HandleClick;
    //m_InteractiveItem.OnUp += HandleClick;
	}

	private void OnDisable(){
		m_InteractiveItem.OnClick -= HandleClick;
	}

	private void HandleClick(){
    m_MoveController.MoveToGaze ();
	}
}
