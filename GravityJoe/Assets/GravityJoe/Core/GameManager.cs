using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
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
        currentPlatform = Instantiate(platformBase, new Vector3(0, -5f, 0), Quaternion.identity);
        currentDeathObject = Instantiate(deathObjectBase, new Vector3(3.5f, -4f, 0), Quaternion.identity);

        currentDeathObject.GetComponent<DeathHandler>().player = currentPlayer;
        //Camera.SetupCurrent(currentPlayer.GetComponentInChildren<Camera>());
        
	}
	
	// Update is called once per frame
	void Update () {
        if (currentPlayer == null)
        {
            currentPlayer = Instantiate(playerBase, Vector3.zero, Quaternion.identity);
            currentDeathObject.GetComponent<DeathHandler>().player = currentPlayer;
        }
            
    }

    void ResetDestructibleObjects()
    {

    }

    void ResetLevelOrientation()
    {

    }
}
