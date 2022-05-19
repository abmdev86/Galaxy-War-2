using com.sluggagames.gw2.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace com.sluggagames.gw2.Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        SOActorModel actorModel;
        GameObject playerShip;

        private void Start()
        {

            LoadAssets();

            CreatePlayer();
        }
        void CreatePlayer()
        {
            // create the player
            // actorModel = Object.Instantiate(Addressables.LoadAssetAsync<SOActorModel>("Assets/Scripts/ScriptableObjects/Player_Default.asset"));
        }

        void LoadAssets()
        {

        }



    }
}
