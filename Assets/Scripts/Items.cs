using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int itemValue = 1;
    public AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position); //  звук підбору
            other.gameObject.GetComponent<ItemCollector>().CollectItem(itemValue);

            Destroy(gameObject); 
        }
    }
}


