// Description: Handles the options menu
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CardboundChronicles.menu
{
    public class OptionsMenuManager : MonoBehaviour
    {
        public enum Platform { Desktop, Mobile };
        public Platform platform;

        [Header("MOBILE SETTINGS")]
        [Tooltip("Toggle for mobile audio")]
        public GameObject text_mobileaudio;
        [Tooltip("Toggle for mobile music")]
        public GameObject text_mobilemusic;
        [Tooltip("glow_ for mobile shadows")]
        public GameObject glow_mobileshadowsoff;
        [Tooltip("glow_ for mobile shadows")]
        public GameObject glow_mobileShadowlow;
        [Tooltip("glow_ for mobile shadows")]
        public GameObject glow_mobileShadowhigh;

        [Header("VIDEO SETTINGS")]
        [Tooltip("Toggle for fullscreen mode")]
        public GameObject text_fullscreen;
        [Tooltip("Toggle for ambient occlusion")]
        public GameObject text_AmbientOcclusion;
        [Tooltip("glow_ for shadows")]
        public GameObject glow_shadowoff;
        [Tooltip("glow_ for shadows")]
        public GameObject glow_shadowlow;
        [Tooltip("glow_ for shadows")]
        public GameObject glow_shadowhigh;
        [Tooltip("Toggle for VSync")]
        public GameObject text_vsync;
        [Tooltip("Toggle for motion blur")]
        public GameObject text_motionblur;
        [Tooltip("glow_ for texture quality")]
        public GameObject glow_texturelow;
        [Tooltip("glow_ for texture quality")]
        public GameObject glow_texturemed;
        [Tooltip("glow_ for texture quality")]
        public GameObject glow_texturehigh;
        [Tooltip("Toggle for camera effects")]
        public GameObject text_cameraeffects;
        [Tooltip("Apply button")]
        public GameObject text_bellybutton;

        [Header("GAME SETTINGS")]
        [Tooltip("Toggle for subtitles")]
        public GameObject text_subtitles;
        [Tooltip("Dropdown for subtitle language")]
        public TMP_Dropdown text_subtitlelanguage;
        [Tooltip("Toggle for tutorial")]
        public GameObject text_tutorial;
        [Tooltip("glow_ for mute")]
        public GameObject glow_mutemusic;
        [Tooltip("Apply button")]
        public GameObject glow_applybuton;

        [Header("CONTROLS SETTINGS")]
        [Tooltip("Toggle for inverting mouse")]
        public GameObject text_invertmouse;
        [Tooltip("Button for keybindings")]
        public GameObject text_keybindingsbutton;
        [Tooltip("Apply button")]
        public GameObject text_applybutton;

        // Sliders
        public GameObject musicSlider;
        public GameObject audioEffectSlider;
        public GameObject sensitivityXSlider;
        public GameObject sensitivityYSlider;
        public GameObject mouseSmoothSlider;

        private float sliderValueXSensitivity = 0.0f;
        private float sliderValueYSensitivity = 0.0f;
        private float sliderValueSmoothing = 0.0f;

        public void Start()
        {
            // Check slider values
            audioEffectslider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Musicslider");
            musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
            sensitivityXSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("XSensitivity");
            sensitivityYSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("YSensitivity");
            mouseSmoothSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MouseSmoothing");

            // Check full screen
            text_fullscreen.GetComponent<TMP_Text>().text = Screen.fullScreen ? "On" : "Off";

            // Check shadow distance/enabled
            if (platform == Platform.Desktop)
            {
                SetShadowSettings(PlayerPrefs.GetInt("Shadows"), 0, 2, 75);
            }
            else if (platform == Platform.Mobile)
            {
                SetShadowSettings(PlayerPrefs.GetInt("MobileShadows"), 0, 2, 100);
            }

            // Check VSync
            text_vsync.GetComponent<TMP_Text>().text = QualitySettings.vSyncCount == 0 ? "Off" : "On";

            // Check mouse inverse
            text_invertmouse.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("Inverted") == 0 ? "Off" : "On";

            // Check motion blur
            text_motionblur.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("motionblur") == 0 ? "Off" : "On";

            // Check ambient occlusion
            text_AmbientOcclusion.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("AmbientOcclusion") == 0 ? "Off" : "On";

            // Check texture quality
            SetTextureQuality(PlayerPrefs.GetInt("Textures"), 2, 1, 0);
        }

        public void Update()
        {
            sliderValueXSensitivity = sensitivityXSlider.GetComponent<Slider>().value;
            sliderValueYSensitivity = sensitivityYSlider.GetComponent<Slider>().value;
            sliderValueSmoothing = mouseSmoothSlider.GetComponent<Slider>().value;
        }

        public void MusicSlider()
        {
            PlayerPrefs.SetFloat("MusicVolume", musicSlider.GetComponent<Slider>().value);
        }

        public void SensitivityXSlider()
        {
            PlayerPrefs.SetFloat("XSensitivity", sliderValueXSensitivity);
        }

        public void SensitivityYSlider()
        {
            PlayerPrefs.SetFloat("YSensitivity", sliderValueYSensitivity);
        }

        public void SensitivitySmoothing()
        {
            PlayerPrefs.SetFloat("MouseSmoothing", sliderValueSmoothing);
            Debug.Log(PlayerPrefs.GetFloat("MouseSmoothing"));
        }

        public void FullScreen()
        {
            Screen.fullScreen = !Screen.fullScreen;
            text_fullscreen.GetComponent<TMP_Text>().text = Screen.fullScreen ? "On" : "Off";
        }

        public void ShadowsOff()
        {
            SetShadowSettings(0, 0, 0, 0);
        }

        public void ShadowsLow()
        {
            SetShadowSettings(1, 2, 75, 0);
        }

        public void ShadowsHigh()
        {
            SetShadowSettings(2, 4, 500, 0);
        }

        public void MobileShadowsOff()
        {
            SetShadowSettings(0, 0, 0, 0);
        }

        public void MobileShadowsLow()
        {
            SetShadowSettings(1, 2, 75, 0);
        }

        public void MobileShadowsHigh()
        {
            SetShadowSettings(2, 4, 100, 0);
        }

        public void VSync()
        {
            QualitySettings.vSyncCount = QualitySettings.vSyncCount == 0 ? 1 : 0;
            text_vsync.GetComponent<TMP_Text>().text = QualitySettings.vSyncCount == 0 ? "Off" : "On";
        }

        public void InvertMouse()
        {
            PlayerPrefs.SetInt("Inverted", PlayerPrefs.GetInt("Inverted") == 0 ? 1 : 0);
            text_invertmouse.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("Inverted") == 0 ? "Off" : "On";
        }

        public void MotionBlur()
        {
            PlayerPrefs.SetInt("motionblur", PlayerPrefs.GetInt("motionblur") == 0 ? 1 : 0);
            text_motionblur.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("motionblur") == 0 ? "Off" : "On";
        }

        public void AmbientOcclusion()
        {
            PlayerPrefs.SetInt("AmbientOcclusion", PlayerPrefs.GetInt("AmbientOcclusion") == 0 ? 1 : 0);
            text_AmbientOcclusion.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("AmbientOcclusion") == 0 ? "Off" : "On";
        }

        public void TexturesLow()
        {
            SetTextureQuality(0, 2, 1, 0);
        }

        public void TexturesMed()
        {
            SetTextureQuality(1, 1, 0, 0);
        }

        public void TexturesHigh()
        {
            SetTextureQuality(2, 0, 0, 1);
        }

        private void SetShadowSettings(int playerPrefsIndex, int shadowCascades, float shadowDistance, float mobileShadowDistance)
        {
            if (platform == Platform.Desktop)
            {
                PlayerPrefs.SetInt("Shadows", playerPrefsIndex);
                QualitySettings.shadowCascades = shadowCascades;
                QualitySettings.shadowDistance = shadowDistance;
                glow_shadowoff.Setactive(playerPrefsIndex == 0);
                glow_shadowlow.Setactive(playerPrefsIndex == 1);
                glow_shadowhigh.Setactive(playerPrefsIndex == 2);
            }
            else if (platform == Platform.Mobile)
            {
                PlayerPrefs.SetInt("MobileShadows", playerPrefsIndex);
                QualitySettings.shadowCascades = shadowCascades;
                QualitySettings.shadowDistance = mobileShadowDistance;
                glow_shadowoff.Setactive(playerPrefsIndex == 0);
                glow_shadowlow.Setactive(playerPrefsIndex == 1);
                glow_shadowhigh.Setactive(playerPrefsIndex == 2);
            }
        }

        private void SetTextureQuality(int playerPrefsIndex, int limitLow, int limitMed, int limitHigh)
        {
            PlayerPrefs.SetInt("Textures", playerPrefsIndex);
            QualitySettings.masterTextureLimit = playerPrefsIndex == 0 ? limitLow : playerPrefsIndex == 1 ? limitMed : limitHigh;
            glow_texturelow.Setactive(playerPrefsIndex == 0);
            glow_texturemed.Setactive(playerPrefsIndex == 1);
            glow_texturehigh.Setactive(playerPrefsIndex == 2);
        }
    }
}
