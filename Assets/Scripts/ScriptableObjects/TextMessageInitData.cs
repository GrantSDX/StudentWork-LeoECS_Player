using System.Collections;
using UnityEngine;


namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "TextMessageInitData", menuName = "ScriptableObject/TextMessageInitData", order = 0)]

    public class TextMessageInitData : ScriptableObject
    {
        [SerializeField] private GameObject welcome;
        public GameObject Welcome => welcome;

        [SerializeField] private GameObject timeGame;
        public GameObject TimeGame => timeGame;

        

    }
}