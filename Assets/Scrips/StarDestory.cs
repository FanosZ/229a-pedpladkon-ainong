using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDestory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Enermy")
        {
            Destroy(other.gameObject);
        }
    }
}
