using UnityEngine;
using TMPro;

namespace GameJam.MainMenu
{
    /// <summary>
    /// Handles the battle gameplay.
    /// </summary>
    public class GetHighScore : MonoBehaviour
    {   //==============================================================================
        // Variables
        //==============================================================================
        [SerializeField] private TextMeshProUGUI scoreText;



        //==============================================================================
        // Functions
        //==============================================================================
        private void Awake()
        {
            GetPlayerPref();
        }



        private void GetPlayerPref()
        {
            if (PlayerPrefs.HasKey("highscore"))
            {
                scoreText.text = PlayerPrefs.GetInt("highscore").ToString();
            }
        
            else
            {
                scoreText.text = "0";
            }
        }
    }
}