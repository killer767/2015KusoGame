using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class LifeCounter : MonoBehaviour {

	public Text lifeText;

	[SerializeField] private FirstPersonController fpsCtrler;

	private static LifeCounter m_instance;
	public static LifeCounter instance{
		get{
			if(m_instance == false){
				m_instance = FindObjectOfType<LifeCounter>();
			}
			return m_instance;
		}
	}

	public bool AddLife (int amt) {
		int life = Convert.ToInt32(lifeText.text) + amt;
		if (life > 0) {
			lifeText.text = life.ToString("0");
			return true;
		}
		else {
			lifeText.text = "0";
			GameObject.Find("Die").GetComponent<Text>().enabled = true;
			GameObject.Find("Die").GetComponent<Animator>().SetBool("DieShow",true);
			fpsCtrler.WalkSpeed = 0f;
			fpsCtrler.RunSpeed = 0f;
			GameObject.Find("Menu").SendMessage("Stop");
			GameObject.Find("Player").transform.position = new Vector3(0f, 1.5f, -8f);
			return false;
		}
	}
}
