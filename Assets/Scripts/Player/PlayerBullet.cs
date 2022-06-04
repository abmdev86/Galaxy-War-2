
using com.sluggagames.gw2.Core;
using com.sluggagames.gw2.Core.Interfaces;
using UnityEngine;

namespace com.sluggagames.gw2.Player
{
    public class PlayerBullet : MonoBehaviour, IActorTemplate
    {
        GameObject actor;
        int hitpower;
        int health;
        int travelSpeed;

        [SerializeField]
        SOActorModel bulletModel;




        private void Awake()
        {

            ActorStats(bulletModel);
        }

        private void Update()
        {
            transform.position += new Vector3(0, 0, -travelSpeed) * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy")
            {
                IActorTemplate enemy = other.GetComponent<IActorTemplate>();

                if (enemy != null)
                {
                    if (health >= 1)
                    {
                        health -= enemy.SendDamage();

                    }
                    if (health <= 0)
                    {
                        Die();
                    }
                }
            }
        }

        public void ActorStats(SOActorModel actorModel)
        {
            actor = actorModel.actor;
            hitpower = actorModel.hitPower;
            health = actorModel.health;
            travelSpeed = actorModel.speed;

        }

        public void Die()
        {
            Destroy(this.gameObject);
        }

        void OnBecameInvisible()
        {
            Die();
        }

        public void Revive()
        {

        }

        public int SendDamage()
        {
            return hitpower;
        }

        public void TakeDamage(int incomingDamage)
        {
            health -= incomingDamage;
        }
    }
}
