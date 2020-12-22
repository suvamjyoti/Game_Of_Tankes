using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	[SerializeField]private float MoveSpeed;
	[SerializeField]private  float rotateSpeed;

	private float vertical;
	private float horizontal;
	
	private Rigidbody rigidbody;

	public AudioSource m_MovementAudio;
	public AudioClip m_EngineIdling;            
    public AudioClip m_EngineDriving;           
    public float m_PitchRange = 0.2f;
	private float m_MovementInputValue;         
    private float m_TurnInputValue;             
    private float m_OriginalPitch; 

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

	private void Awake()
	{
		//joystick=FindObjectOfType<Joystick>();
		rigidbody=GetComponent<Rigidbody>();
	}

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

	private void Start() {
		m_OriginalPitch = m_MovementAudio.pitch;	//store original pitch
		m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
	}


//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

	private void FixedUpdate()
	{
		//JoyStickMove();
		TankMovement();
		TankRotate();
	}

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

	void Update ()
	{	
		vertical=Input.GetAxis("Vertical");
		horizontal=Input.GetAxis("Horizontal");

		if(vertical==0 && horizontal ==0){
			rigidbody.constraints = RigidbodyConstraints.FreezePositionX|RigidbodyConstraints.FreezePositionY|RigidbodyConstraints.FreezePositionZ; 
		}
		else{
			rigidbody.constraints = RigidbodyConstraints.None;
			rigidbody.constraints = RigidbodyConstraints.FreezePositionY|RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationY;
			
		}

		m_MovementInputValue = vertical;
		m_TurnInputValue = horizontal;

		EngineAudio ();

	}

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

	private void TankMovement()
	{
		if(vertical!=0){
			Vector3 moveTank=transform.forward*vertical*MoveSpeed*Time.deltaTime;
			rigidbody.MovePosition(rigidbody.position + moveTank);
		}
	}

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

	private void TankRotate()
	{
		if(horizontal!=0){
			float rotate = horizontal*rotateSpeed*Time.deltaTime;
			Quaternion rotateTank=Quaternion.Euler(0f,rotate,0f);
			rigidbody.MoveRotation(rigidbody.rotation*rotateTank);
		}
	}

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

	private void EngineAudio ()
    {
        if (Mathf.Abs (m_MovementInputValue) < 0.1f && Mathf.Abs (m_TurnInputValue) < 0.1f)
        {
            if (m_MovementAudio.clip == m_EngineDriving)
            {
                m_MovementAudio.clip = m_EngineIdling;
                m_MovementAudio.pitch = Random.Range (m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play ();
            }
        }
        else
        {
            if (m_MovementAudio.clip == m_EngineIdling)
            {
                m_MovementAudio.clip = m_EngineDriving;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
    }


}
