using UnityEngine;

namespace GravityJoe
{

    public class PlayerShoot : MonoBehaviour
    {

        float chargeBeginTime = -1.0f;
        float timeOfLastFire = -1.0f;
        bool isCharging = false;
        public float maxCharge = 2.0f;

        public ArrowScript arrow;
        public MissileScript missile;

        public float arrowSpeed;
        public float missileSpeed;
        public float explosionRadius;
        public float explosionMagnitude;
        public float timeBetweenShots = 1.0f;
        WEAPON currentWeapon = WEAPON.BOW;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            CheckWeapons();
            if (Time.time - timeOfLastFire >= timeBetweenShots)
            {
                switch (currentWeapon)
                {
                    case WEAPON.BOW:
                        CheckFireBow();
                        break;
                    case WEAPON.ROCKET_LAUNCHER:
                        CheckFireLauncher();
                        break;
                    default:
                        break;
                }
            }
        }

        void CheckWeapons()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentWeapon = WEAPON.BOW;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentWeapon = WEAPON.ROCKET_LAUNCHER;
            }
        }

        void CheckFireBow()
        {
            if (Input.GetMouseButtonDown(0))
            {
                chargeBeginTime = Time.time;
                isCharging = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isCharging = false;
                float mag = (Time.time - chargeBeginTime) / maxCharge;
                if (mag > 1.0f) mag = 1.0f;
                if (mag > 0.5) FireArrow(mag);
            }
        }

        void CheckFireLauncher()
        {
            if (Input.GetMouseButtonDown(0))
            {
                FireMissile();
            }
        }

        void FireArrow(float magnitude)
        {
            Vector2 mouseDir = ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position)).normalized;

            ArrowScript newArrow = Instantiate(arrow, gameObject.transform.position, Quaternion.identity);

            newArrow.GetComponent<Rigidbody2D>().AddForce(mouseDir * arrowSpeed * magnitude, ForceMode2D.Impulse);

            timeOfLastFire = Time.time;
        }

        void FireMissile()
        {
            Vector2 mouseDir = ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position)).normalized;

            MissileScript newMissile = Instantiate(missile, gameObject.transform.position, Quaternion.identity);
            newMissile.missileSpd = missileSpeed;
            newMissile.explosionRadius = explosionRadius;
            newMissile.explosionMagnitude = explosionMagnitude;
            newMissile.transform.right = mouseDir;
            timeOfLastFire = Time.time;
        }
    }
}
