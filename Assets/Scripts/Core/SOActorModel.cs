using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.sluggagames.gw2.Core
{

    [CreateAssetMenu(fileName = "Create Actor", menuName = "Create Actor")]
    public class SOActorModel : ScriptableObject
    {
        public string actorName;
        public int score;
        public AttackType attackType;

        public enum AttackType
        {
            wave, player, flee, bullet
        }

        public string description;
        public int health;
        public int speed;
        public int hitPower;
        public GameObject actor;
        public GameObject actorsBullets;
    }
}
