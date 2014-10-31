using UnityEngine;
using System.Collections;

public class GuiController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI() {

		GUILayout.BeginArea (new Rect (Screen.width/2, Screen.height/2, 300, 300));
		if (GUILayout.Button ("Slow time")) {
			Time.timeScale = 0.2f;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
		}
		
		if (GUILayout.Button ("Reset time")) {
			Time.timeScale = 1f;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
		}
		if (GUILayout.Button ("afect fixed delta time")) {
			
		}
		GUILayout.EndArea ();

	}
}
