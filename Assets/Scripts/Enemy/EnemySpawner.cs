using System;
using System.Collections;
using com.sluggagames.gw2.Core;
using com.sluggagames.gw2.Core.Interfaces;
using UnityEngine;

namespace com.sluggagames.gw2.Enemy
{
    public class EnemySpawner : MonoBehaviour

    {
        [SerializeField]
        SOActorModel actorModel;
        [SerializeField]
        float spawnRate;
        [SerializeField]
        [Range(0, 10)]
        int quantity;

        GameObject enemies;

        private void Awake()
        {
            enemies = GameObject.Find("_enemies");
            StartCoroutine(FireEnemy(quantity, spawnRate));
        }

        IEnumerator FireEnemy(int qty, float spwnRate)
        {
            for (int i = 0; i < qty; i++)
            {
                GameObject enemyUnit = CreateEnemy();
                enemyUnit.gameObject.transform.SetParent(this.transform);
                enemyUnit.transform.position = transform.position;
                yield return new WaitForSeconds(spwnRate);
            }
            yield return null;

        }

        private GameObject CreateEnemy()
        {
            GameObject enemy = GameObject.Instantiate(actorModel.actor) as GameObject;
            var template = enemy.GetComponent<IActorTemplate>();
            template.ActorStats(actorModel);
            enemy.name = actorModel.actorName.ToString();
            return enemy;
        }
    }
}
