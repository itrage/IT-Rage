using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour {
    
    public Transform[] objectHold; 
    public Transform objectPosition;
    public GameObject player;

    Transform item;

    public Transform Item {
        get { return item; }
    }

    void Awake() {
        int objectIndex = Random.Range(0, objectHold.Length);
        Vector3 newPosition = new Vector3(0.2f, 0.1f);
        item = Instantiate(objectHold[objectIndex], player.transform.position + newPosition, player.transform.rotation, objectPosition);   
    }
}
