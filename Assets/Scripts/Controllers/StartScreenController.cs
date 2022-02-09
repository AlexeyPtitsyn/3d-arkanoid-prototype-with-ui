// Main menu screen controller.
// Copyright Alexey Ptitsyn <alexey.ptitsyn@gmail.com>, 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class StartScreenController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameManager;

        [SerializeField]
        private GameObject _btnNewGame;

        [SerializeField]
        private GameObject _btnExitGame;

        [SerializeField]
        private GameObject _textArkanoid;

        [SerializeField]
        private GameObject _text3d;

        [SerializeField]
        private GameObject _textVersion;

        private float _textMoveSpeed = 10f;

        private float _textArkanoidFrom = 400f;
        private float _textArkanoidTo = 500f;
        private bool _textArkanoidMoveRight = true;

        private float _text3dFrom = 740f;
        private float _text3dTo = 880f;
        private bool _text3dMoveRight = false;

        private void Awake()
        {
            _textVersion.GetComponent<Text>().text = $"Version: <color=\"#fff\">{Constants.Version}</color>";

            StartCoroutine(TextArkanoidMove());
            StartCoroutine(Text3dMove());

            _btnNewGame.GetComponent<Button>().onClick.AddListener(() => { OnNewGame(); });
            _btnExitGame.GetComponent<Button>().onClick.AddListener(() => { OnExitGame(); });
        }

        private void DoMoveText(GameObject obj, ref float from, ref float to, ref bool isMoveRight)
        {
            if (isMoveRight)
            {
                var comp = obj.GetComponent<RectTransform>();
                comp.position += new Vector3(1, 0, 0) * Time.deltaTime * _textMoveSpeed;

                if (comp.position.x >= to)
                {
                    isMoveRight = false;
                }
            }
            else
            {
                var comp = obj.GetComponent<RectTransform>();
                comp.position += new Vector3(-1, 0, 0) * Time.deltaTime * _textMoveSpeed;

                if (comp.position.x <= from)
                {
                    isMoveRight = true;
                }
            }
        }

        IEnumerator TextArkanoidMove()
        {
            while(true)
            {
                DoMoveText(_textArkanoid, ref _textArkanoidFrom, ref _textArkanoidTo, ref _textArkanoidMoveRight);

                yield return null;
            }
        }

        IEnumerator Text3dMove()
        {
            while(true)
            {
                DoMoveText(_text3d, ref _text3dFrom, ref _text3dTo, ref _text3dMoveRight);

                yield return null;
            }
        }

        private void OnExitGame()
        {
            if(Application.isEditor)
            {
                UnityEditor.EditorApplication.isPlaying = false;
                return;
            }

            Application.Quit();
        }

        private void OnNewGame()
        {
            _gameManager.GetComponent<GameManager>().Run();

            Destroy(this.gameObject);
        }
    }

}
