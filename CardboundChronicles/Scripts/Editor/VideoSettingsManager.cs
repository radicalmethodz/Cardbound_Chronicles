using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace CardboundChronicles

public class VideoSettingsManager : MonoBehaviour
{
	public GameObject resolutionDropdown;
	public GameObject fullscreenToggle;

	public void Start()
	{
		// Load video settings from PlayerPrefs
		resolutionDropdown.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("Resolution");
		fullscreenToggle.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt("Fullscreen") == 1;
	}

	public void SetResolution(int resolutionIndex)
	{
		PlayerPrefs.SetInt("Resolution", resolutionIndex);
		// Update your video system with the new resolution
	}

	public void SetFullscreen(bool isFullscreen)
	{
		PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
		// Update your video system with the new fullscreen setting
	}
}