using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene {
        MainMenuScene, 
        LevelSelectScene,
        TownScene,
        LoadingScene,
        Level1,
        Level2,
    }
    private static Scene targetScene;

    public static void Load(Scene scene) {
        Loader.targetScene = scene;

        Time.timeScale = 1f;

        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallBack() {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
