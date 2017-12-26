using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "VN Characters", order = 1)]
public class VNDictionnaryCharacters : ScriptableObject
{
    [Serializable]
    public struct Characters
    {
        public string name;
        public Sprite[] sprites;
    }
    public Characters[] m_Characters;
}
