using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    // base objects for instantiation
    [SerializeField]
    GameObject playerBase;
    [SerializeField]
    GameObject platformBase;
    [SerializeField]
    GameObject deathObjectBase;
    [SerializeField]
    GameObject hangingObjectBase;
    [SerializeField]
    GameObject destructibleWallBase;

    // current gameObjects in scene
    public GameObject currentPlayer;
    public GameObject currentPlatform;
    public GameObject currentDeathObject;
    public List<GameObject> currentHangingObjects;
    public List<GameObject> currentDestructibleWalls;


    // Use this for initialization
    void Start () {
        // check if player already exists, if not, spawn one
        if (GravityJoe.Utility.GetPlayer() == null)
            currentPlayer = Instantiate(playerBase, Vector3.zero, Quaternion.identity);

        // creates one platform and one death object for testing
        currentPlatform = Instantiate(platformBase, new Vector3(0, -5f, 0), Quaternion.identity);
        currentDeathObject = Instantiate(deathObjectBase, new Vector3(3.5f, -4f, 0), Quaternion.identity);

        // sets death object's player GameObject to the current player object (for testing)
        currentDeathObject.GetComponent<DeathHandler>().player = currentPlayer;
        
	}
	
	// Update is called once per frame
	void Update () {

        // resets player and player object in death object if the player dies (for testing)
        if (currentPlayer == null)
        {
            currentPlayer = Instantiate(playerBase, Vector3.zero, Quaternion.identity);
            currentDeathObject.GetComponent<DeathHandler>().player = currentPlayer;
        }
            
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
