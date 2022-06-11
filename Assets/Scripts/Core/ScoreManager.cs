using UnityEngine;

namespace com.sluggagames.gw2
{
    public class ScoreManager : MonoBehaviour
    {
      static int playerScore;
      public int PlayerScore => playerScore;


      public void SetScore(int value){
        playerScore+= value;
      }

      public void ResetScore(){
       // PlayerPrefs.SetInt("Player Score", playerScore);

        playerScore = 0000000;
      }

    }
}
