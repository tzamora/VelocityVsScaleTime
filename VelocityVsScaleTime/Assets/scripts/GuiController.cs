using UnityEngine;
using System.Collections;

public class GuiController : MonoBehaviour {

	Vector3 defaultGravity = Vector3.zero;

	public 

	// Use this for initialization
	void Start () {
		defaultGravity = Physics.gravity;
	}
	
	void OnGUI() {

		GUILayout.BeginArea (new Rect (Screen.width/2, Screen.height/2, 100, 100));
		if (GUILayout.Button ("Slow time")) {
			Time.timeScale = 0.5f;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
//			Physics.gravity = Physics.gravity * 4f;
		}
		
		if (GUILayout.Button ("Reset time")) {
			Time.timeScale = 1f;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
//			Physics.gravity = defaultGravity;
		}

		GUILayout.EndArea ();

	}
}
