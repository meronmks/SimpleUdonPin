using UdonSharp;
using UnityEngine;

namespace MeronmksTools.SimpleUdonPin
{
    public class EntButton : UdonSharpBehaviour
    {
        [SerializeField] private SimpleUdonPin simpleUdonPin;

        public void Click()
        {
            simpleUdonPin.SendCustomEvent(nameof(simpleUdonPin.CheckPin));
        }
    }
}
