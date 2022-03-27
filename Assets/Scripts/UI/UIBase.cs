using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace XXFreamWork
{

    /// <summary>
    /// UI基类
    /// </summary>
    public class UIBase : IEventHandler
    {
        public void HandleEvent(EventBase evt)
        {
            throw new System.NotImplementedException();
        }

        public bool HasBubbleUpHandlers()
        {
            throw new System.NotImplementedException();
        }

        public bool HasTrickleDownHandlers()
        {
            throw new System.NotImplementedException();
        }

        public void SendEvent(EventBase e)
        {
            throw new System.NotImplementedException();
        }
    }
}


