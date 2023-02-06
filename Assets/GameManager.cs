using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class GameManager : MonoBehaviour
    {
        public int numberOfPlayers = 1;
        public Character[] characters;
        public PubCharacterInput[] characterInputs;

      
        // Sub Managers					
     

        public PlayerManager playerManager { get; private set; }

        
        //	Singleton				
       



        private static global::GameManager instance;
        private static object appLock = new object();
        private static bool isClosing = false;

        private GameManager() { }


        public static global::GameManager Instance()
        {
            if (isClosing)
            {
                return null;
            }

            lock (appLock)
            {
                instance = FindObjectOfType(typeof(global::GameManager)) as global::GameManager;

                if (FindObjectsOfType(typeof(global::GameManager)).Length > 1)
                {
                    Debug.LogError("There are more application managers. Please Halp, this is wrong.");
                }
                else if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    instance = singleton.AddComponent<global::GameManager>();
                    singleton.name = "GameManager";
                    DontDestroyOnLoad(singleton);
                }

                return instance;
            }
        }

        
        // Setting Game up	    		
        

        void Awake()
        {
            playerManager = GetComponent<PlayerManager>();
        }

       

        public void OnDestroy()
        {
            isClosing = true;
        }
    }
