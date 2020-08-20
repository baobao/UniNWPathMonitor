using System.Collections;
using System.Collections.Generic;
using info.shibuya24.Network;
using UnityEngine;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    [SerializeField] private Text _statusText;

    void Start()
    {
        UniNWPathMonitor.StartMonitor();
        UniNWPathMonitor.onChangeNetworkStatus += status =>
            {
                _statusText.text = status == UniNWPathMonitor.NetworkStatus.satisfied ? "接続中" : "切断中";
            };
    }
}