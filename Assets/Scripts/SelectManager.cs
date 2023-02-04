using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GJ.Selection
{
    public class SelectManager : MonoBehaviour
    {
        [SerializeField] GameObject hintEnemy;
        [SerializeField] GameObject selectionMenu;

        enum PageState
        {
            hintPage,
            questionPage,
            battlePage
        }

        private void Start()
        {
            StatePage(PageState.hintPage);
        }


        void StatePage(PageState state)
        {
            switch(state)
            {
                case PageState.hintPage:
                    hintEnemy.SetActive(true);
                    selectionMenu.SetActive(false);
                    break;
                case PageState.questionPage:
                    hintEnemy.SetActive(false);
                    selectionMenu.SetActive(true);
                    break;
                case PageState.battlePage:
                    break;
            }
        }

    }
}


