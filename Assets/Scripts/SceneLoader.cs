using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum EScene
    {
        MENU = 0,
        GAME = 1,
        SPECTACLE = 2
    }
    
    public static void LoadScene(EScene scene)
    {
        SceneManager.LoadScene((int)scene);
    }
}