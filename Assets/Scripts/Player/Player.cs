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

        CinemachineVirtualCamera cam;
        GameObject actor;
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
            cam = (CinemachineVirtualCamera)GameObject.FindObjectOfType(typeof(CinemachineVirtualCamera));
            height = 1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f);
            width = 1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f);


            _Player = GameObject.Find("_Player");
            cam.Follow = transform;
            cam.LookAt = transform;

        }

        public void ActorStats(SOActorModel model)
        {

            health = model.health;
            hitPower = model.hitPower;
            travelSpeed = model.speed;
            fire = model.actorsBullets;

        }

        public void Die()
        {

            cam.Follow = _Player.transform;
            cam.LookAt = _Player.transform;
        }

        public void Revive()
        {
            throw new System.NotImplementedException();
        }

        public int SendDamage()
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(int incomingDamage)
        {
            throw new System.NotImplementedException();
        }
    }
}
