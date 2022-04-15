//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
////using UnityEngine.SceneManagement;

//public class HallBtnManager : MonoBehaviour
//{
//    private Button[] HallBtnS;
    

//    void Start()
//    {
//        HallBtnS = new Button[gameObject.transform.childCount];
//        for (int i = 0; i < gameObject.transform.childCount; i++)
//        {
//            HallBtnS[i] = transform.GetChild(i).GetComponent<Button>();
            
//            string _HallBtnSName = HallBtnS[i].name ;
//            HallBtnS[i].onClick.AddListener(delegate ()
//            {
//                MainSceneUIManager.HallBtnSName = _HallBtnSName;
//                // SceneManager.LoadScene(1);             
//                SceneStateController.Instance.SetState(new MainSceneState(), true, "Loading");
//            });
//        }       
//    }

//}
