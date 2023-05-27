
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

public class EntButton : UdonSharpBehaviour
{
    [SerializeField] private SimpleUdonPin simpleUdonPin;

    public void Click()
    {
        simpleUdonPin.SendCustomEvent(nameof(simpleUdonPin.CheckPin));
    }
}
