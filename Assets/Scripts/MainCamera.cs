using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
	public GameObject player;
	public float hight = 5.0f;
	public float pos = -6.5f;

	void Start()
	{

	}


	void Update()
	{
		Vector3 playerpos = this.player.transform.position;
		transform.position = new Vector3(playerpos.x, playerpos.y + hight, playerpos.z + pos);
	}
}
