//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;


//namespace GJ.Selection
//{
//    public class SelectionLoad : MonoBehaviour
//    {
//        public SelectionData dataSelection;

//        [Header("UI")]
//        public Button choiceButton1;
//        public Button choiceButton2;

//        public Selection tempSelection;
//        public Selection choice1Selection;
//        public Selection choice2Selection;

//        private void Awake()
//        {
//            choiceButton1.onClick.AddListener(Choice1);
//            choiceButton1.onClick.AddListener(Choice2);
//        }
//        void Choice1()
//        {
//            //next selection;
//            tempSelection = choice1Selection;
//            if (tempSelection.selection.Length == 0)
//            {
//                return;
//            }
//            RandomLoadSelection();
//        }
//        void Choice2()
//        {
//            //next selection;
//            tempSelection = choice2Selection;
//            if (tempSelection.selection.Length == 0)
//            {
//                return;
//            }
//            RandomLoadSelection();
//        }
//        private void Start()
//        {
//            FirstRandomLoadSelection();
//        }
//        void FirstRandomLoadSelection()
//        {
//            int id1 = Random.Range(0, dataSelection.selection.Length);
//            int id2 = Random.Range(0, dataSelection.selection.Length);
//            while (id1 == id2)
//            {
//                id2 = Random.Range(0, dataSelection.selection.Length);
//            }
//            choice1Selection = dataSelection.selection[id1];
//            choice2Selection = dataSelection.selection[id2];
//            LoadUI();
//        }
//        void RandomLoadSelection()
//        {
//            int id1 = Random.Range(0, tempSelection.selection.Length);
//            int id2 = Random.Range(0, tempSelection.selection.Length);
//            //while (id1 == id2)
//            //{
//            //    id2 = Random.Range(0, tempSelection.selection.Length);
//            //}
//            for(int i = 0; i < 10; i++)
//            {
//                id2 = Random.Range(0, tempSelection.selection.Length);
//                if (id2 != id1)
//                    break;
//            }
//            choice1Selection = tempSelection.selection[id1];
//            choice2Selection = tempSelection.selection[id2];
//            LoadUI();
//        }
//        void LoadUI()
//        {
//            choiceButton1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choice1Selection.buttonText;
//            choiceButton2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choice2Selection.buttonText;
//        }
//    }
//}

