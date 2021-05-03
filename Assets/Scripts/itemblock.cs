using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemblock : MonoBehaviour
{
    public GameObject blockprefab;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            Vector2 vec = this.gameObject.transform.position;
            Destroy(this.gameObject);
            Instantiate(blockprefab, vec, Quaternion.identity);
        }
    }
}
