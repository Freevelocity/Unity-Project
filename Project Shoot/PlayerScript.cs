using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Vector2 _StartPostion;
    Vector2 _StartPostionLocal;
    public Rigidbody2D _rigidbody2D;
    public Rigidbody2D _hookRb2D;
    LineRenderer _lineRenderer;
    public SpriteRenderer _SpriteRenderer;
    [SerializeField] public float _maxDragDistance = 5f;
    [SerializeField] PauseMenuScript _pauseMenu;
    [SerializeField] BallLives _ballLives;
    [SerializeField] LayerMask groundMask;
    [SerializeField] public TrailRenderer _trailRenderer;
    [SerializeField] CircleCollider2D _cicleCollider2d;
    public Vector2 mousePosition;


    [SerializeField] GameObject backGround;
    [SerializeField] Transform platform;

    float _secondsToWait;
    public float _secondsToReset = 4f;
    public float _ballNormalBounce = 0.4f;
    public float _dashAmount = 0.5f;
    public float _additionalForce = 1.1f;

    private int shootTimeVal = 0;
    private int bounceTimeVal = 0;
    private int dashTimeVal = 0;


    public  bool _levelComplete = false;
    public bool isPressed = false;
    bool canTouch;
    bool killZoneTrigger;
    public bool _isReleased = false;
    public bool touchedWall = false;
    public bool inMotion = false;
    public bool isReset = false;
    public bool isMoving;
    public bool hitBin = false;
    
    public bool isGrounded = false;
    public float groundCheckDistance = 0.1f;
    public bool onMovingPlatform = false;
    Vector2 _ballInitalVelocity;
    Vector2 _ballUpdateVelocity;

    public float groundResetTime = 3f;
    public float groundResetTimeVal;

    public float HARDgroundResetTime = 1f;
    public float HARDgroundResetTimeVal;


    public float completeTime = 2f;
    private float completeTimeVal;


    public int bounceAmount = 0;
    private int bounceAmountVal = 0;

    [SerializeField] GameObject MainParent;

    public int PlatformHits;
    private int PlatformHitsVal;

    public bool isResetInGame = false;

    public int TrajectoryNumber = 65;

    public bool FirstPress = false;

    public GameObject dashEffectStart;
    public GameObject dashEffectEnd;

    public bool CanShake = false;

    public float BallBounceness = 1f;
    PlayerAnimation playerAnimation;


    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _lineRenderer = GetComponent<LineRenderer>();
        _cicleCollider2d = GetComponent<CircleCollider2D>();
        _trailRenderer = GetComponent<TrailRenderer>();




    }

    void Start()
    {
        GetComponent<SpringJoint2D>().enabled = false;
        _trailRenderer.enabled = false;
        _StartPostion = _rigidbody2D.position ;
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimation = GetComponent<PlayerAnimation>();
        _rigidbody2D.isKinematic = true;
        _lineRenderer.enabled = false;
        canTouch = true;
        Time.timeScale = 1f;
        _secondsToWait = 1 / (GetComponent<SpringJoint2D>().frequency * 4);

        shootTimeVal = _pauseMenu.ShootTime;
        bounceTimeVal = _pauseMenu.BounceTime;
        dashTimeVal = _pauseMenu.DashTime;

        groundResetTimeVal = groundResetTime;
        HARDgroundResetTimeVal = HARDgroundResetTime;
        completeTimeVal = completeTime;
        PlatformHitsVal = PlatformHits;


        transform.parent = MainParent.transform;
        FirstPress = true;




    }

    void OnMouseDown()
    {


        if (!touchedWall)
        {
            _lineRenderer.enabled = true;

            
            isPressed = true;
            _cicleCollider2d.enabled = false;
            if (FirstPress)
            {
                _StartPostionLocal = _rigidbody2D.position;
                FirstPress = false;
            }
        }

    }


    void OnMouseUp()
    {

        if (!touchedWall)
        {

            isPressed = false;
            canTouch = false;
            _rigidbody2D.isKinematic = false;
            _lineRenderer.enabled = false;
            _isReleased = true;
            isReset = false;
            inMotion = true;
            _pauseMenu.ShootGroundReset = false;
            groundResetTimeVal = groundResetTime;
            _ballInitalVelocity = (_hookRb2D.position - _rigidbody2D.position) / _secondsToWait;
            _rigidbody2D.AddForce(_ballInitalVelocity * _additionalForce, ForceMode2D.Impulse);
            Invoke("ColliderBackOn", _secondsToWait+0.01f);
            FindObjectOfType<AudioManager>().Play("InGameReleaseSound");
        }


    }

    void Update()
    {
        GroundCheck();
        //Debug.Log(SkinManager.skin);
        _ballUpdateVelocity = _rigidbody2D.velocity;

       
        if (canTouch)
        {
            if (isPressed)
            {
                BallShootFunction();

                _lineRenderer.startColor = Color.black;
                _lineRenderer.endColor = Color.white;

                

            }

        }



        switch (GameValues.difficult) {
            case GameValues.Difficulties.NORMAL:
                if (isGrounded && !hitBin && !_pauseMenu.ShootGroundReset && !isPressed)
                {
                    groundResetTimeVal -= Time.deltaTime;
                    if (groundResetTimeVal <= 0)
                    {
                        StartCoroutine(AfterSomeSeconds());
                        groundResetTimeVal = groundResetTime;


                    }

                }
                break;
            case GameValues.Difficulties.HARD:
                if (isGrounded && !hitBin && !_pauseMenu.ShootGroundReset && !isPressed)
                {

                    HARDgroundResetTimeVal -= Time.deltaTime;
                    if (HARDgroundResetTimeVal <= 0)
                    {
                        StartCoroutine(AfterSomeSeconds());
                        HARDgroundResetTimeVal = HARDgroundResetTime;


                    }

                }
                break;
        }
             


       if(_pauseMenu.shootAgain && _isReleased)
        {
            
           if(isPressed)
            {
                BallShootFunction();
                _trailRenderer.enabled = true;
                _trailRenderer.startColor = Color.blue;
                _trailRenderer.endColor = Color.white;
                _lineRenderer.startColor = Color.blue;
                _lineRenderer.endColor = Color.white;
                
            }
       }

       
       if(_pauseMenu.dashing)
        {
            transform.position += new Vector3(_ballUpdateVelocity.x,_ballUpdateVelocity.y,transform.position.z).normalized *_dashAmount;
            _trailRenderer.enabled = false;
            Instantiate(dashEffectStart, _rigidbody2D.position, Quaternion.identity);
            _pauseMenu.dashing = false;
            CanShake = true;
            


        }



        if (touchedWall && !_pauseMenu.bounceClicked)
        {
            _pauseMenu.shootAgain = false;
            _trailRenderer.enabled = false;
        }

       if(_rigidbody2D.velocity.x == 0)
        {
            isMoving = false;
        }
       else
        {
            isMoving = true;
        }


  
        

        if (isGrounded && hitBin)
        {
            completeTimeVal -= Time.deltaTime;
            if (completeTimeVal <= 0)
            {
                _levelComplete = true;
                FindObjectOfType<AudioManager>().Play("InGameVictory");
                //PlayerPrefs.SetInt("levelsUnlocked", SceneManager.GetActiveScene().buildIndex + 1);
                completeTimeVal = 10000000f;
                
            }
        }

        if(isResetInGame)
        {
            
            StartCoroutine(Reset());
            transform.parent = MainParent.transform;
            isResetInGame = false;
        }


        

        if(onMovingPlatform && isPressed)
        {
            transform.parent = MainParent.transform;
          
            onMovingPlatform = false;
          
           

        }
       


        if(_pauseMenu.bounceClicked)
        {
            _trailRenderer.enabled = true;
            _trailRenderer.startColor = new Color(1, 0, 0); 
            _trailRenderer.endColor = Color.white;

            _lineRenderer.startColor = new Color(1, 0, 0);
            _lineRenderer.endColor = Color.white;
        }

        if(_pauseMenu.shootAgain && _pauseMenu.bounceClicked)
        {
            _trailRenderer.enabled = true;
            _trailRenderer.startColor = new Color(0.5f, 0, 1);
            _trailRenderer.endColor = Color.white;

            _lineRenderer.startColor = new Color(0.5f, 0, 1);
            _lineRenderer.endColor = Color.white;
        }

        if(!_pauseMenu.shootAgain && !_pauseMenu.bounceClicked)
        {
            _trailRenderer.enabled = false;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    { 
        if(collision.gameObject.tag == "Bin")
        {
            hitBin = true;
            FindObjectOfType<AudioManager>().Play("InGameBallHitBin");

        }
        if(collision.gameObject.tag == "Wall")
        {
            touchedWall = true;
            FindObjectOfType<AudioManager>().Play("InGameGroundHit");
        }

        if (collision.gameObject.tag == "Wall" && _pauseMenu.bounceClicked)
        {
            bounceAmountVal++;
            if(bounceAmountVal == bounceAmount)
            {
                _pauseMenu.bounceClicked = false;

                var speed = _ballUpdateVelocity.magnitude;
                var direction = Vector2.Reflect(_ballUpdateVelocity, collision.contacts[0].normal).normalized;
                _rigidbody2D.velocity = direction * Mathf.Max(speed, 0f);
              
                FindObjectOfType<AudioManager>().Play("InGameGroundHit");
                bounceAmountVal = 0;
                
            }
            
        }

        if(collision.gameObject.CompareTag("MovingPlatform") && PlatformHitsVal > 0)
        {
            transform.parent = collision.transform;
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.isKinematic = true;
            onMovingPlatform = true;
            _hookRb2D.transform.position = _rigidbody2D.position;
            _hookRb2D.position = _rigidbody2D.position;
            _pauseMenu.shootAgain = false;
            _pauseMenu.bounceClicked = false;
            canTouch = true;
            touchedWall = false;
            inMotion = false;
            _isReleased = false;
            PlatformHitsVal--;
            FindObjectOfType<AudioManager>().Play("InGameBallHitPlatform"); 
        }
        else
        {
            transform.parent = MainParent.transform;
            onMovingPlatform = false;
        }

        if (_pauseMenu.bounceClicked)
        {

            

            if (collision.gameObject.tag == "Wall")
            {


                var speed = _ballUpdateVelocity.magnitude;
                var direction = Vector2.Reflect(_ballUpdateVelocity, collision.contacts[0].normal).normalized;
                _rigidbody2D.velocity = direction * Mathf.Max(speed, 0f);
                FindObjectOfType<AudioManager>().Play("InGameGroundHit");


            }

        }
        else
        {
            _rigidbody2D.sharedMaterial.bounciness = _ballNormalBounce;
        }
        

        if(collision.gameObject.CompareTag("BinWalls"))
        {
            FindObjectOfType<AudioManager>().Play("InGameBallHitBin"); 
        }


        if(collision.gameObject.CompareTag("Wall") && _pauseMenu.shootAgain)
        {
            FindObjectOfType<AudioManager>().Play("InGameShootHitWall");
        }

        if(collision.gameObject.CompareTag("BinWalls") && _pauseMenu.shootAgain)
        {
            FindObjectOfType<AudioManager>().Play("InGameShootHitWall");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "KillZone")
        {

            if (!killZoneTrigger)
            {
                StartCoroutine(AfterSomeSeconds());
                FindObjectOfType<AudioManager>().Play("InGameDeath");
                killZoneTrigger = true;
            }


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        killZoneTrigger = false;
    }

    public IEnumerator AfterSomeSeconds()
    {

        yield return new WaitForSeconds(_secondsToReset);
        _ballLives.Lives--;
        GameValues.ballLivesHard--;
        _trailRenderer.enabled = false;
        transform.parent = MainParent.transform;
        _rigidbody2D.position = _StartPostionLocal;
        _hookRb2D.transform.position = _StartPostionLocal;
        _hookRb2D.position = _StartPostionLocal;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.sharedMaterial.bounciness = _ballNormalBounce;
         canTouch = true;
        touchedWall = false;
         inMotion = false;
        _isReleased = false;
        _pauseMenu.bounceClicked = false;
        _pauseMenu.shootAgain = false;
        isReset = true;

        onMovingPlatform = false;
        
        
        PlatformHitsVal = PlatformHits;
        bounceAmountVal = 0;
        _pauseMenu.ShootTime = shootTimeVal;
        _pauseMenu.BounceTime = bounceTimeVal;
        _pauseMenu.DashTime = dashTimeVal;


        groundResetTimeVal = groundResetTime;

        _pauseMenu.shootTimeChange.GetComponent<TMPro.TextMeshProUGUI>().text = shootTimeVal.ToString();
        _pauseMenu.bounceTimeChange.GetComponent<TMPro.TextMeshProUGUI>().text = bounceTimeVal.ToString();
        _pauseMenu.dashTimeChange.GetComponent<TMPro.TextMeshProUGUI>().text = dashTimeVal.ToString();

       
    }


    public IEnumerator Reset()
    {

        yield return new WaitForSeconds(_secondsToReset);
        _ballLives.Lives = 3;
        _trailRenderer.enabled = false;
        transform.parent = MainParent.transform;
        _rigidbody2D.position = _StartPostionLocal;
        _hookRb2D.position = _StartPostionLocal;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.sharedMaterial.bounciness = _ballNormalBounce;
        canTouch = true;
        touchedWall = false;
        inMotion = false;
        _isReleased = false;
        _pauseMenu.bounceClicked = false;
        _pauseMenu.shootAgain = false;
        isReset = true;
        hitBin = false;
        _pauseMenu.ShootTime = shootTimeVal;
        _pauseMenu.BounceTime = bounceTimeVal;
        _pauseMenu.DashTime = dashTimeVal;
        
        
        onMovingPlatform = false;
        PlatformHitsVal = PlatformHits;
        bounceAmountVal = 0;
        groundResetTimeVal = groundResetTime;
        playerAnimation.PlayOnce = true;



        _pauseMenu.shootTimeChange.GetComponent<TMPro.TextMeshProUGUI>().text = shootTimeVal.ToString();
        _pauseMenu.bounceTimeChange.GetComponent<TMPro.TextMeshProUGUI>().text = bounceTimeVal.ToString();
        _pauseMenu.dashTimeChange.GetComponent<TMPro.TextMeshProUGUI>().text = dashTimeVal.ToString();


    }



   

    void BallShootFunction()
    {
         mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //_lineRenderer.SetPosition(0, _hookRb2D.position);
        //_lineRenderer.SetPosition(1, _rigidbody2D.position);
        
        if (Vector3.Distance(mousePosition, _hookRb2D.position) > _maxDragDistance)
        {
            _rigidbody2D.position = _hookRb2D.position + ((mousePosition - _hookRb2D.position).normalized * _maxDragDistance);
            Vector2[] trajectory = Plot(_rigidbody2D, _rigidbody2D.position, ((_hookRb2D.position - _rigidbody2D.position) / _secondsToWait) * _additionalForce, TrajectoryNumber);
            _lineRenderer.positionCount = trajectory.Length;
            Vector3[] positions = new Vector3[trajectory.Length];

            for (int i = 0; i < trajectory.Length; i++)
            {
                positions[i] = trajectory[i];
            }
            _lineRenderer.SetPositions(positions);
        }
        else
        {
            _rigidbody2D.position = mousePosition;

            Vector2[] trajectory = Plot(_rigidbody2D, _rigidbody2D.position, ((_hookRb2D.position-_rigidbody2D.position)/_secondsToWait) * _additionalForce, TrajectoryNumber);
            _lineRenderer.positionCount = trajectory.Length;
            Vector3[] positions = new Vector3[trajectory.Length];

            for(int i = 0; i < trajectory.Length; i++)
            {
                positions[i] = trajectory[i];
            }
            _lineRenderer.SetPositions(positions);
           //_lineRenderer.SetPosition(1, _rigidbody2D.position);
        }

    }


    void GroundCheck()
    {
        RaycastHit2D raycastHit2D = Physics2D.CircleCast(_cicleCollider2d.bounds.center- new Vector3(0, groundCheckDistance, 0), _cicleCollider2d.radius, Vector2.right, _cicleCollider2d.radius,groundMask);
        //Debug.Log(raycastHit2D.collider);
        
        if(raycastHit2D.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        
    }

    void ColliderBackOn()
    {
        _cicleCollider2d.enabled = true;
    }



  public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps)
    {
        Vector2[] results = new Vector2[steps];

        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale * timestep * timestep;
        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = velocity * timestep;

        for(int i = 0; i < steps; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(_cicleCollider2d.bounds.center - new Vector3(0, groundCheckDistance , 0), _cicleCollider2d.radius);
    //}
}
    
