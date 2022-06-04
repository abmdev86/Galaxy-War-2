using System.Collections;
using Cinemachine;
using com.sluggagames.gw2.Core;
using com.sluggagames.gw2.Core.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace com.sluggagames.gw2.Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class Player : MonoBehaviour, IActorTemplate
    {
        int travelSpeed;
        int health;
        int hitPower;
        Vector2 move;
        CinemachineVirtualCamera cam;
        Rigidbody rb;
        GameObject actor;
        [SerializeField]
        GameObject fire;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;

            }
        }
        public GameObject Fire
        {
            get
            {
                return fire;

            }
            set
            {
                fire = value;
            }
        }
        GameObject _Player;
        float width;
        float height;


        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            cam = (CinemachineVirtualCamera)GameObject.FindObjectOfType(typeof(CinemachineVirtualCamera));
            height = 1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f);
            width = 1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f);

            Debug.Log(height + " and width: " + width);
            _Player = GameObject.Find("_player");
            cam.Follow = transform;
            cam.LookAt = transform;

        }

        private void FixedUpdate()
        {
            Movement(move);
        }


        void Movement(Vector2 movement)
        {
            movement.Normalize();
            //rb.Move(Vector3 position, Quaternion rotation); 2022.1+
            Vector3 newMove = new Vector3(0, movement.y, -movement.x);
            rb.MovePosition(transform.position + newMove * Time.deltaTime * travelSpeed);

        }

        #region Unity Callbacks

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy")
            {
                if (health >= 1)
                {
                    // check for player shield
                    if (transform.Find("energy +1(Clone"))
                    {
                        Destroy(transform.Find("energy +1(Clone)").gameObject);
                        health -= other.GetComponent<IActorTemplate>().SendDamage();
                    }
                    else
                    {
                        health -= 1;
                    }
                }
                if (health <= 0)
                {
                    Die();
                }
            }
        }
        #endregion
        #region  IActorTemplate Methods
        public void TakeDamage(int incomingDamage)
        {
            health -= incomingDamage;
        }
        public int SendDamage()
        {
            return hitPower;
        }

        public void Die()
        {

            cam.Follow = _Player.transform;
            cam.LookAt = _Player.transform;
        }
        public void ActorStats(SOActorModel model)
        {

            health = model.health;
            hitPower = model.hitPower;
            travelSpeed = model.speed;
            fire = model.actorsBullets;

        }
        public void Revive()
        {
            throw new System.NotImplementedException();
        }
        #endregion
        #region PlayerInput Callbacks


        public void OnMove(InputValue value)
        {

            move = value.Get<Vector2>();

        }

        public void OnFire(InputValue value)
        {
            if (value.isPressed)
            {
                GameObject bullet = GameObject.Instantiate(fire, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                bullet.transform.SetParent(_Player.transform);

            }
        }

        #endregion


    }
}
