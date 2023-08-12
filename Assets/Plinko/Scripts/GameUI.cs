using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class GameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _helpText;
    public TextMeshProUGUI BallCountText;
	[SerializeField] TextMeshProUGUI _scoreText;
	[SerializeField] TextMeshProUGUI _currentScoreEndgameText;
    [SerializeField] TextMeshProUGUI _bestScoreText;


    [SerializeField] GameObject _menuCanvas;
    private void Start()
    {
        UpdateTexts();

    }

    private void Update()
    {
    }

    public void UpdateTexts()
    {
        _scoreText.text = GameManager.Single.Score.ToString();
        _currentScoreEndgameText.text = _scoreText.text;
    }

    public void HideHelpText()
    {
        _helpText.enabled = false;
    }

    public void ShowEndgameMenu()
    {
        GameManager.Single.GameActive = false;
		_menuCanvas.SetActive(true);
    }
}
