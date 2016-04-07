using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class GameManager : MonoBehaviour {

  private VRInteractiveItem[] m_InteractiveItems;
  private VRInput m_VRInput;

  [SerializeField] Camera m_MainCamera;
  [SerializeField] float m_MovementSpeed = 3f;

	// Use this for initialization
	void Start () {
   		 SetupMovement();
	}
		

  void SetupMovement() {
    // Find input manager
    m_VRInput = GameObject.FindObjectOfType<VRInput>();
    // This action is invoked on every single frame
    m_VRInput.OnSwipe += this.OnSwipe;
  }
		
  void OnSwipe(VRInput.SwipeDirection direction) {
    // Only do something when we have a swipe
    if(direction != VRInput.SwipeDirection.NONE) {
      switch(direction) {
        case VRInput.SwipeDirection.LEFT:
          m_MainCamera.transform.Translate(m_MovementSpeed * -1, 0, 0);
          break;
        case VRInput.SwipeDirection.RIGHT:
          m_MainCamera.transform.Translate(m_MovementSpeed, 0, 0);
          break;
      case VRInput.SwipeDirection.UP:
        m_MainCamera.transform.Translate(0, 0, m_MovementSpeed);
        break;
      case VRInput.SwipeDirection.DOWN:
        m_MainCamera.transform.Translate(0, 0, m_MovementSpeed * -1);
        break;
      }
    }
  }
}
