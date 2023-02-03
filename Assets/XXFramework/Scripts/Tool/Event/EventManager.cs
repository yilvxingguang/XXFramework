﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PostWrapper
{
	// 分发帧
	public int PostFrame;
	// 消息ID，一个 hashCode
	public int EventID;
	// 消息内容，IEventMessage 是消息抽象接口
	public IEventMessage Message;
	// 释放消息，等待垃圾回收
	public void OnRelease()
	{
		PostFrame = 0;
		EventID = 0;
		Message = null;
	}
}

public class EventManager 
{
	private static readonly Dictionary<int, List<Action<IEventMessage>>> _listeners = new Dictionary<int, List<Action<IEventMessage>>>(1000);
	private static readonly List<PostWrapper> _postWrappers = new List<PostWrapper>(1000);
	/// <summary>
	/// 添加监听
	/// </summary>
	public static void AddListener<TEvent>(System.Action<IEventMessage> listener) where TEvent : IEventMessage
	{
		AddListener(typeof(TEvent), listener);
	}

	/// <summary>
	/// 添加监听
	/// </summary>
	public static void AddListener(System.Type eventType, System.Action<IEventMessage> listener)
	{
		int eventId = eventType.GetHashCode();
		AddListener(eventId, listener);
	}

	/// <summary>
	/// 添加监听
	/// </summary>
	public static void AddListener(int eventId, System.Action<IEventMessage> listener)
	{
		if (_listeners.ContainsKey(eventId) == false)
			_listeners.Add(eventId, new List<Action<IEventMessage>>());
		if (_listeners[eventId].Contains(listener) == false)
			_listeners[eventId].Add(listener);
	}

	/// <summary>
	/// 移除监听
	/// </summary>
	public static void RemoveListener(Type eventType, Action<IEventMessage> listener)
	{
		int eventId = eventType.GetHashCode();
		RemoveListener(eventId, listener);
	}

	/// <summary>
	/// 移除监听
	/// </summary>
	public static void RemoveListener(int eventId, Action<IEventMessage> listener)
	{
		if (_listeners.ContainsKey(eventId))
		{
			if (_listeners[eventId].Contains(listener))
				_listeners[eventId].Remove(listener);
		}
	}
	/// <summary>
	/// 实时广播事件
	/// </summary>
	public static void SendMessage(IEventMessage message)
	{
		int eventId = message.GetType().GetHashCode();
		SendMessage(eventId, message);
	}

	/// <summary>
	/// 实时广播事件
	/// </summary>
	public static void SendMessage(int eventId, IEventMessage message)
	{
		if (_listeners.ContainsKey(eventId) == false)
			return;

		List<Action<IEventMessage>> listeners = _listeners[eventId];
		for (int i = listeners.Count - 1; i >= 0; i--)
		{
			listeners[i].Invoke(message);
		}
	}
	/// <summary>
	/// 延迟广播事件
	/// </summary>
	public static void PostMessage(IEventMessage message)
	{
		int eventId = message.GetType().GetHashCode();
		PostMessage(eventId, message);
	}

	/// <summary>
	/// 延迟广播事件
	/// </summary>
	public static void PostMessage(int eventId, IEventMessage message)
	{
		var wrapper = new PostWrapper();
		wrapper.PostFrame = UnityEngine.Time.frameCount;
		wrapper.EventID = eventId;
		wrapper.Message = message;
		_postWrappers.Add(wrapper);
	}
	/// <summary>
	/// 每帧遍历延迟数组，如果数组中有消息且当前帧大于分发帧则立即分发
	/// </summary>
	public static void Update()
	{
		for (int i = _postWrappers.Count - 1; i >= 0; i--)
		{
			var wrapper = _postWrappers[i];
			if (UnityEngine.Time.frameCount > wrapper.PostFrame)
			{
				SendMessage(wrapper.EventID, wrapper.Message);
				_postWrappers.RemoveAt(i);
			}
		}
	}
	/// <summary>
	/// 清空所有监听
	/// </summary>
	public static void ClearListeners()
	{
		foreach (int eventId in _listeners.Keys)
		{
			_listeners[eventId].Clear();
		}
		_listeners.Clear();
	}

}
