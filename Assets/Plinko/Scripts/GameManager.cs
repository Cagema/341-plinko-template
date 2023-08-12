using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Single;

	[HideInInspector] public Camera MainCamera;
	GameUI _gameUI;

	int _score;

	public GameObject ballGOprefab;

	public bool GameActive;
	public Vector2 RightUpperCorner;

	[Header("Game parameters")]
	[SerializeField] int _ballsCount;
	[SerializeField] float _timeForNewBall;

	float _timer;

	[Header("Sounds")]
	[SerializeField] AudioSource _music;
	[SerializeField] AudioSource _blockTouch;
	[SerializeField] AudioSource _bucketHit;

	public int Score
	{
		get { return _score; }
		set
		{
			_score = value;

			_gameUI.UpdateTexts();
		}
	}

	private void Awake()
	{
		if (Single != null)
		{
			Debug.Log("Error! - single already exist");
			Single = this;
		}
		else
		{
			Single = this;
		}

		_gameUI = FindObjectOfType<GameUI>();
		MainCamera = Camera.main;
		RightUpperCorner = MainCamera.ViewportToWorldPoint(new Vector2(1, 1));
	}

	private void FixedUpdate()
	{
		_timer += Time.deltaTime;
		if (_ballsCount < 30 && _timer > _timeForNewBall)
		{
			_timer = 0;
			_ballsCount++;
			_gameUI.BallCountText.text = _ballsCount.ToString();
		}
	}

	private void EndGame()
	{
		_gameUI.ShowEndgameMenu();
		_music.Stop();
	}

	public void StartGame()
	{
		Invoke(nameof(ActivateGame), 0.1f);
		_gameUI.HideHelpText();
	}
	private void ActivateGame()
	{
		GameActive = true;
	}

    internal void Spawn(Vector2 mousePos)
    {
        if (_ballsCount > 0)
		{
			_ballsCount--;
			Instantiate(ballGOprefab, new Vector3(mousePos.x, RightUpperCorner.y + 1, 0), Quaternion.identity, transform);

            _gameUI.BallCountText.text = _ballsCount.ToString();
        }
    }

	public void BlockTouchSound()
	{
		_blockTouch.Play();
	}

	public void BucketHitSound()
	{
		_bucketHit.Play();
	}
}
