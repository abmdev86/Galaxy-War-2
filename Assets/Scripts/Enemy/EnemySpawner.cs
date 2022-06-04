using System.Collections;
using com.sluggagames.gw2.Core;
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





    }
}
