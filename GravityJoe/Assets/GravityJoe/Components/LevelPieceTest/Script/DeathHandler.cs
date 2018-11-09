using UnityEngine;

public class DeathHandler : MonoBehaviour
{

    // player info to find collision for this platform object
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(col.gameObject);
        }
    }
}
