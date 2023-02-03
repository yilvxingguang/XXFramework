using System;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyEvent : Singleton<InputKeyEvent>
{
    private Dictionary<KeyCode, Action> KeyEvent = new Dictionary<KeyCode, Action>();

    public void AddKetEvent(KeyCode key, Action action)
    {
        if (KeyEvent.ContainsKey(key))
        {
            if (KeyEvent.Values.Equals(action)) return;

            KeyEvent[key] += action;
        }
        else
        {
            KeyEvent.Add(key, action);
        }
    }

    public void Update()
    {
        if (KeyEvent.Keys.Count == 0) return;
        foreach (var key in KeyEvent.Keys)
        {
            if (Input.GetKeyDown(key))
            {
                KeyEvent[key].Invoke();
            }
        }
    }
}

