using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MouseyScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;


    private Animator _animator;
    private Rigidbody _rigidbody;

    private float _desiredPositionX;
    private bool _isInterpolating;
    private bool _startGame;
    private bool _isPushing;
    private bool _isGrounded;
    private int _health = 3;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleInput();
        MoveChar();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isGrounded)
            {
                JumpChar();
                AudioManager.Instance.PlayJump();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!_isInterpolating)
            {
                if (transform.position.x < 2)
                {
                    ChangePosition(true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!_isInterpolating)
            {
                if (transform.position.x > -2)
                {
                    ChangePosition(false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            AudioManager.Instance.PlayGameMusic();
            _startGame = true;
            _animator.SetBool("IsRunning", true);
            UIManager.Instance.StartGame();
            StartCoroutine(IncreaseSpeed());
        }
    }

    private void MoveChar()
    {
        if (!_startGame)
        {
            return;
        }
        if (!_isPushing)
        {
            _rigidbody.linearVelocity = (transform.forward * moveSpeed) + (Vector3.up * _rigidbody.linearVelocity.y);
        }

        if (_isInterpolating)
        {
            Vector3 desiredPosition = new Vector3(_desiredPositionX, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, 10 * Time.deltaTime);
            if (transform.position == desiredPosition)
            {
                _isInterpolating = false;
            }
        }
    }

    private void JumpChar()
    {
        if (!_startGame) return;
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _animator.SetTrigger("Jump");
    }



    private void ChangePosition(bool isRight)
    {
        if (!_startGame) return;

        if (isRight)
        {
            _desiredPositionX = transform.position.x + 2;
        }
        else
        {
            _desiredPositionX = transform.position.x - 2;
        }
        _isInterpolating = true;
    }

    public void OnHitObstacle()
    {
        AudioManager.Instance.PlayObstacle();
        _health--;

        UIManager.Instance.UpdateHealth(_health);

        if (_health <= 0)
        {
            _rigidbody.linearVelocity = Vector3.zero;
            _animator.SetTrigger("Death");
            _startGame = false;
            StartCoroutine(EndGame());
        }
        else
        {
            StartCoroutine(PushChar());
        }
    }

    private IEnumerator PushChar()
    {
        _isPushing = true;
        _rigidbody.AddForce(transform.forward * -3f, ForceMode.Impulse);
        _animator.SetBool("IsBack", true);

        yield return new WaitForSeconds(1f);

        _animator.SetBool("IsBack", false);
        _isPushing = false;
    }

    private IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(15f);
        if (moveSpeed < 15)
        {
            moveSpeed += 0.25f;
            StartCoroutine(IncreaseSpeed());
        }
    }

    public void RightFootStepSfx()
    {
        AudioManager.Instance.PlayStepRightFootSound();
    }

    public void LeftFootStepSfx()
    {
        AudioManager.Instance.PlayStepLeftFootSound();
    }

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("S_RunnerScene");
    }
    private void OnCollisionStay(Collision collision)
    {
        _isGrounded = true;
    }
    private void OnCollisionExit(Collision other)
    {
        _isGrounded = false;
    }
}
