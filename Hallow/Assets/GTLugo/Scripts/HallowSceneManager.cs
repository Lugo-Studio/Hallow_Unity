using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace GTLugo.Scripts {
  public class HallowSceneManager : MonoBehaviour {
    #region Serialized Fields

    [Header("Scenes")] public SceneAsset master;
    public SceneAsset world;
    public SceneAsset main_menu;

    #endregion

    public static HallowSceneManager Instance { get; private set; }

    #region Event Functions

    private void Awake() {
      if (Instance is null) {
        Instance = this;
        DontDestroyOnLoad(gameObject);
      } else {
        Destroy(gameObject);
      }
    }

    private void Start() { SwapToScene(main_menu); }

    #endregion

    private void SwapToScene(SceneAsset scene_asset) {
      LoadBaseScenes();
      SceneManager.LoadSceneAsync(scene_asset.name, LoadSceneMode.Additive);
    }

    private void LoadBaseScenes() { SceneManager.LoadSceneAsync(master.name); }
  }
}