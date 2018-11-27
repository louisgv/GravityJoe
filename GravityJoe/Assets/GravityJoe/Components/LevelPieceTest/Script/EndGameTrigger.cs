using UnityEngine;
using UnityEngine.SceneManagement;

namespace GravityJoe
{
    public class EndGameTrigger : MonoBehaviour
    {

        public bool endGame;
        public string nextLevelName;

        public GameObject winText;

        void OnTriggerEnter2D(Collider2D col)
        {
            if (endGame)
            {
                Time.timeScale = 0f;
                winText.SetActive(true);
                return;
            }
            SceneManager.LoadScene(nextLevelName);
        }
    }
}

