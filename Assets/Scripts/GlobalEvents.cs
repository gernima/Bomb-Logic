using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents : MonoBehaviour
{
    public static UnityEvent activatingItems = new UnityEvent();
    public static UnityEvent buildings = new UnityEvent();
    public static UnityEvent levelFailed = new UnityEvent();
    public static void ActivateItems()
    {
        activatingItems.Invoke();
    }
    public static void ChangeIsStart()
    {
        buildings.Invoke();
    }
    public static void FailLevel()
    {
        levelFailed.Invoke();
    }
}
