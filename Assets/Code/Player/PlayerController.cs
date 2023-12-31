using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public GameObject JumpTarget;
    public GameObject DirectionShower;

    public float JumpIncreaser;
    public float JumpPower;
    public float JumpTargetMaxHeight;
    public float MaxJumpPower;
    public SpriteRenderer spriteRendPlayer;
    public SpriteRenderer spriteRendDirectionShower;
    
    float currentRedColor = 0;

    private float _jumpDirection;
    private Rigidbody2D _rb;

    private float _offset;
    float _halfScreenWith;
    
    bool _canJump = true;
    string _nameCurrentScene = "";

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();        
        ResetVariables();
        _halfScreenWith = Screen.width / 2;

        _nameCurrentScene = SceneManager.GetActiveScene().name;
    }
    
    // Update is called once per frame
    void Update()
    {
        CheckPosition();
        _jumpDirection = GetJumpDirection();
        Debug.Log($"Direcion: {_jumpDirection}");
        Vector2 transPos = transform.position;

        if (_jumpDirection != 0)
        {
            _offset = 1f * _jumpDirection;
            DirectionShower.transform.position = new Vector2(transPos.x + (0.3f * _offset), transPos.y + 0.65f);
        }

        if (!_canJump) return;
         
        if (_jumpDirection == 0 || JumpPower >= MaxJumpPower)
        {
            if (JumpPower == 0) return;
            else 
            {
                JumpTarget.transform.position = new Vector2(transPos.x + _offset, transPos.y + 1.5f);

                Vector2 jumpVector = JumpTarget.transform.position - transform.position;
                
                Debug.Log($"jmpVec:{jumpVector} pwr:{JumpPower}");
                _rb.AddForce(jumpVector * JumpPower, ForceMode2D.Impulse);
                
                ResetVariables();
            }
        }
        else
        {
            if (JumpPower < MaxJumpPower)
            {
                float incValue = JumpIncreaser * Time.deltaTime;
                JumpPower += incValue;
                
                currentRedColor += incValue / MaxJumpPower;
                Debug.Log($" inc: {incValue} jp:{JumpPower} redCol:{currentRedColor}");
                spriteRendDirectionShower.color = spriteRendPlayer.color = new Color(1, 1-currentRedColor, 1-currentRedColor, 1 );
            }            
        }
        
    }

    float direction = 0;
    private float GetJumpDirection()
    {
        if (Input.touchCount > 0)
        {
            Touch[] touches = Input.touches;
            Touch touch;
            for (int i = 0; i < touches.Length; i++)
            {
                if (touches[i].phase == TouchPhase.Began)
                {
                    touch = touches[i];
                    if (touch.position.x > _halfScreenWith) direction = 1;
                    else direction = -1;
                }
            }
        }
        else
        {
            direction = Input.GetAxis("Horizontal");
            if (direction < -0.3) direction = -1;
            else if (direction > 0.3) direction = 1;
            else direction = 0;
        }
        
        return direction;
    }

    private void ResetVariables()
    {
        JumpPower = 0;
        _jumpDirection = 0;
        DirectionShower.transform.position  = JumpTarget.transform.position = transform.position;
        spriteRendDirectionShower.color = spriteRendPlayer.color = new Color(1, 1, 1, 1);
         
        currentRedColor = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contactCount > 1) _canJump = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.contactCount > 1) _canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.contactCount == 0) _canJump = false;
    }

    void CheckPosition()
    {
        if (transform.position.y < -15) SceneManager.LoadScene(_nameCurrentScene);
    }
}
