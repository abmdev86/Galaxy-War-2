using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;
using System;

namespace com.sluggagames.gw2.Core
{
    public  class GameManager : MonoBehaviour
    {
        static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                return instance;
            }
        }

    LevelManager sceneManager;
    ScoreManager scoreManager;

        public static int currentScene = 0;
        public static int gameLevelScene = 3;

        public static int playerLives = 3;
        CinemachineVirtualCamera cam;
        bool died = false;
        public bool Died
        {
            get { return died; }
            set { died = value; }
        }

        void Awake()
        {
            cam = (CinemachineVirtualCamera)GameObject.FindObjectOfType(typeof(CinemachineVirtualCamera));
            CheckGameManager();
            
            sceneManager = GetComponent<LevelManager>();
            scoreManager = GetComponent<ScoreManager>();
            
            
           

            // change to a call to the levelmanager to get this ....
            currentScene = SceneManager.GetActiveScene().buildIndex;
            currentScene = sceneManager.GetCurrentSceneIndex();
        }

        void LightAndCameraSetup(int sceneIndex)
        {
            switch (sceneIndex)
            {
                case 3:
                case 4:
                case 5:
                case 6:
                    {
                        LightSetup();
                        CameraSetup();
                        break;
                    }
            }
        }

        private void CameraSetup()
        {
            var player = GameObject.Find("_player");
        }

        public void LifeLost(){
            if(playerLives >=1){
            playerLives--;
            print($"Lives remaining {playerLives}");
           sceneManager.ResetScene();
            }else{
                playerLives = 3;
                sceneManager.GameOver();
            }
        }

        public void SetScore(int value){
             scoreManager.SetScore(value);
            }

        private void LightSetup()
        {
            throw new NotImplementedException();
        }

        void CheckGameManager()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {

                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this);
        }
    }
}
