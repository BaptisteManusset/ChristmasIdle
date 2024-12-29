using UnityEngine;


public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (!Instantiated) CreateInstance();
            return _instance;
        }
    }

    private static void CreateInstance()
    {
        if (Destroyed) return;
        T[] objects = FindObjectsOfType<T>();
        if (objects.Length <= 0) return;
        if (objects.Length > 1)
        {
            Debug.LogWarning($"Too many instance of the singleton {nameof(T)}");
            for (int i = 1; i < objects.Length; i++) Destroy(objects[i].gameObject);
        }

        _instance = objects[0];
        _instance.gameObject.SetActive(true);
        Instantiated = true;
        Destroyed = false;
    }

    public bool Persistent;
    public static bool Instantiated { get; private set; }
    public static bool Destroyed { get; private set; }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            if (Persistent)
            {
                CreateInstance();
                DontDestroyOnLoad(gameObject);
            }

            return;
        }

        if (Persistent) DontDestroyOnLoad(gameObject);
        if (GetInstanceID() != _instance.GetInstanceID()) Destroy(gameObject);
    }

    protected virtual void OnDestroy()
    {
        Destroyed = true;
        Instantiated = false;
    }
}