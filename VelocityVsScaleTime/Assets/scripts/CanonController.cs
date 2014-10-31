using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class CanonController : MonoBehaviour {

	public float speed = 10f;

	public Transform bulletStartPosition;

	public CanonBulletController canonBulletPrefab;

	public List<CanonBulletController> bulletPool;

	// Use this for initialization
	void Start () {

		// add one bullet to the pool

		CanonBulletController bulletGO = (CanonBulletController) GameObject.Instantiate (canonBulletPrefab, Vector3.zero, Quaternion.identity);

		CanonBulletController bullet = bulletGO.GetComponent<CanonBulletController>();

		bullet.OnBulletDisabled = OnBulletDisabled;

		//

		bulletPool = new List<CanonBulletController> ();

		bulletPool.Add (bullet);

		//
		StartCoroutine( ShootRoutine () );
	
	}

	void OnDisable(){
		foreach (CanonBulletController bullet in bulletPool) {
		
			bullet.OnBulletDisabled = null;

		}
	}

	IEnumerator ShootRoutine(){

		while(true){

			Shoot();

			yield return new WaitForSeconds(0.1f);

		}

	}

	void Shoot () {

		if (bulletPool.Count > 0) {

			CanonBulletController bullet = bulletPool.Pop();

			bullet.init();

			bullet.rigidbody.velocity = new Vector3 (1f, 1f, 0f) * speed * (1f / Time.timeScale);

			print ("---> " + bullet.rigidbody.velocity);

			bullet.transform.position = bulletStartPosition.position;
		}

	}

	void OnBulletDisabled(CanonBulletController bullet){

		bulletPool.Push(bullet);

	}
}
