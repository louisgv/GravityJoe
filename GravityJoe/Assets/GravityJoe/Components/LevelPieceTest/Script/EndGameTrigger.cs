using UnityEngine;
using UnityEngine.SceneManagement;

namespace GravityJoe
{
    public class EndGameTrigger : MonoBehaviour
    {

        public bool endGame;
        public string nextLevelName;
        GameManager gameManager;

        void Awake()
        {
            gameManager = Utility.GetGameManager();
        }

        public GameObject winText;

        void OnTriggerEnter2D(Collider2D col)
        {
            if (endGame)
            {
                //Time.timeScale = 0f;
                gameManager.deathCount = 0;
                SceneManager.LoadScene("WinScreen");
                return;
            }
            GameManager.allDeaths += gameManager.deathCount;
            SceneManager.LoadScene(nextLevelName);
        }
    }
}

