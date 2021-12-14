using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPostionTrigger : MonoBehaviour
{
    public GameObject itemsObject;
    public float heightToMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + heightToMove, other.transform.position.z);
        }
    }
}
