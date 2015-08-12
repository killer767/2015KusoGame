using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Again : MonoBehaviour {


	private Animator m_animator;
	

	void Start () {
		m_animator = GetComponent<Animator> ();
	}
	
	public void Res () {
		GameObject.Find ("Main Camera").GetComponent<AudioSource> ().Pause ();
		GameObject.Find("Die").GetComponent<Text>().enabled = false;
		m_animator.SetBool ("DieShow", false);
		GameObject.Find ("Menu").GetComponent<Animator> ().SetBool ("Hide",false);
		GameObject.Find ("Menu").GetComponentInChildren<Button>().enabled = true;
	}
}
