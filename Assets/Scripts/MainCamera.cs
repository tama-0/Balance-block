using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
	public GameObject player;
	public float height = 5.0f;
	public float pos = -6.5f;

	void Start()
	{

	}


	void Update()
	{
        Vector3 playerpos = player.transform.position;
        transform.position = new Vector3(playerpos.x, playerpos.y + height, playerpos.z + pos);
	}
}
