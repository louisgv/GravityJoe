using UnityEngine;

namespace GravityJoe {

    public class Player : MonoBehaviour
    {

        PlayerMovement movement;

        void Awake()
        {
            movement = this.GetComponent<PlayerMovement>();
        }

        public PlayerMovement Movement
        {
            get
            {
                return movement;
            }
        }

        // Use this for initialization
        void Start()
        {
            movement = GetComponent<PlayerMovement>();
        }

    }
}
