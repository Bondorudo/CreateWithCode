using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 17, -16);
    

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
