using UnityEngine.SceneManagement;
using UnityEngine;

namespace com.sluggagames.gw2.Core
{

    public enum Scenes
    {
        bootup,
        testScene,
        title,
        shop,
        level1,
        level2,
        level3,
        gameOver
    }
    public class LevelManager : MonoBehaviour
    {

        public void BeginGame()
        {
            SceneManager.LoadScene(Scenes.testScene.ToString());
        }

        public void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void GameOver()
        {
            SceneManager.LoadScene(Scenes.gameOver.ToString());

        }


    }
}
