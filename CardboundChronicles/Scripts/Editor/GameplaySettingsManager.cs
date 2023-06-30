using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace CardboundChronicles

using UnityEngine;
using TMPro;

public class GameplaySettingsManager : MonoBehaviour
{
	public GameObject difficultySlider;
	public GameObject tutorialsToggle;

	public void Start()
	{
		// Load gameplay settings from PlayerPrefs
		difficultySlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Difficulty");
		tutorialsToggle.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt("TutorialsEnabled") == 1;
	}

	public void SetDifficulty(float difficulty)
	{
		PlayerPrefs.SetFloat("Difficulty", difficulty);
		// Update your gameplay system with the new difficulty
	}

	public void SetTutorialsEnabled(bool enabled)
	{
		PlayerPrefs.SetInt("TutorialsEnabled", enabled ? 1 : 0);
		// Update your gameplay system with the new tutorials setting
	}
}
