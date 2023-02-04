using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameJam.Battle
{
    /// <summary>
    /// Handles the battle gameplay.
    /// </summary>
    public class TimeScaleButton : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private bool isTimeScaledUp = false;
        private Image buttonImage;
        [SerializeField] private TextMeshProUGUI timeScaleText;


        //==============================================================================
        // Functions
        //==============================================================================
        private void Awake()
        {
            buttonImage = gameObject.GetComponent<Image>();
        }
        


        public void TimeScaleUp()
        {
            // turn off
            if (isTimeScaledUp)
            {
                Time.timeScale = 1f;
                isTimeScaledUp = false;
                timeScaleText.enabled = false;
                buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 0.44f);
            }

            // turn on
            else if (!isTimeScaledUp)
            {
                Time.timeScale = 2f;
                isTimeScaledUp = true;
                timeScaleText.enabled = true;
                buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 1f);
            }
        }
    }
}

