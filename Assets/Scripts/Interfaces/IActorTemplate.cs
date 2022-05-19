using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.sluggagames.gw2.Core.Interfaces
{
    public interface IActorTemplate
    {
        int SendDamage();
        void TakeDamage(int incomingDamage);
        void Die();
        void Revive();
        void ActorStats(SOActorModel actorModel);
    }
}
