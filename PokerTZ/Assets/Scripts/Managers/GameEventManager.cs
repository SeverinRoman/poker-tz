using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameEventManager
{
    //LevelManager
    public static UnityEvent<string> ChangeLevel = new();
    public static UnityEvent ChangeNextLevel = new();
    public static UnityEvent RestartLevel = new();
    public static UnityEvent<Action<int>> GetNumberLevel = new();
    public static UnityEvent<Action<int>> GetMaxNumberLevel = new();
    public static UnityEvent<Action<string>> GetNameLevel = new();

}
