using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    
    public float coolDownDefault = 5f;
    public float coolDown = 0;

    // Update is called once per frame
    void Update()
    {
        coolDown += Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && coolDown > coolDownDefault)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            coolDown = 0;
        }
    }
}
