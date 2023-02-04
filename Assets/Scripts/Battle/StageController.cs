using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace GameJam.Battle
{
    /// <summary>
    /// Handles the battle gameplay.
    /// </summary>
    public class StageController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================



        //==============================================================================
        // Functions
        //==============================================================================
        public static void OnPlayerDeath()
        {
            Debug.Log("GAME OVER");
        }



        public static void OnEnemyDeath()
        {
            Debug.Log("PREPARING NEXT STAGE");
        }
    }
}

