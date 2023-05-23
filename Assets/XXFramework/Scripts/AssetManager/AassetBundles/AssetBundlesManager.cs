using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// AB�������� ȫ��Ψһ ʹ�õ���ģʽ
/// </summary>
public class AssetBundlesManager : UnitySingleton<AssetBundlesManager>
    {
        //AB������---���AB���޷��ظ����ص����� Ҳ���������Ч�ʡ�
        private Dictionary<string, AssetBundle> abCache;

        private AssetBundle mainAB = null; //����

        private AssetBundleManifest mainManifest = null; //�����������ļ�---���Ի�ȡ������

        //����ƽ̨�µĻ���·�� --- ���ú��жϵ�ǰƽ̨�µ�streamingAssets·��
        private string basePath
        {
            get
            {
                //ʹ��StreamingAssets·��ע��AB�����ʱ ��ѡcopy to streamingAssets
#if UNITY_EDITOR || UNITY_STANDALONE
                return Application.dataPath + "/StreamingAssets/";
#elif UNITY_IPHONE
                return Application.dataPath + "/Raw/";
#elif UNITY_ANDROID
                return Application.dataPath + "!/assets/";
#endif
            }
        }
        //����ƽ̨�µ��������� --- ���Լ���������ȡ������Ϣ
        private string mainABName
        {
            get
            {
#if UNITY_EDITOR || UNITY_STANDALONE
                return "StandaloneWindows";
#elif UNITY_IPHONE
                return "IOS";
#elif UNITY_ANDROID
                return "Android";
#endif
            }
        }

        //�̳��˵���ģʽ�ṩ�ĳ�ʼ������
        protected override void Init()
        {
            base.Init();
            //��ʼ���ֵ�
            abCache = new Dictionary<string, AssetBundle>();
        }


        //����AB��
        private AssetBundle LoadABPackage(string abName)
        {
            AssetBundle ab;
            //����ab������һ����������������
            if (mainAB == null)
            {
                //���ݸ���ƽ̨�µĻ���·������������������
                mainAB = AssetBundle.LoadFromFile(basePath + mainABName);
                //��ȡ�����µ�AssetBundleManifest��Դ�ļ�������������Ϣ��
                mainManifest = mainAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
            
            }
            //����manifest��ȡ���������������� �̶�API
            string[] dependencies = mainManifest.GetAllDependencies(abName);
            //ѭ����������������
            for (int i = 0; i < dependencies.Length; i++)
            {
                //������ڻ��������
                if (!abCache.ContainsKey(dependencies[i]))
                {
                    //�������������ƽ��м���
                    ab = AssetBundle.LoadFromFile(basePath + dependencies[i]);
                    //ע����ӽ����� ��ֹ�ظ�����AB��
                    abCache.Add(dependencies[i], ab);
                }
            }
        Debug.Log(dependencies.Length);
        //����Ŀ��� -- ͬ��ע�⻺������
        if (abCache.ContainsKey(abName)) return abCache[abName];
            else
            {
                ab = AssetBundle.LoadFromFile(basePath + abName);
                abCache.Add(abName, ab);
                return ab;
            }


        }


        //==================������Դͬ�����ط�ʽ==================
        //�ṩ���ֵ��÷�ʽ �����������Եĵ��ã�Lua�Է���֧�ֲ��ã�
        #region ͬ�����ص���������

        /// <summary>
        /// ͬ��������Դ---���ͼ��� ��ֱ�� ������ʾת��
        /// </summary>
        /// <param name="abName">ab��������</param>
        /// <param name="resName">��Դ����</param>
        public T LoadResource<T>(string abName, string resName) where T : UnityEngine.Object
    {
            //����Ŀ���
            AssetBundle ab = LoadABPackage(abName);

            //������Դ
            return ab.LoadAsset<T>(resName);
        }


        //��ָ������ ����������²�����ʹ�� ʹ��ʱ����ʾת������
        public UnityEngine.Object LoadResource(string abName, string resName)
        {
            //����Ŀ���
            AssetBundle ab = LoadABPackage(abName);

            //������Դ
            return ab.LoadAsset(resName);
        }


        //���ò����������ͣ��ʺ϶Է��Ͳ�֧�ֵ����Ե��ã�ʹ��ʱ��ǿת����
        public Object LoadResource(string abName, string resName, System.Type type)
        {
            //����Ŀ���
            AssetBundle ab = LoadABPackage(abName);

            //������Դ
            return ab.LoadAsset(resName, type);
        }

        #endregion


        //================������Դ�첽���ط�ʽ======================

        /// <summary>
        /// �ṩ�첽����----ע�� �������AB����ͬ�����أ�ֻ�Ǽ�����Դ���첽
        /// </summary>
        /// <param name="abName">ab������</param>
        /// <param name="resName">��Դ����</param>
        public void LoadResourceAsync(string abName, string resName, System.Action<Object> finishLoadObjectHandler)
        {
            AssetBundle ab = LoadABPackage(abName);
            //����Э�� �ṩ��Դ���سɹ����ί��
            StartCoroutine(LoadRes(ab, resName, finishLoadObjectHandler));
        }


        private IEnumerator LoadRes(AssetBundle ab, string resName, System.Action<Object> finishLoadObjectHandler)
        {
            if (ab == null) yield break;
            //�첽������ԴAPI
            AssetBundleRequest abr = ab.LoadAssetAsync(resName);
            yield return abr;
            //ί�е��ô����߼�
            finishLoadObjectHandler(abr.asset);
        }


        //����Type�첽������Դ
        public void LoadResourceAsync(string abName, string resName, System.Type type, System.Action<Object> finishLoadObjectHandler)
        {
            AssetBundle ab = LoadABPackage(abName);
            StartCoroutine(LoadRes(ab, resName, type, finishLoadObjectHandler));
        }


        private IEnumerator LoadRes(AssetBundle ab, string resName, System.Type type, System.Action<Object> finishLoadObjectHandler)
        {
            if (ab == null) yield break;
            AssetBundleRequest abr = ab.LoadAssetAsync(resName, type);
            yield return abr;
            //ί�е��ô����߼�
            finishLoadObjectHandler(abr.asset);
        }


        //���ͼ���
        public void LoadResourceAsync<T>(string abName, string resName, System.Action<Object> finishLoadObjectHandler) where T : Object
        {
            AssetBundle ab = LoadABPackage(abName);
            StartCoroutine(LoadRes<T>(ab, resName, finishLoadObjectHandler));
        }

        private IEnumerator LoadRes<T>(AssetBundle ab, string resName, System.Action<Object> finishLoadObjectHandler) where T : Object
        {
            if (ab == null) yield break;
            AssetBundleRequest abr = ab.LoadAssetAsync<T>(resName);
            yield return abr;
            //ί�е��ô����߼�
            finishLoadObjectHandler(abr.asset as T);
        }


        //====================AB��������ж�ط�ʽ=================
        //������ж��
        public void UnLoad(string abName)
        {
            if (abCache.ContainsKey(abName))
            {
                abCache[abName].Unload(false);
                //ע�⻺����һ���Ƴ�
                abCache.Remove(abName);
            }
        }

        //���а�ж��
        public void UnLoadAll()
        {
            AssetBundle.UnloadAllAssetBundles(false);
            //ע����ջ���
            abCache.Clear();
            mainAB = null;
            mainManifest = null;
        }
}
