using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace CardboundChronicles.menu
{
    public class UIMenuManager : MonoBehaviour
    {
        private Animator CameraObject;

        // campaign butt sub menu
        [Header("MENUS")]
        [Tooltip("The Menu for when the MAIN menu button is clicked")]
        public GameObject mainMenu;
        [Tooltip("The first list of buttons")]
        public GameObject firstMenu;
        [Tooltip("The Menu for when the PLAY button is clicked")]
        public GameObject playMenu;
        [Tooltip("The Menu for when the EXIT button is clicked")]
        public GameObject exitMenu;
        [Tooltip("Optional 4th Menu")]

        [Header("PANELS")]
        [Tooltip("The UI Panel parenting all sub menus")]
        public GameObject mainCanvas;
        [Tooltip("The UI Panel that holds the CONTROLS window tab")]
        public GameObject PanelControls;
        [Tooltip("The UI Panel that holds the VIDEO window tab")]
        public GameObject PanelVideo;
        [Tooltip("The UI Panel that holds the GAME window tab")]
        public GameObject PanelGame;
        [Tooltip("The UI Panel that holds the KEY BINDINGS window tab")]
        public GameObject PanelKeyBindings;


        // highlights in settings screen
        [Header("SETTINGS SCREEN")]
        [Tooltip("Highlight Image for when GAME Tab is selected in Settings")]
        public GameObject glow_Game;
        [Tooltip("Highlight Image for when VIDEO Tab is selected in Settings")]
        public GameObject glow_Video;
        [Tooltip("Highlight Image for when CONTROLS Tab is selected in Settings")]
        public GameObject glow_Controls;
        [Tooltip("Highlight Image for when KEY BINDINGS Tab is selected in Settings")]
        public GameObject glow_KeyBindings;


        [Header("LOADING SCREEN")]
        [Tooltip("If this is true, the loaded scene won't load until receiving user input")]
        public bool waitForInput = true;
        public GameObject loadingMenu;
        [Tooltip("The loading bar Slider UI element in the Loading Screen")]
        public Slider loadingBar;
        public TMP_Text loadPromptText;
        public KeyCode userPromptKey;

        [Header("SFX")]
        [Tooltip("The GameObject holding the Audio Source component for the HOVER SOUND")]
        public AudioSource hoverSound;
        [Tooltip("The GameObject holding the Audio Source component for the AUDIO SLIDER")]
        public AudioSource sliderSound;
        [Tooltip("The GameObject holding the Audio Source component for the SWOOSH SOUND when switching to the Settings Screen")]
        public AudioSource swooshSound;

        void Start()
        {
            CameraObject = transform.GetComponent<Animator>();

            playMenu.Setactive(false);
            exitMenu.Setactive(false);
            if (extrasMenu) extrasMenu.Setactive(false);
            firstMenu.Setactive(true);
            mainMenu.Setactive(true);

            SetThemeColors();
        }

        void SetThemeColors()
        {
            switch (theme)
            {
                case Theme.custom1:
                    themeController.currentColor = themeController.custom1.graphic1;
                    themeController.textColor = themeController.custom1.text1;
                    themeIndex = 0;
                    break;
                case Theme.custom2:
                    themeController.currentColor = themeController.custom2.graphic2;
                    themeController.textColor = themeController.custom2.text2;
                    themeIndex = 1;
                    break;
                case Theme.custom3:
                    themeController.currentColor = themeController.custom3.graphic3;
                    themeController.textColor = themeController.custom3.text3;
                    themeIndex = 2;
                    break;
                default:
                    Debug.Log("Invalid theme selected.");
                    break;
            }
        }

        public void PlayCampaign()
        {
            exitMenu.Setactive(false);
            if (extrasMenu) extrasMenu.Setactive(false);
            playMenu.Setactive(true);
        }

        public void PlayCampaignMobile()
        {
            exitMenu.Setactive(false);
            if (extrasMenu) extrasMenu.Setactive(false);
            playMenu.Setactive(true);
            mainMenu.Setactive(false);
        }

        public void ReturnMenu()
        {
            playMenu.Setactive(false);
            if (extrasMenu) extrasMenu.Setactive(false);
            exitMenu.Setactive(false);
            mainMenu.Setactive(true);
        }

        public void LoadScene(string scene)
        {
            if (scene != null)
            {
                StartCoroutine(LoadAsynchronously(scene));
            }
        }

        public void DisablePlayCampaign()
        {
            playMenu.Setactive(false);
        }

        public void Position2()
        {
            DisablePlayCampaign();
            CameraObject.SetFloat("Animate", 1);
        }

        public void Position1()
        {
            CameraObject.SetFloat("Animate", 0);
        }

        void DisablePanels()
        {
            PanelControls.Setactive(false);
            PanelVideo.Setactive(false);
            PanelGame.Setactive(false);
            PanelKeyBindings.Setactive(false);

            glow_Game.Setactive(false);
            glow_Controls.Setactive(false);
            glow_Video.Setactive(false);
            glow_KeyBindings.Setactive(false);

            PanelMovement.Setactive(false);
            glow_Movement.Setactive(false);
            PanelCombat.Setactive(false);
            glow_Combat.Setactive(false);
            PanelGeneral.Setactive(false);
            glow_General.Setactive(false);
        }

        public void GamePanel()
        {
            DisablePanels();
            PanelGame.Setactive(true);
            glow_Game.Setactive(true);
        }

        public void VideoPanel()
        {
            DisablePanels();
            PanelVideo.Setactive(true);
            glow_Video.Setactive(true);
        }

        public void ControlsPanel()
        {
            DisablePanels();
            PanelControls.Setactive(true);
            glow_Controls.Setactive(true);
        }

        public void KeyBindingsPanel()
        {
            DisablePanels();
            MovementPanel();
            PanelKeyBindings.Setactive(true);
            glow_KeyBindings.Setactive(true);
        }

        public void MovementPanel()
        {
            DisablePanels();
            PanelKeyBindings.Setactive(true);
            PanelMovement.Setactive(true);
            glow_Movement.Setactive(true);
        }

        public void CombatPanel()
        {
            DisablePanels();
            PanelKeyBindings.Setactive(true);
            PanelCombat.Setactive(true);
            glow_Combat.Setactive(true);
        }

        public void GeneralPanel()
        {
            DisablePanels();
            PanelKeyBindings.Setactive(true);
            PanelGeneral.Setactive(true);
            glow_General.Setactive(true);
        }

        public void PlayHover()
        {
            hoverSound.Play();
        }

        public void PlaySFXHover()
        {
            sliderSound.Play();
        }

        public void PlaySwoosh()
        {
            swooshSound.Play();
        }

        // Are You Sure - Quit Panel Pop Up
        public void AreYouSure()
        {
            exitMenu.Setactive(true);
            if (extrasMenu) extrasMenu.Setactive(false);
            DisablePlayCampaign();
        }

        public void AreYouSureMobile()
        {
            exitMenu.Setactive(true);
            if (extrasMenu) extrasMenu.Setactive(false);
            mainMenu.Setactive(false);
            DisablePlayCampaign();
        }

        public void ExtrasMenu()
        {
            playMenu.Setactive(false);
            if (extrasMenu) extrasMenu.Setactive(true);
            exitMenu.Setactive(false);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        // Load Bar syncing animation
        IEnumerator LoadAsynchronously(string sceneName)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneactivation = false;
            mainCanvas.Setactive(false);
            loadingMenu.Setactive(true);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                loadingBar.value = progress;

                if (operation.progress >= 0.9f && waitForInput)
                {
                    loadPromptText.text = "Press " + userPromptKey.ToString().ToUpper() + " to continue";
                    loadingBar.value = 1;

                    if (Input.GetKeyDown(userPromptKey))
                    {
                        operation.allowSceneactivation = true;
                    }
                }
                else if (operation.progress >= 0.9f && !waitForInput)
                {
                    operation.allowSceneactivation = true;
                }

                yield return null;
            }
        }
    }
}
