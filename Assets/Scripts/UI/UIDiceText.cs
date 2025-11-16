using TMPro;
using UnityEngine;

namespace K02.UI.Dice
{
    public class UIDiceText : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI label;

        public void Display(int value)
        {
            label.text = $"Dice: {value}";
        }
    }
}