using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public LevelManager LevelManager { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LevelManager = GetComponentInChildren<LevelManager>();
            if (LevelManager == null)
            {
                Debug.LogError("GameManager: LevelManager not found!");
            }
            else
            {
                Debug.Log("GameManager: LevelManager found!");
            }
        }
        else
        {
            Debug.LogWarning("GameManager: Instance already exists");
            Destroy(gameObject);
        }

        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            DontDestroyOnLoad(mainCamera.gameObject);
        }
        else
        {
            Debug.LogError("Main Camera not found.");
        }
    }
}
