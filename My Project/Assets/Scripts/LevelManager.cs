using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (animator == null)
        {
            animator = GameObject.Find("SceneTransition").GetComponent<Animator>();
        }

        animator.gameObject.SetActive(false);
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        Debug.Log($"LevelManager: Start to make scene {sceneName}");

        animator.gameObject.SetActive(true);
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            yield return null;
        }

        Debug.Log($"LevelManager: Scene {sceneName} finished load");
        Player.Instance.transform.position = Vector3.zero;
        animator.ResetTrigger("Start");
        animator.SetTrigger("Ended");
        
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
}
