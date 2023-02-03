using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PostWrapper
{
	// �ַ�֡
	public int PostFrame;
	// ��ϢID��һ�� hashCode
	public int EventID;
	// ��Ϣ���ݣ�IEventMessage ����Ϣ����ӿ�
	public IEventMessage Message;
	// �ͷ���Ϣ���ȴ���������
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
	/// ��Ӽ���
	/// </summary>
	public static void AddListener<TEvent>(System.Action<IEventMessage> listener) where TEvent : IEventMessage
	{
		AddListener(typeof(TEvent), listener);
	}

	/// <summary>
	/// ��Ӽ���
	/// </summary>
	public static void AddListener(System.Type eventType, System.Action<IEventMessage> listener)
	{
		int eventId = eventType.GetHashCode();
		AddListener(eventId, listener);
	}

	/// <summary>
	/// ��Ӽ���
	/// </summary>
	public static void AddListener(int eventId, System.Action<IEventMessage> listener)
	{
		if (_listeners.ContainsKey(eventId) == false)
			_listeners.Add(eventId, new List<Action<IEventMessage>>());
		if (_listeners[eventId].Contains(listener) == false)
			_listeners[eventId].Add(listener);
	}

	/// <summary>
	/// �Ƴ�����
	/// </summary>
	public static void RemoveListener(System.Type eventType, System.Action<IEventMessage> listener)
	{
		int eventId = eventType.GetHashCode();
		RemoveListener(eventId, listener);
	}

	/// <summary>
	/// �Ƴ�����
	/// </summary>
	public static void RemoveListener(int eventId, System.Action<IEventMessage> listener)
	{
		if (_listeners.ContainsKey(eventId))
		{
			if (_listeners[eventId].Contains(listener))
				_listeners[eventId].Remove(listener);
		}
	}
	/// <summary>
	/// ʵʱ�㲥�¼�
	/// </summary>
	public static void SendMessage(IEventMessage message)
	{
		int eventId = message.GetType().GetHashCode();
		SendMessage(eventId, message);
	}

	/// <summary>
	/// ʵʱ�㲥�¼�
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
	/// �ӳٹ㲥�¼�
	/// </summary>
	public static void PostMessage(IEventMessage message)
	{
		int eventId = message.GetType().GetHashCode();
		PostMessage(eventId, message);
	}

	/// <summary>
	/// �ӳٹ㲥�¼�
	/// </summary>
	public static void PostMessage(int eventId, IEventMessage message)
	{
		var wrapper = new PostWrapper();
		wrapper.PostFrame = UnityEngine.Time.frameCount;
		wrapper.EventID = eventId;
		wrapper.Message = message;
		_postWrappers.Add(wrapper);
	}
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
	/// ������м���
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
