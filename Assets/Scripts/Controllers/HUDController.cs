// HUD Controller.
// Copyright Alexey Ptitsyn <alexey.ptitsyn@gmail.com>, 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class HUDController : MonoBehaviour
    {
        public GameObject TextObject;

        private Text _textComponent;

        /**
         * <summary>Set active display.</summary>
         * <param name="display">Display to select.</param>
         */
        public void SetDisplay(int display)
        {
            GetComponent<Canvas>().targetDisplay = display;
        }

        /**
         * <summary>Hang events for gamemanager.</summary>
         * <params name="manager">Selected game manager.</params>
         */
        public void HangEvents(GameManager manager)
        {
            _textComponent = TextObject.GetComponent<Text>();

            manager.OnLifeUpdate += (int lives) =>
            {
                if (lives <= 2)
                {
                    _textComponent.text = $"Lives: <color=\"red\">{lives}</color>";
                    return;
                }

                _textComponent.text = $"Lives: {lives}";
            };
        }
    }
}