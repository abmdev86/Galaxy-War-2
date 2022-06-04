using UnityEngine.SceneManagement;
using UnityEngine;

namespace com.sluggagames.gw2.Core
{
    public enum Scenes
    {
        bootup,
        title,
        shop,
        level1,
        level2,
        level3,
        gameOver
    }
    public class SceneManager : MonoBehaviour
    {
        public void ResetScene()

        {
            SceneManager.LoadScene(SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
