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
        private int _display;

        public GameObject TextObject;

        private Text _textComponent;

        private void Awake()
        {
            _display = GameObject.Find("Player2Camera").GetComponent<Camera>().targetDisplay;
            GetComponent<Canvas>().targetDisplay = _display;

            _textComponent = TextObject.GetComponent<Text>();

            GameObject.Find("GameManager").GetComponent<GameManager>().OnLifeUpdate += (int lives) =>
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