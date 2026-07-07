using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Light directionalLight;
    [SerializeField] private Animator canvasAnimator;
    [SerializeField] private GameObject mainMenuObject;

    private bool _isStarted;

    void Update()
    {
        if (_isStarted)
        {
            mainCamera.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
            directionalLight.intensity += 0.005f;
        }
    }

    public void StartGame()
    {
        _isStarted = true;
        canvasAnimator.SetTrigger("StartGame");
        mainMenuObject.SetActive(false);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("S_RunnerScene");
    }
}
