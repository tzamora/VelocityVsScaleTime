using UnityEngine;
using System.Collections;
using System;

public class CanonBulletController : MonoBehaviour {

	public Action<CanonBulletController> OnBulletDisabled;

	private float initialMass = 0f;

	private float initialDrag = 0f;

	// Use this for initialization
	void Start () {

		init ();

		//rigidbody.constantForce.force = new Vector3(1f, 0f, 0f) ; 

		//constantForce.relativeForce = new Vector3(1f, 0f, 0f);\

		rigidbody.velocity = new Vector3 (1f, 1f, 1f) * 10;

	}

	void Update(){

//		GetComponent<Rigidbody> ().mass = initialMass * Time.timeScale;
//
//		GetComponent<Rigidbody> ().drag = initialDrag * Time.timeScale;
	}

	void FixedUpdate() {


		//rigidbody.AddForce( new Vector3(1f, 0f, 0f) * 10f * Time.deltaTime ,ForceMode.Acceleration) ;

		print ("--- est0 cambio?" + rigidbody.velocity);
	}

	public void init(){

		initialMass = GetComponent<Rigidbody> ().mass;

		StartCoroutine (CheckVisibilityRoutine());
	}

	IEnumerator CheckVisibilityRoutine(){

		bool isVisible = true;

		while(isVisible){

			if(!transform.GetBounds().IsVisibleFrom(Camera.main)){

				OnBulletDisabled(this);

				isVisible = false;

			}
			
			yield return new WaitForSeconds(0.1f);
			
		}
		
	}
}
