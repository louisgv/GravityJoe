using System.Collections.Generic;
using UnityEngine;

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

        // current gameObjects in scene
        Player currentPlayer;
        Platform currentPlatform;

        public List<GameObject> currentHangingObjects;
        public List<GameObject> currentDestructibleWalls;


        // Use this for initialization
        void Start()
        {
            currentPlayer = Utility.GetPlayer();
            currentPlatform = Utility.GetPlatform();
        }

        // Update is called once per frame
        void Update()
        {

            // resets player and player object in death object if the player dies (for testing)
            if (currentPlayer == null)
            {
                ResetPlayer();
                ResetDestructibleObjects();
                ResetLevelOrientation();
            }

        }

        // used to reset player
        void ResetPlayer()
        {
            currentPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }

        // used to reset destructible objects
        void ResetDestructibleObjects()
        {

        }
        // used to reset level orientation
        void ResetLevelOrientation()
        {

        }
    }

}
