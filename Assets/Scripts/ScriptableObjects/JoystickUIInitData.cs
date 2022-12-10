using RefAccess.UI;
using System.Collections;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "JoystickUIInitData", menuName = "ScriptableObject/JoystickUIInitData", order = 0)]
    public class JoystickUIInitData : ScriptableObject
    {

        [SerializeField] private JoystickUIRef joystickUIRef;

        public JoystickUIRef JoystickUIRef => joystickUIRef;
    }
}