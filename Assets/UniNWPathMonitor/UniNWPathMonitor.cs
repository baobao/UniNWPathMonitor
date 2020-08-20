using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace info.shibuya24.Network
{
    /// <summary>
    /// Network Status Checking component using NWPathMonitor.
    /// (Only iOS12 or higher)
    /// </summary>
    public class UniNWPathMonitor : MonoBehaviour
    {
        public enum NetworkStatus
        {
            /// <summary>
            /// No Connect
            /// </summary>
            unsatisfied = 0,

            /// <summary>
            /// Connect
            /// </summary>
            satisfied = 1,
        }

        public static Action<NetworkStatus> onChangeNetworkStatus;

#if UNITY_EDITOR == false && UNITY_IOS
        [DllImport("__Internal")]
        private static extern void StartMonitor__();
#endif
        /// <summary>
        /// Start monitoring network conditions.
        /// </summary>
        public static void StartMonitor()
        {
#if UNITY_EDITOR == false && UNITY_IOS
            StartMonitor__();
#endif
        }

        /// <summary>
        /// Network Status Change Notification
        /// </summary>
        public void Noti(string value)
        {
            Debug.Log($"Monitor : {value}");
            if (int.TryParse(value, out var status))
            {
                var result = (NetworkStatus) status;
                onChangeNetworkStatus?.Invoke(result);
            }
        }
    }
}