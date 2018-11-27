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
