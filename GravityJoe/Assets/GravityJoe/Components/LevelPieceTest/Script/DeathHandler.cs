using UnityEngine;

namespace GravityJoe
{

    public class DeathHandler : MonoBehaviour
    {

        GameManager gameManager;

        void Awake()
        {
            gameManager = Utility.GetGameManager();
        }

        // player info to find collision for this platform object
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                // Destroy(col.gameObject);
                gameManager.deathCount++;
                gameManager.ResetLevel();
            }
        }
    }
}
