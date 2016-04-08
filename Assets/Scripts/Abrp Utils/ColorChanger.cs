using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class ColorChanger : MonoBehaviour {
	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Color m_OverColor = new Color(1,0,0);
	[SerializeField] private Color m_OutColor = new Color(0,1,0);
	private Renderer m_Renderer;
	private bool m_GazeOver;

	private void Start(){
		m_Renderer = GetComponent<Renderer> ();
	}

	private void Awake(){
		if (m_InteractiveItem == null) {
			m_InteractiveItem = gameObject.AddComponent<VRInteractiveItem> ();
		}
	}

	private void OnEnable(){
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
	}

	private void HandleOver(){
		m_Renderer.material.color = m_OverColor;
		m_GazeOver = true;
	}

	private void HandleOut(){
		m_Renderer.material.color = m_OutColor;
		m_GazeOver = false;
	}
}
