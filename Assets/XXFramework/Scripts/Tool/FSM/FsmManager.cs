using System;
using System.Collections;
using System.Collections.Generic;


public class IFsmNode 
{
	public string Name;
	public void  OnEnter() 
	{
	
	}
	public void OnUpdate()
	{

	}
	public void OnExit()
	{

	}

}

/// <summary>
/// ����״̬��
/// </summary>
public static class FsmManager
{
	// ���е�״̬�ڵ�
	private static readonly List<IFsmNode> _nodes = new List<IFsmNode>();
	// ��ǰ����״̬�ڵ�
	private static IFsmNode _curNode;
	// ��һ�����е�״̬�ڵ�
	private static IFsmNode _preNode;

	/// <summary>
	/// ��ǰ���еĽڵ�����
	/// </summary>
	public static string CurrentNodeName
	{
		get { return _curNode != null ? _curNode.Name : string.Empty; }
	}

	/// <summary>
	/// ֮ǰ���еĽڵ�����
	/// </summary>
	public static string PreviousNodeName
	{
		get { return _preNode != null ? _preNode.Name : string.Empty; }
	}


	/// <summary>
	/// ����״̬��
	/// </summary>
	/// <param name="entryNode">��ڽڵ�</param>
	public static void Run(string entryNode)
	{
		_curNode = GetNode(entryNode);
		_preNode = GetNode(entryNode);

		if (_curNode != null)
			_curNode.OnEnter();
		else
			UnityEngine.Debug.LogError($"Not found entry node : {entryNode}");
	}

	/// <summary>
	/// ����״̬��
	/// </summary>
	public static void Update()
	{
		if (_curNode != null)
			_curNode.OnUpdate();
	}

	/// <summary>
	/// ����һ���ڵ�
	/// </summary>
	public static void AddNode(IFsmNode node)
	{
		if (node == null)
			throw new ArgumentNullException();

		if (_nodes.Contains(node) == false)
		{
			_nodes.Add(node);
		}
		else
		{
			UnityEngine.Debug.LogWarning($"Node {node.Name} already existed");
		}
	}

	/// <summary>
	/// ת���ڵ�
	/// </summary>
	public static void Transition(string nodeName)
	{
		if (string.IsNullOrEmpty(nodeName))
			throw new ArgumentNullException();

		IFsmNode node = GetNode(nodeName);
		if (node == null)
		{
			UnityEngine.Debug.LogError($"Can not found node {nodeName}");
			return;
		}

		UnityEngine.Debug.Log($"FSM change {_curNode.Name} to {node.Name}");
		_preNode = _curNode;
		_curNode.OnExit();
		_curNode = node;
		_curNode.OnEnter();
	}

	/// <summary>
	/// ���ص�֮ǰ�Ľڵ�
	/// </summary>
	public static void RevertToPreviousNode()
	{
		Transition(PreviousNodeName);
	}

	private static bool IsContains(string nodeName)
	{
		for (int i = 0; i < _nodes.Count; i++)
		{
			if (_nodes[i].Name == nodeName)
				return true;
		}
		return false;
	}

	private static IFsmNode GetNode(string nodeName)
	{
		for (int i = 0; i < _nodes.Count; i++)
		{
			if (_nodes[i].Name == nodeName)
				return _nodes[i];
		}
		return null;
	}
}
