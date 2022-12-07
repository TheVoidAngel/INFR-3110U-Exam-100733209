using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    ObjectPooler instance;

    public Transform spawnerPos;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Rigidbody rb = ObjectPooler.instance.Spawn("ghost", spawnerPos.transform.position).GetComponent<Rigidbody>();
        }
    }
}
