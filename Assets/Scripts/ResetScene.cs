using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class RestartGame : MonoBehaviour
{
    private ObjectSpawner spawner;
    public bool allClear;
    private void Start()
    {
        spawner = FindObjectOfType<ObjectSpawner>();
    }
    public void ResetScene()
    {
        allClear = true;
        print("ALL CLEAR!");
    }
}