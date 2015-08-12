using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {

	private bool isGetKey;
	private bool isFound;

	[SerializeField] private FirstPersonController fpsCtrler;

	void Start () {
		isGetKey = false;
		isFound = false;
	}
	
	void Update () {

		if (Input.GetKeyDown (KeyCode.P) && isGetKey == true) {
			GameObject.Find("Bed").GetComponent<Animator>().enabled = true;
			GameObject.Find("PressP").GetComponent<Text>().enabled = false;
			GameObject.Find("Haha").GetComponent<Text>().enabled = true;
			GameObject.Find("Bed").GetComponent<AudioSource>().Play();
			StartCoroutine("WaitB");
		}

		if (Input.GetKeyDown (KeyCode.P) && isFound == true) {
			GameObject.Find("End").GetComponent<Text>().enabled = true;
			StartCoroutine("WaitE");
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.name == "Curtain") {
			GameObject.Find("RoomDoor").GetComponentInChildren<Animator>().SetTrigger("Open");
			StartCoroutine("WaitC");
		}

		if (other.name == "Bed") {
			GameObject.Find("PressP").GetComponent<Text>().enabled = true;
			isGetKey = true;
		}

		if (other.name == "END_SHIT") {
			isFound = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.name == "Bed") {
			GameObject.Find ("PressP").GetComponent<Text> ().enabled = false;
			isGetKey = false;
		}

		if (other.name == "END_SHIT") {
			isFound = false;
		}
	}

	IEnumerator WaitB(){
		fpsCtrler.WalkSpeed = 0f;
		fpsCtrler.RunSpeed = 0f;
		yield return new WaitForSeconds (3);
		GameObject.Find("Haha").GetComponent<Text>().enabled = false;
		LifeCounter.instance.AddLife(-5);

	}

	IEnumerator WaitC(){
		yield return new WaitForSeconds (4);
		GameObject.Find ("DoorHold").GetComponent<Animator> ().enabled = true;
	}

	IEnumerator WaitE(){
		fpsCtrler.WalkSpeed = 0f;
		fpsCtrler.RunSpeed = 0f;
		yield return new WaitForSeconds (3);
		GameObject.Find("End").GetComponent<Text>().enabled = false;
		LifeCounter.instance.AddLife(-5);
		//GameObject.Find("Player").transform.position = new Vector3(0f, 1.5f, -8f);
		//GameObject.Find ("Menu").GetComponent<Animator> ().SetBool ("Hide",false);
		//GameObject.Find ("Menu").GetComponentInChildren<Button>().enabled = true;
	}
}