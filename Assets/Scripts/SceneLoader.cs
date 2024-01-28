using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public struct SceneCallback_t
    {
        public int intData;
        public string stringData;

        public SceneCallback_t(int x)
        {
            intData = x;
            stringData = x.ToString();
        }

        public SceneCallback_t(string x)
        {
            if (!int.TryParse(x, out intData))
            {
                intData = x.GetHashCode();
            }

            stringData = x;
        }
    }

    private static SceneCallback_t data;
    
    public enum EScene
    {
        //MENU = 0,
        GAME = 0,
        SPECTACLE = 1,
        ENDING = 2
    }
    
    public static void LoadScene(EScene scene, SceneCallback_t data)
    {
        SceneLoader.data = data;
        SceneManager.sceneLoaded += callback;
        SceneManager.LoadScene((int)scene);
    }

    private static void callback(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.buildIndex == (int)EScene.ENDING)
        {
            GameObject[] objs = arg0.GetRootGameObjects();
            foreach (GameObject obj in objs)
            {
                if (obj.name == "Canvas")
                {
                    if (data.intData < 0 || data.intData > (int)(EndingManager.Ending_t.MAX) - 1)
                        data.intData = (int)EndingManager.Ending_t.KING_WIN;
                    obj.GetComponent<EndingManager>().showEnding((EndingManager.Ending_t)data.intData);
                }
            }
        }
    }

}