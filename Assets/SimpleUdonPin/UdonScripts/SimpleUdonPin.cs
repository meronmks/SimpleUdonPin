
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;

public class SimpleUdonPin : UdonSharpBehaviour
{
    //要件その1：入力に成功した場合にテレポートする（移動先が指定されている場合）
    //要件その2：入力に成功した場合GameObjectをアクティブにする（指定されている場合）
    //要件その3：入力に成功した場合GameObjectを非アクティブにする（指定されている場合）
    //要件その4：その2とその3は同期ズレを考慮しbool反転は利用しない
    //要件その5：入力失敗時には何もしない

    [SerializeField] private InputField inputField;
    [SerializeField] private string pin;
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private GameObject[] activeObjects;
    [SerializeField] private bool[] activeObjectsSync;
    [SerializeField] private GameObject[] inactiveObjects;
    [SerializeField] private bool[] inactiveObjectsSync;
    [UdonSynced] private bool isPinSuccessed = false;   //同期用
    
    public override void OnDeserialization()
    {
        if (isPinSuccessed)
        {
            if (activeObjects != null)
            {
                for (int i = 0; i < activeObjects.Length; i++)
                {
                    if (activeObjectsSync[i])
                    {
                        activeObjects[i].SetActive(true);
                    }
                }
            }

            if (inactiveObjects != null)
            {
                for (int i = 0; i < inactiveObjects.Length; i++)
                {
                    if (inactiveObjectsSync[i])
                    {
                        inactiveObjects[i].SetActive(false);
                    }
                }
            }
        }
    }

    public void CheckPin()
    {
        if (inputField.text.Equals(pin))
        {
            if (Networking.LocalPlayer.IsOwner(this.gameObject))
            {
                Success();
            }
            else
            {
                SendCustomNetworkEvent(NetworkEventTarget.Owner, nameof(Success));
            }
        }
        inputField.text = "";
    }

    public void Success()
    {
        isPinSuccessed = true;
        if(teleportTarget != null)
        {
            Networking.LocalPlayer.TeleportTo(teleportTarget.position, teleportTarget.rotation);
        }
            
        if (activeObjects != null)
        {
            for (int i = 0; i < activeObjects.Length; i++)
            {
                activeObjects[i].SetActive(true);
            }
        }

        if (inactiveObjects != null)
        {
            for (int i = 0; i < inactiveObjects.Length; i++)
            {
                inactiveObjects[i].SetActive(false);
            }
        }
        RequestSerialization();
    }
}
