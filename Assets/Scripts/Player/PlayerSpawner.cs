using System.Collections;
using com.sluggagames.gw2.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace com.sluggagames.gw2.Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        SOActorModel actorModel;
        GameObject playerShip;

        private void Start()
        {
            StartCoroutine(InitPlayer());

        }

        IEnumerator InitPlayer()
        {
            // load player assets
            yield return LoadAssets();

            // instantiate the actor model.
            playerShip = GameObject.Instantiate(actorModel.actor) as GameObject;
            playerShip.GetComponent<Player>().ActorStats(actorModel);
            //enusure we have actor model
            yield return new WaitForSeconds(1);
            //if we have model setup player.
            SetupPlayer();

        }
        void SetupPlayer()
        {
            playerShip.transform.rotation = Quaternion.Euler(0, 180, 0);
            playerShip.transform.localScale = new Vector3(60, 60, 60);
            playerShip.name = actorModel.actorName;
            playerShip.transform.SetParent(this.transform);
            playerShip.transform.position = Vector3.zero;
        }
        IEnumerator LoadAssets()
        {
            AsyncOperationHandle<SOActorModel> playerActorModel = Addressables.LoadAssetAsync<SOActorModel>("PlayerActorModel");
            yield return playerActorModel;
            if (playerActorModel.Status == AsyncOperationStatus.Succeeded)
            {
                actorModel = playerActorModel.Result;

            }
            else
            {
                Debug.LogError("Unable to load assets for player");
            }
        }

        private void OnDisable()
        {
            Addressables.Release(actorModel);
        }



    }
}
