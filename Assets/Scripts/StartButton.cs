using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class StartButton : MonoBehaviour {

	public GameObject[] prefab;

	private Animator m_animator;

	[SerializeField] private FirstPersonController fpsCtrler;

	void Start () {
		m_animator = GetComponent<Animator> ();
	}
	
	public void Kuso () {
		StartCoroutine ("GlassSound");
		m_animator.SetBool ("Hide",true);
		LifeCounter.instance.AddLife(3);
		InvokeRepeating ("Spawn", .5f, .05f);
		fpsCtrler.WalkSpeed = 5f;
		fpsCtrler.RunSpeed = 10f;
		GameObject.Find ("Menu").GetComponentInChildren<Button>().enabled = false;
	}

	public void Stop(){
		CancelInvoke ("Spawn");
	}

	void Spawn (){
		GameObject obj = (GameObject) Instantiate(prefab[Random.Range (0, prefab.Length)]);
		obj.transform.position = new Vector3 (
			Random.Range (-3, 3),
			25f,
			Random.Range (5, 380)
			);
		Destroy (obj, 3f);
	}

	IEnumerator GlassSound(){
		yield return new WaitForSeconds (3);
		GameObject.Find ("Main Camera").GetComponent<AudioSource> ().Play ();
	}
}
