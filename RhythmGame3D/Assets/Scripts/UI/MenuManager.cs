using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace RhythmGame3D.UI
{
    /// <summary>
    /// Manages the main menu navigation and panels
    /// </summary>
    public class MenuManager : MonoBehaviour
    {
        [Header("Panels")]
        public GameObject mainPanel;
        public GameObject beatmapPanel;
        public GameObject settingsPanel;
        
        [Header("Main Menu Buttons")]
        public Button playButton;
        public Button beatmapButton;
        public Button settingsButton;
        public Button quitButton;
        
        [Header("Settings")]
        public string gameplaySceneName = "GameScene";
        
        void Start()
        {
            // Setup button listeners
            if (playButton != null)
                playButton.onClick.AddListener(OnPlayClicked);
            
            if (beatmapButton != null)
                beatmapButton.onClick.AddListener(OnBeatmapClicked);
            
            if (settingsButton != null)
                settingsButton.onClick.AddListener(OnSettingsClicked);
            
            if (quitButton != null)
                quitButton.onClick.AddListener(OnQuitClicked);
            
            // Show main panel by default
            ShowMainPanel();
        }
        
        /// <summary>
        /// Play button - Load gameplay scene
        /// </summary>
        void OnPlayClicked()
        {
            Debug.Log("[MenuManager] Loading gameplay scene...");
            SceneManager.LoadScene(gameplaySceneName);
        }
        
        /// <summary>
        /// Beatmap button - Show beatmap selection panel
        /// </summary>
        void OnBeatmapClicked()
        {
            Debug.Log("[MenuManager] Opening beatmap panel...");
            ShowBeatmapPanel();
        }
        
        /// <summary>
        /// Settings button - Show settings panel
        /// </summary>
        void OnSettingsClicked()
        {
            Debug.Log("[MenuManager] Opening settings panel...");
            ShowSettingsPanel();
        }
        
        /// <summary>
        /// Quit button - Exit game
        /// </summary>
        void OnQuitClicked()
        {
            Debug.Log("[MenuManager] Quitting game...");
            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        
        /// <summary>
        /// Show main menu panel
        /// </summary>
        public void ShowMainPanel()
        {
            if (mainPanel != null) mainPanel.SetActive(true);
            if (beatmapPanel != null) beatmapPanel.SetActive(false);
            if (settingsPanel != null) settingsPanel.SetActive(false);
        }
        
        /// <summary>
        /// Show beatmap selection panel
        /// </summary>
        public void ShowBeatmapPanel()
        {
            if (mainPanel != null) mainPanel.SetActive(false);
            if (beatmapPanel != null) beatmapPanel.SetActive(true);
            if (settingsPanel != null) settingsPanel.SetActive(false);
        }
        
        /// <summary>
        /// Show settings panel
        /// </summary>
        public void ShowSettingsPanel()
        {
            if (mainPanel != null) mainPanel.SetActive(false);
            if (beatmapPanel != null) beatmapPanel.SetActive(false);
            if (settingsPanel != null) settingsPanel.SetActive(true);
        }
    }
}
