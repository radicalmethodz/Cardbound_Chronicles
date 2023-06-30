using UnityEngine;
using System.Collections;

namespace SlimUI.ModernMenu{
	public class CheckMusicVolume : MonoBehaviour {
		public void  Start (){
			// remember volume level from last time
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
		
			// Update the volume immediately
			UpdateVolume();
		}

		public void UpdateVolume (){
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
		}
	}
}