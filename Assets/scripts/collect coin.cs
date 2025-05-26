using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] private AudioSource coinFX;

    private void OnTriggerEnter(Collider other)
    {
        // Ensure only player triggers collection
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Coin collected");
            if (coinFX != null)
            {
                coinFX.Play(); // Capital 'P' in Play
            }

            MasterInfo.coinCount += 1; // Make sure MasterInfo is defined elsewhere

            gameObject.SetActive(false); // Correct syntax: lowercase 'g' in gameObject
        }
    }
}
