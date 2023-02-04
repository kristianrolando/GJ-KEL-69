using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GJ.Selection
{
    [CreateAssetMenu(fileName = "Selection Data")]
    public class SelectionData : ScriptableObject
    {
        public Selection[] selection;
    }
    [System.Serializable]
    public class Selection
    {
        
    }
}

