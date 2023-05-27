
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

public class NumButton : UdonSharpBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private string num;
    
    public void Click()
    {
        inputField.text += num;
    }
}
