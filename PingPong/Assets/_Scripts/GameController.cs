using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{

    public static GameController Instance;

    private void OnEnable()
    {
        Instance = this;
    }

    public bool _inPlay = false;
    public bool _gameOver = false;
    public int _scoreOne;
    public int _scoreTwo;
    [SerializeField]
    private int _scoreToWin;

    public TextMeshProUGUI _scoreOneText;
    public TextMeshProUGUI _scoreTwoText;
    public GameObject _gameOverPanel;
    public TextMeshProUGUI _winnerText;
    private void Start()
    {
       
    }

    private void Update()
    {
        if(_inPlay==false && _gameOver!=true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _inPlay = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        Winner();

    }

    public void Winner()
    {
        if(!_gameOver)
        {
            if (_scoreOne >= _scoreToWin)
            {
                _gameOver = true;
                _winnerText.text = "Player 1 wins";
                _gameOverPanel.SetActive(true);
            }
            if (_scoreTwo >= _scoreToWin)
            {
                _gameOver = true;
                _winnerText.text = "Player 2 wins";
                _gameOverPanel.SetActive(true);
            }
        }
       

    }

    public void PlayButtonCLicked()
    {
        SceneManager.LoadScene(0);
    }

}
