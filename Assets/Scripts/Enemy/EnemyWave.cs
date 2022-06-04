
using com.sluggagames.gw2.Core;
using com.sluggagames.gw2.Core.Interfaces;
using UnityEngine;

namespace com.sluggagames.gw2.Enemy
{
    public class EnemyWave : MonoBehaviour, IActorTemplate
    {

        int health;
        int travelSpeed;
        int firingSpeed;
        int hitPower;

        [SerializeField]
        float verticalSpeed = 2f;
        [SerializeField]
        float verticalAmplitude = 1;
        Vector3 sinVector;
        float time;

        private void Update()
        {
            Attack();

        }

        void Attack()
        {

            time += Time.deltaTime;
            sinVector.y = Mathf.Sin(time * verticalSpeed) * verticalAmplitude;
            transform.position = new Vector3(transform.position.x, transform.position.y + sinVector.y, transform.position.z + travelSpeed * Time.deltaTime);
        }

        public void ActorStats(SOActorModel actorModel)
        {
            health = actorModel.health;
            travelSpeed = actorModel.speed;
            hitPower = actorModel.hitPower;
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                if (health >= 1)
                {
                    health -= other.GetComponent<IActorTemplate>().SendDamage();

                }
                if (health <= 0)
                {
                    Die();
                }
            }
        }
        public void Revive()
        {
            throw new System.NotImplementedException();
        }

        public int SendDamage()
        {
            return hitPower;
        }

        public void TakeDamage(int incomingDamage)
        {
            health -= incomingDamage;
        }
    }
}
