using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FallDown : MonoBehaviour {

	private Rigidbody m_rigibody;

	private bool isJump;
	private bool isHit;

	void Start () {
		m_rigibody = GetComponent<Rigidbody> ();
		isJump = false;
		isHit = false;
	}
	
	void Update () {

	}

	void OnCollisionEnter (Collision coll){
		if (coll.collider.name.Contains("Floor") && isJump == false) {
			m_rigibody.AddForce(Vector3.up * 300f);
			isHit = true;
			isJump = true;
		}

//		if (coll.collider.tag == "Player" && isHit == false) {
//			LifeCounter.instance.AddLife(-1);
//			isHit = true;
//		}

		if (coll.collider.tag == "Player") {
			LifeCounter.instance.AddLife(-1);
			isHit = true;
		}
	}
}
