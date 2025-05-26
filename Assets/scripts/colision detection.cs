using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionDetect : MonoBehaviour
{
    [SerializeField] private GameObject theplayer;
    [SerializeField] private GameObject playerAnim;
    

    private void OnTriggerEnter(Collider other)
    {
        theplayer.GetComponent<PlayerMovement>().enabled = false;
        playerAnim.GetComponent<Animator>().Play("stumble Backwards");
    }
}
