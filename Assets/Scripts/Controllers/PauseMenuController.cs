using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _continueButton;

        [SerializeField]
        private GameObject _quitButton;

        [SerializeField]
        private GameObject _restartLevelButton;

        public GameManager gameManager;

        private void Awake()
        {
            _restartLevelButton.GetComponent<Button>().onClick.AddListener(() => {
                gameManager.InitLevel();
                gameManager.OnContinueGame();
            });
            _continueButton.GetComponent<Button>().onClick.AddListener(() => { gameManager.OnContinueGame(); });
            _quitButton.GetComponent<Button>().onClick.AddListener(() => { gameManager.OnExitGame();  });
        }
    }
}
