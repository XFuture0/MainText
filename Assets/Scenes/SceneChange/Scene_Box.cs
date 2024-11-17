using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Box : MonoBehaviour
{
    public SceneSO CurrentScene;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO UnLoadEvent;
    private void OnEnable()
    {
        UnLoadEvent.OnEventRaised += OnUnLoad;
    }

    private void OnUnLoad()
    {
        SceneManager.UnloadSceneAsync(CurrentScene.SceneName);
    }
    private void OnDisable()
    {
        UnLoadEvent.OnEventRaised -= OnUnLoad;
    }
}
