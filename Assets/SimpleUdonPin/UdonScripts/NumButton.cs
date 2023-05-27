using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace MeronmksTools.SimpleUdonPin
{
    public class NumButton : UdonSharpBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private string num;
    
        public void Click()
        {
            inputField.text += num;
        }
    }
}
