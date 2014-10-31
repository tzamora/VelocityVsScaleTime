using UnityEngine;
using System.Collections;
using System;

public class CanonBulletController : MonoBehaviour {

	public Action<CanonBulletController> OnBulletDisabled;

	public void init(){

		StartCoroutine (CheckVisibilityRoutine());
	}

	IEnumerator CheckVisibilityRoutine(){

		bool isVisible = true;

		while(isVisible){

			yield return new WaitForSeconds(0.01f);

			if(!transform.GetBounds().IsVisibleFrom(Camera.main)){

				OnBulletDisabled(this);

				isVisible = false;

				break;
			}
		}
		
	}
}
