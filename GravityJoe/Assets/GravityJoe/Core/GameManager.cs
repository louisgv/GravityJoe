using System.Collections;
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
        Platform platformPrefab;
        [SerializeField]
        DeathHandler deathObjectPrefab;
        [SerializeField]
        GameObject hangingObjectPrefab;
        [SerializeField]
        GameObject destructibleWallPrefab;

        // current gameObjects in scene
        public Player currentPlayer;
        public Platform currentPlatform;
        public DeathHandler currentDeathObject;

        public List<GameObject> currentHangingObjects;
        public List<GameObject> currentDestructibleWalls;
        public List<DeathHandler> currentDeathObjects;
        public List<Platform> currentPlatforms;


        // Use this for initialization
        void Start()
        {
            // check if player already exists, if not, spawn one
            if (Utility.GetPlayer() == null)
                currentPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

            // creates one platform and one death object for testing
            currentPlatforms.Add(Instantiate(platformPrefab, new Vector3(0, -5f, 0), Quaternion.identity));
            currentDeathObjects.Add(Instantiate(deathObjectPrefab, new Vector3(3.5f, -4f, 0), Quaternion.identity));

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
