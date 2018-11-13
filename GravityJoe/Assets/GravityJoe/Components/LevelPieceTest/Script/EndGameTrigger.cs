using UnityEngine;

namespace GravityJoe
{
    public class EndGameTrigger : MonoBehaviour
    {

        void OnTriggerEnter2D(Collider2D col)
        {
            Time.timeScale = 0f;
        }
    }
}

