using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class StartScreenController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _btnExitGame;

        [SerializeField]
        private GameObject _btnNewGame;

        [SerializeField]
        private GameObject _textArkanoid;

        [SerializeField]
        private GameObject _text3d;

        [SerializeField]
        private GameObject _textVersion;

        private float _textMoveSpeed = 2f;

        private float _textArkanoidFrom = -120f;
        private float _textArkanoidTo = 0f;
        private bool _textArkanoidMoveRight = true;

        private float _text3dFrom = 0f;
        private float _text3dTo = 360f;
        private bool _text3dMoveRight = false;

        private void Awake()
        {
            _textVersion.GetComponent<Text>().text = $"Version: <color=\"#fff\">{Constants.Version}</color>";



            _btnNewGame.GetComponent<Button>().onClick.AddListener(OnNewGame);
            _btnExitGame.GetComponent<Button>().onClick.AddListener(OnExitGame);
        }

        private void OnExitGame()
        {
            Debug.Log("On exit.");
        }

        private void OnNewGame()
        {
            Debug.Log("On new game.");
        }
    }

}