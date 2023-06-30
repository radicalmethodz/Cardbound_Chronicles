// Description: This script is used to manage the atmosphere of the menu scene.
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CardboundChronicles.menu
{
    [ExecuteInEditMode]
    [System.Serializable]
    public class MenuAtmosphereManager : MonoBehaviour
    {
        [Header("Color Scheme Settings")]
        [Tooltip("The color scheme to apply")]
        public ColorSchemeData.Profile colorScheme;
        private int colorSchemeIndex;
        public ColorSchemeData colorSchemeController;

        [Header("Audio Effects")]
        [Tooltip("The AudioSource for the Flutter sound effect")]
        public AudioSource flutterSound;
        [Tooltip("The AudioSource for the Coil sound effect")]
        public AudioSource coilSound;
        [Tooltip("The AudioSource for the Slider sound effect")]
        public AudioSource sliderSound;
        [Tooltip("The AudioSource for the Wind sound effect")]
        public AudioSource windSound;
        [Tooltip("The AudioSource for the Whisper sound effect")]
        public AudioSource whisperSound;

        [Header("Atmospheric Settings")]
        [Tooltip("Toggle to enable/disable fog")]
        public bool enableFog = false;
        [Tooltip("The color of the fog")]
        public Color fogColor = Color.white;
        [Range(0f, 1f)]
        [Tooltip("The density of the fog")]
        public float fogDensity = 0.1f;
        [Tooltip("The mode of the fog")]
        public FogMode fogMode = FogMode.ExponentialSquared;
        [Tooltip("Toggle to enable/disable ambient light")]
        public bool enableAmbientLight = false;
        [Tooltip("The color of the ambient equator light")]
        public Color ambientEquatorColor = Color.white;
        [Tooltip("The mode of the ambient light")]
        public Rendering.AmbientMode ambientMode = Rendering.AmbientMode.Flat;
        [Tooltip("The color of the ambient ground light")]
        public Color ambientGroundColor = Color.white;
        [Range(0f, 8f)]
        [Tooltip("The intensity of the ambient light")]
        public float ambientIntensity = 1f;
        [Tooltip("The color of the ambient light")]
        public Color ambientLight = Color.white;

        // Update the atmosphere settings whenever a serialized field is changed in the editor
        private void OnValidate()
        {
            UpdateAtmosphereUI();
        }

        private void Awake()
        {
            UpdateAtmosphereUI();
        }

        private void Update()
        {
            UpdateAtmosphereUI();
        }

        private void SetColorSchemeColors()
        {
            ColorSchemeData.ColorProfile profile;

            // Map the selected color scheme to the respective profile
            switch (colorScheme)
            {
                case ColorSchemeData.Profile.Profile1:
                    profile = colorSchemeController.GetProfileByName(colorSchemeController.profile1Name);
                    break;
                case ColorSchemeData.Profile.Profile2:
                    profile = colorSchemeController.GetProfileByName(colorSchemeController.profile2Name);
                    break;
                case ColorSchemeData.Profile.Profile3:
                    profile = colorSchemeController.GetProfileByName(colorSchemeController.profile3Name);
                    break;
                case ColorSchemeData.Profile.Profile4:
                    profile = colorSchemeController.GetProfileByName(colorSchemeController.profile4Name);
                    break;
                case ColorSchemeData.Profile.Profile5:
                    profile = colorSchemeController.GetProfileByName(colorSchemeController.profile5Name);
                    break;
                default:
                    Debug.Log("Invalid color scheme selected.");
                    return;
            }

            colorSchemeController.currentColor = profile.interfaceColor;
            colorSchemeController.textColor = profile.textColor;
        }

        public void PlayFlutter()
        {
            if (flutterSound != null)
            {
                flutterSound.Play();
            }
            else
            {
                Debug.LogWarning("Flutter sound AudioSource not found!");
            }
        }

        public void PlayCoil()
        {
            if (coilSound != null)
            {
                coilSound.Play();
            }
            else
            {
                Debug.LogWarning("Coil sound AudioSource not found!");
            }
        }

        public void PlaySlider()
        {
            if (sliderSound != null)
            {
                sliderSound.Play();
            }
            else
            {
                Debug.LogWarning("Slider sound AudioSource not found!");
            }
        }

        public void PlayWind()
        {
            if (windSound != null)
            {
                windSound.Play();
            }
            else
            {
                Debug.LogWarning("Wind sound AudioSource not found!");
            }
        }

        public void PlayWhisper()
        {
            if (whisperSound != null)
            {
                whisperSound.Play();
            }
            else
            {
                Debug.LogWarning("Whisper sound AudioSource not found!");
            }
        }

        public void UpdateMusicVolume()
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");
            }
            else
            {
                Debug.LogWarning("AudioSource component not found!");
            }
        }

        public void UpdateSFXVolume()
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = PlayerPrefs.GetFloat("AudioEffectVolume");
            }
            else
            {
                Debug.LogWarning("AudioSource component not found!");
            }
        }

        public void UpdateAtmosphericSettings()
        {
            UpdateFogSettings();
            UpdateAmbientLightSettings();
        }

        private void UpdateFogSettings()
        {
            RenderSettings.fog = enableFog;
            RenderSettings.fogColor = fogColor;
            RenderSettings.fogDensity = fogDensity;
            RenderSettings.fogMode = fogMode;
        }

        private void UpdateAmbientLightSettings()
        {
            RenderSettings.ambientEquatorColor = ambientEquatorColor;
            RenderSettings.ambientMode = ambientMode;
            RenderSettings.ambientGroundColor = ambientGroundColor;
            RenderSettings.ambientIntensity = ambientIntensity;
            RenderSettings.ambientLight = ambientLight;
        }
    }
}
