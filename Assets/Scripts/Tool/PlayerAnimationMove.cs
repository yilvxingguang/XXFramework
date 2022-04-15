using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAnimationMove : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveToTarget(GameObject position)
    {
        //player.DOLookAt(position.transform.GetChild(0).position,1);
        player.DOMove(position.transform.position, 2f).OnComplete(delegate { player.DOLookAt(position.transform.GetChild(0).position, 1); });

    }
}
