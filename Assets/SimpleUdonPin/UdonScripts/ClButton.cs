
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

public class ClButton : UdonSharpBehaviour
{
    [SerializeField] private InputField inputField;

    public void Click()
    {
        inputField.text = "";
    }
}
