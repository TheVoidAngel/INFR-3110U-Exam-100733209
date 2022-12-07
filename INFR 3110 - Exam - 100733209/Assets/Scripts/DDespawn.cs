using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDespawn : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameObject.SetActive(false);
        }
    }
}
