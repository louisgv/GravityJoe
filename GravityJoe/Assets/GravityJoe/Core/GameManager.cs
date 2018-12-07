using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GravityJoe
{
    public class GameManager : MonoBehaviour
    {

        // base objects for instantiation
        [SerializeField]
        Player playerPrefab;
        [SerializeField]
        GameObject hangingObjectPrefab;
        [SerializeField]
        GameObject destructibleWallPrefab;
        [SerializeField]
        public int deathCount;
        public static int allDeaths;

        // current gameObjects in scene
        Player currentPlayer;
        Platform currentPlatform;

        Text deathL;
        Text deathG;

        public List<GameObject> currentHangingObjects;
        public List<GameObject> currentDestructibleWalls;


        // Use this for initialization
        void Start()
        {
            currentPlayer = Utility.GetPlayer();
            currentPlatform = Utility.GetPlatform();
            deathL = GameObject.Find("deathsL").GetComponent<Text>();
            deathG = GameObject.Find("deathsG").GetComponent<Text>();
        }

        private void Update()
        {
            deathL.text = "Deaths on Level: " + deathCount;
            deathG.text = "Death Total: " + (allDeaths+deathCount);
        }

        public void ResetLevel()
        {
            ResetDestructibleObjects();
            ResetLevelOrientation();
            ResetPlayer();
        }

        // used to reset player
        void ResetPlayer()
        {
            currentPlayer.transform.position = Vector3.zero;
            currentPlayer.transform.rotation = Quaternion.identity;
        }

        // used to reset destructible objects
        void ResetDestructibleObjects()
        {

        }
        // used to reset level orientation
        void ResetLevelOrientation()
        {
            currentPlatform.ResetRotation();
        }
    }

}
