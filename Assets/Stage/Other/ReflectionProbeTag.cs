﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;
#endif

 
public class ReflectionProbeTag : MonoBehaviour
{
    public uint TAG;
}


#if UNITY_EDITOR
public class ReflectionProbeTagManager
{
    [InitializeOnLoadMethod]
    static void init() { EditorApplication.update += UPDATE; }
    static uint sd;
    static void UPDATE()
    { 
        sd = 0;
        foreach (GameObject o in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            // シーン上に存在するオブジェクトならば処理.
            if (o.activeInHierarchy)
            {
                var co = o.GetComponent<ReflectionProbe>();

                if (co != null)
                {
                    if(o.GetComponent<ReflectionProbeTag>()==null)
                        o.AddComponent<ReflectionProbeTag>();
                    co.mode = UnityEngine.Rendering.ReflectionProbeMode.Baked;

                    o.GetComponent<ReflectionProbeTag>().TAG = sd;
                    sd += 1;
                }   
            }
        } 
    }
}

#endif

