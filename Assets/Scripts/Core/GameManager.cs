using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.sluggagames.gw2.Core
{
    public class GameManager : MonoBehaviour
    {
        static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                return instance;
            }
        }

        void Awake()
        {
            CheckGameManager();
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
