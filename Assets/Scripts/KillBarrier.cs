using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Find the spawn point by tag
            GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
            
            // Check if the spawn point exists to avoid null reference errors
            if (spawnPoint != null)
            {
                // Move the player to the spawn point position
                collision.transform.position = spawnPoint.transform.position;
                
                // Optional: Reset player velocity to zero if needed
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.zero;
                }
            }
            else
            {
                Debug.LogError("Spawn point not found. Make sure your spawn point is tagged correctly.");
            }
        }
    }
}
