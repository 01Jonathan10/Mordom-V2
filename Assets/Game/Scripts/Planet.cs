using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

	public int life;
	public int shield;
	public GameObject currentWeapon;

	// Use this for initialization
	void Start () {
		life = 100;
		shield = 0;
		currentWeapon = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
