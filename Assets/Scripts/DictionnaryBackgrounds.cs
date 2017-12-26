using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "VN Backgrounds", order = 2)]
public class DictionnaryBackgrounds : ScriptableObject
{
    [Serializable]
    public struct Backgrounds
    {
        public string name;
        public Sprite sprite;
    }
    public Backgrounds[] m_Backgrounds;
}
