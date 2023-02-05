using UnityEngine;

namespace GameJam.Battle
{
    /// <summary>
    /// Handles battle data.
    /// </summary>
    public class DataManager : MonoBehaviour
    {   //==============================================================================
        // Variables
        //==============================================================================
        public static DataManager Instance;

        public static int playerScore;



        //==============================================================================
        // Functions
        //==============================================================================
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            DontDestroyOnLoad(this);
        }
    }
}