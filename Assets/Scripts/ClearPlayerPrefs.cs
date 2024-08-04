using UnityEngine;

public class ClearPlayerPrefs : MonoBehaviour
{
    private static ClearPlayerPrefs instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            ClearAllPlayerPrefs();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void ClearAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
