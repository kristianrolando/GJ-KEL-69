using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameJam.Battle
{
    public class CountDownBattle : MonoBehaviour
    {
        [SerializeField] GameObject countDownObj;
        [SerializeField] TextMeshProUGUI countDownText;
        [SerializeField] float countDown;
        [SerializeField] GameObject battleObj;

        float time;
        bool isStartCountDown;

        private void Start()
        {
            battleObj.SetActive(false);
            isStartCountDown = true;
            time = countDown;
            countDownText.text = Mathf.Floor(time).ToString();;
        }
        private void Update()
        {
            if(isStartCountDown)
            {
                CountDown();
            }
        }
        void CountDown()
        {
            time -= Time.deltaTime;
            countDownText.text = Mathf.Floor(time).ToString();
            if(time <= 0)
            {
                isStartCountDown = false;
                battleObj.SetActive(true);
                gameObject.SetActive(false);
                countDownObj.SetActive(false);
            }
        }

    }
}

