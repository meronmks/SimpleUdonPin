using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace MeronmksTools.SimpleUdonPin
{
    public class ClButton : UdonSharpBehaviour
    {
        [SerializeField] private InputField inputField;

        public void Click()
        {
            inputField.text = "";
        }
    }
}
