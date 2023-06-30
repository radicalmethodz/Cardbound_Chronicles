// Description: Scriptable object that holds color scheme data for the game.
using UnityEngine;

namespace CardboundChronicles.menu
{
    [CreateAssetMenu(menuName = "ColorSchemeData")]
    [System.Serializable]
    public class ColorSchemeData : ScriptableObject
    {
        public enum Profile
        {
            Profile1,
            Profile2,
            Profile3,
            Profile4,
            Profile5
        }

        [System.Serializable]
        public class ColorProfile
        {
            [Header("Interface Color")]
            public Color interfaceColor;

            [Header("Text Color")]
            public Color32 textColor;
        }

        [Header("Color Schemes")]
        public ColorProfile profile1;
        public string profile1Name = "Profile 1";
        public ColorProfile profile2;
        public string profile2Name = "Profile 2";
        public ColorProfile profile3;
        public string profile3Name = "Profile 3";
        public ColorProfile profile4;
        public string profile4Name = "Profile 4";
        public ColorProfile profile5;
        public string profile5Name = "Profile 5";

        [HideInInspector]
        public Color currentColor;
        [HideInInspector]
        public Color32 textColor;

        public ColorProfile GetProfileByName(string profileName)
        {
            switch (profileName)
            {
                case "Profile 1":
                    return profile1;
                case "Profile 2":
                    return profile2;
                case "Profile 3":
                    return profile3;
                case "Profile 4":
                    return profile4;
                case "Profile 5":
                    return profile5;
                default:
                    Debug.LogError("Invalid profile name: " + profileName);
                    return null;
            }
        }
    }
}
