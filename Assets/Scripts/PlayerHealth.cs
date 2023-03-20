using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public int healthAmount = 1; // amount of health to add or subtract
    public GameObject player; // reference to player object
    private PlayerHealth playerHealth; // reference to player health script
    private Image heartImage; // reference to heart image component

    private void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>(); // get player health script
        heartImage = GetComponent<Image>(); // get heart image component
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.Heal(healthAmount); // add health to player when heart is collected
            heartImage.enabled = false; // hide heart image
            GetComponent<Collider2D>().enabled = false; // disable collider so heart can't be collected again
            StartCoroutine(RespawnHeart()); // start coroutine to respawn heart after a delay
        }
    }

    IEnumerator RespawnHeart()
    {
        yield return new WaitForSeconds(10f); // wait for 10 seconds before respawning heart
        heartImage.enabled = true; // show heart image again
        GetComponent<Collider2D>().enabled = true; // enable collider again so heart can be collected
    }
}
