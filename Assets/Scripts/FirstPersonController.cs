using UnityEngine;
using UnityEngine.UI;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	[RequireComponent(typeof(CharacterController))]
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
	[RequireComponent(typeof(PlayerInput))]
#endif
	public class FirstPersonController : MonoBehaviour
	{
		[Header("Player")]
		[Tooltip("Move speed of the character in m/s")]
		public float MoveSpeed = 4.0f;
		[Tooltip("Sprint speed of the character in m/s")]
		public float SprintSpeed = 6.0f;
		[Tooltip("Rotation speed of the character")]
		public float RotationSpeed = 1.0f;
		[Tooltip("Acceleration and deceleration")]
		public float SpeedChangeRate = 10.0f;

		[Space(10)]
		[Tooltip("The height the player can jump")]
		public float JumpHeight = 1.2f;
		[Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
		public float Gravity = -15.0f;

		[Space(10)]
		[Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
		public float JumpTimeout = 0.1f;
		[Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
		public float FallTimeout = 0.15f;

		[Header("Player Grounded")]
		[Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
		public bool Grounded = true;
		[Tooltip("Useful for rough ground")]
		public float GroundedOffset = -0.14f;
		[Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
		public float GroundedRadius = 0.5f;
		[Tooltip("What layers the character uses as ground")]
		public LayerMask GroundLayers;

		[Header("Cinemachine")]
		[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
		public GameObject CinemachineCameraTarget;
		[Tooltip("How far in degrees can you move the camera up")]
		public float TopClamp = 90.0f;
		[Tooltip("How far in degrees can you move the camera down")]
		public float BottomClamp = -90.0f;

		// cinemachine
		private float _cinemachineTargetPitch;

		// player
		private float _speed;
		private float _rotationVelocity;
		private float _verticalVelocity;
		private float _terminalVelocity = 53.0f;

		// timeout deltatime
		private float _jumpTimeoutDelta;
		private float _fallTimeoutDelta;

		private PlayerInput _playerInput;
		private CharacterController _controller;
		private StarterAssetsInputs _input;
		private GameObject _mainCamera;

		private const float _threshold = 0.01f;
		
		private bool IsCurrentDeviceMouse => _playerInput.currentControlScheme == "KeyboardMouse";

		//=====dialogue=====
		public Transform checkAstro;
		public LayerMask whatisAstro;
		public bool isAstro=false;
		public bool verif_astro=false;
		public bool test_astro=true;/*
		public LayerMask whatisAstro2;
		public bool isAstro2;
		public bool verif2=false;
		public bool test2;
		public LayerMask whatisAstro3;
		public bool isAstro3;
		public bool verif3=false;
		public bool test3;
		public LayerMask whatisAstro4;
		public bool isAstro4;
		public bool verif4=false;
		public bool test4;
		public LayerMask whatisAstro5;
		public bool isAstro5;
		public bool verif5=false;
		public bool test5;*/
		public static bool b=false;


		public static void changeMove(bool f){
			b=f;
		}

		private void Awake()
		{
			// get a reference to our main camera
			if (_mainCamera == null)
			{
				_mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
			}
		}

		private void Start()
		{
			_controller = GetComponent<CharacterController>();
			_input = GetComponent<StarterAssetsInputs>();
			_playerInput = GetComponent<PlayerInput>();

			// reset our timeouts on start
			_jumpTimeoutDelta = JumpTimeout;
			_fallTimeoutDelta = FallTimeout;
		}

		private void Update()
		{
			JumpAndGravity();
			GroundedCheck();
			if(b){Move();}

			//=====asto 1======
			Collider[] hitColliders = Physics.OverlapSphere(checkAstro.position,0.5f,whatisAstro);
			if(hitColliders.Length==0 || GameConfig.endGameTime || GameConfig.endMission1){
				isAstro=false;
				GameObject.FindGameObjectWithTag("ImageBox1").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Astronaut1").GetComponent<Dialogue>().isOnDial=false;
				GameObject.FindGameObjectWithTag("Astronaut1").GetComponent<Dialogue>().currentDialogue=0;
				GameObject.FindGameObjectWithTag("DialogueBox1").GetComponent<Text>().text="";
				GameObject.FindGameObjectWithTag("E1").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Text1").GetComponent<Text>().enabled = false;
				test_astro=true;
			}
			else{
				isAstro=true;
			}
			if(isAstro && test_astro){
				GameObject.FindGameObjectWithTag("E1").GetComponent<Image>().enabled = true;
				GameObject.FindGameObjectWithTag("Text1").GetComponent<Text>().enabled = true;
			}
			if(!_input.etkalam){
				verif_astro=false;
			}
			else{
				GameObject.FindGameObjectWithTag("E1").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Text1").GetComponent<Text>().enabled = false;
				test_astro=false;
			}
			if(isAstro && _input.etkalam && !verif_astro)
			{
				verif_astro=true;
				Collider[] Astronaut = Physics.OverlapSphere(checkAstro.position, 10f, whatisAstro);
				foreach (Collider item in Astronaut){
					if(item.GetComponent<Dialogue>().isOnDial)
					{
						item.GetComponent<Dialogue>().NextLine();
					}
					else
					{
						GameObject.FindGameObjectWithTag("ImageBox1").GetComponent<Image>().enabled=true;
						item.GetComponent<Dialogue>().StartDialogue();
					}
					if(!item.GetComponent<Dialogue>().isOnDial)
					{
						verif_astro = true;
						GameObject.FindGameObjectWithTag("ImageBox1").GetComponent<Image>().enabled=false;
					}
				}
			}


/*
			//=====asto 2======
			Collider[] hitColliders2 = Physics.OverlapSphere(checkAstro.position,0.5f,whatisAstro2);
			if(hitColliders2.Length==0){
				isAstro2=false;
				GameObject.FindGameObjectWithTag("ImageBox2").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Astronaut2").GetComponent<Dialogue>().isOnDial=false;
				GameObject.FindGameObjectWithTag("Astronaut2").GetComponent<Dialogue>().currentDialogue=0;
				GameObject.FindGameObjectWithTag("DialogueBox2").GetComponent<Text>().text="";
				GameObject.FindGameObjectWithTag("E2").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Text2").GetComponent<Text>().enabled = false;
				test2=true;
			}
			else{
				isAstro2=true;
			}
			if(isAstro2 && test2){
				GameObject.FindGameObjectWithTag("E2").GetComponent<Image>().enabled = true;
				GameObject.FindGameObjectWithTag("Text2").GetComponent<Text>().enabled = true;
			}
			if(!_input.etkalam){
				verif2=false;
			}
			else{
				GameObject.FindGameObjectWithTag("E2").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Text2").GetComponent<Text>().enabled = false;
				test2=false;
			}
			
			if(isAstro2 && _input.etkalam && !verif2)
			{
				verif2=true;
				Collider[] Astronaut2 = Physics.OverlapSphere(checkAstro.position, 10f, whatisAstro2);
				foreach (Collider item in Astronaut2){
					if(item.GetComponent<Dialogue>().isOnDial)
					{
						item.GetComponent<Dialogue>().NextLine();
					}
					else
					{
						GameObject.FindGameObjectWithTag("ImageBox2").GetComponent<Image>().enabled=true;
						item.GetComponent<Dialogue>().StartDialogue2();
					}
					if(!item.GetComponent<Dialogue>().isOnDial)
					{
						verif2 = true;
						GameObject.FindGameObjectWithTag("ImageBox2").GetComponent<Image>().enabled=false;
					}
				}
			}
			//=====asto 3======
			Collider[] hitColliders3 = Physics.OverlapSphere(checkAstro.position,0.5f,whatisAstro3);
			if(hitColliders3.Length==0){
				isAstro3=false;
				GameObject.FindGameObjectWithTag("ImageBox3").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Astronaut3").GetComponent<Dialogue>().isOnDial=false;
				GameObject.FindGameObjectWithTag("Astronaut3").GetComponent<Dialogue>().currentDialogue=0;
				GameObject.FindGameObjectWithTag("DialogueBox3").GetComponent<Text>().text="";
				GameObject.FindGameObjectWithTag("E3").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Text3").GetComponent<Text>().enabled = false;
				test3=true;
			}
			else{
				isAstro3=true;
			}
			if(isAstro3 && test3){
				GameObject.FindGameObjectWithTag("E3").GetComponent<Image>().enabled = true;
				GameObject.FindGameObjectWithTag("Text3").GetComponent<Text>().enabled = true;
			}
			if(!_input.etkalam){
				verif3=false;
			}
			else{
				GameObject.FindGameObjectWithTag("E3").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Text3").GetComponent<Text>().enabled = false;
				test3=false;
			}
			if(isAstro3 && _input.etkalam && !verif3)
			{
				verif3=true;
				Collider[] Astronaut3 = Physics.OverlapSphere(checkAstro.position, 10f, whatisAstro3);
				foreach (Collider item in Astronaut3){
					if(item.GetComponent<Dialogue>().isOnDial)
					{
						item.GetComponent<Dialogue>().NextLine();
					}
					else
					{
						GameObject.FindGameObjectWithTag("ImageBox3").GetComponent<Image>().enabled=true;
						item.GetComponent<Dialogue>().StartDialogue3();
					}
					if(!item.GetComponent<Dialogue>().isOnDial)
					{
						verif3 = true;
						GameObject.FindGameObjectWithTag("ImageBox3").GetComponent<Image>().enabled=false;
					}
				}
			}
			
			//=====asto 4======
			Collider[] hitColliders4 = Physics.OverlapSphere(checkAstro.position,0.5f,whatisAstro4);
			if(hitColliders4.Length==0){
				isAstro4=false;
				GameObject.FindGameObjectWithTag("ImageBox4").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Astronaut4").GetComponent<Dialogue>().isOnDial=false;
				GameObject.FindGameObjectWithTag("Astronaut4").GetComponent<Dialogue>().currentDialogue=0;
				GameObject.FindGameObjectWithTag("DialogueBox4").GetComponent<Text>().text="";
				GameObject.FindGameObjectWithTag("E4").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Text4").GetComponent<Text>().enabled = false;
				test4=true;
			}
			else{
				isAstro4=true;
			}
			if(isAstro4 && test4){
				GameObject.FindGameObjectWithTag("E4").GetComponent<Image>().enabled = true;
				GameObject.FindGameObjectWithTag("Text4").GetComponent<Text>().enabled = true;
			}
			if(!_input.etkalam){
				verif4=false;
			}
			else{
				GameObject.FindGameObjectWithTag("E4").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Text4").GetComponent<Text>().enabled = false;
				test4=false;
			}
			if(isAstro4 && _input.etkalam && !verif4)
			{
				verif4=true;
				Collider[] Astronaut4 = Physics.OverlapSphere(checkAstro.position, 10f, whatisAstro4);
				foreach (Collider item in Astronaut4){
					if(item.GetComponent<Dialogue>().isOnDial)
					{
						item.GetComponent<Dialogue>().NextLine();
					}
					else
					{
						GameObject.FindGameObjectWithTag("ImageBox4").GetComponent<Image>().enabled=true;
						item.GetComponent<Dialogue>().StartDialogue4();
					}
					if(!item.GetComponent<Dialogue>().isOnDial)
					{
						verif4 = true;
						GameObject.FindGameObjectWithTag("ImageBox4").GetComponent<Image>().enabled=false;
					}
				}
			}

			//=====asto 5======
			Collider[] hitColliders5 = Physics.OverlapSphere(checkAstro.position,0.5f,whatisAstro5);
			if(hitColliders5.Length==0){
				isAstro5=false;
				GameObject.FindGameObjectWithTag("ImageBox5").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Astronaut5").GetComponent<Dialogue>().isOnDial=false;
				GameObject.FindGameObjectWithTag("Astronaut5").GetComponent<Dialogue>().currentDialogue=0;
				GameObject.FindGameObjectWithTag("DialogueBox5").GetComponent<Text>().text="";
				GameObject.FindGameObjectWithTag("E5").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Text5").GetComponent<Text>().enabled = false;
				test5=true;
			}
			else{
				isAstro5=true;
			}
			if(isAstro5 && test5){
				GameObject.FindGameObjectWithTag("E5").GetComponent<Image>().enabled = true;
				GameObject.FindGameObjectWithTag("Text5").GetComponent<Text>().enabled = true;
			}
			if(!_input.etkalam){
				verif5=false;
			}
			else{
				GameObject.FindGameObjectWithTag("E5").GetComponent<Image>().enabled=false;
				GameObject.FindGameObjectWithTag("Text5").GetComponent<Text>().enabled = false;
				test5=false;
			}
			if(isAstro5 && _input.etkalam && !verif5)
			{
				verif5=true;
				Collider[] Astronaut5 = Physics.OverlapSphere(checkAstro.position, 10f, whatisAstro5);
				foreach (Collider item in Astronaut5){
					if(item.GetComponent<Dialogue>().isOnDial)
					{
						item.GetComponent<Dialogue>().NextLine();
					}
					else
					{
						GameObject.FindGameObjectWithTag("ImageBox5").GetComponent<Image>().enabled=true;
						item.GetComponent<Dialogue>().StartDialogue5();
					}
					if(!item.GetComponent<Dialogue>().isOnDial)
					{
						verif5 = true;
						GameObject.FindGameObjectWithTag("ImageBox5").GetComponent<Image>().enabled=false;
					}
				}
			}*/
		}

		private void LateUpdate()
		{
			CameraRotation();
		}

		private void GroundedCheck()
		{
			// set sphere position, with offset
			Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
			Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
		}

		private void CameraRotation()
		{
			// if there is an input
			if (_input.look.sqrMagnitude >= _threshold)
			{
				//Don't multiply mouse input by Time.deltaTime
				float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;
				
				_cinemachineTargetPitch += _input.look.y * RotationSpeed * deltaTimeMultiplier;
				_rotationVelocity = _input.look.x * RotationSpeed * deltaTimeMultiplier;

				// clamp our pitch rotation
				_cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

				// Update Cinemachine camera target pitch
				CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

				// rotate the player left and right
				transform.Rotate(Vector3.up * _rotationVelocity);
			}
		}

		private void Move()
		{
			// set target speed based on move speed, sprint speed and if sprint is pressed
			float targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed;

			// a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

			// note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
			// if there is no input, set the target speed to 0
			if (_input.move == Vector2.zero) targetSpeed = 0.0f;

			// a reference to the players current horizontal velocity
			float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

			float speedOffset = 0.1f;
			float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

			// accelerate or decelerate to target speed
			if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
			{
				// creates curved result rather than a linear one giving a more organic speed change
				// note T in Lerp is clamped, so we don't need to clamp our speed
				_speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * SpeedChangeRate);

				// round speed to 3 decimal places
				_speed = Mathf.Round(_speed * 1000f) / 1000f;
			}
			else
			{
				_speed = targetSpeed;
			}

			// normalise input direction
			Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

			// note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
			// if there is a move input rotate player when the player is moving
			if (_input.move != Vector2.zero)
			{
				// move
				inputDirection = transform.right * _input.move.x + transform.forward * _input.move.y;
			}

			// move the player
			_controller.Move(inputDirection.normalized * (_speed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
		}

		private void JumpAndGravity()
		{
			if (Grounded)
			{
				// reset the fall timeout timer
				_fallTimeoutDelta = FallTimeout;

				// stop our velocity dropping infinitely when grounded
				if (_verticalVelocity < 0.0f)
				{
					_verticalVelocity = -2f;
				}

				// Jump
				if (_input.jump && _jumpTimeoutDelta <= 0.0f)
				{
					// the square root of H * -2 * G = how much velocity needed to reach desired height
					_verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);
				}

				// jump timeout
				if (_jumpTimeoutDelta >= 0.0f)
				{
					_jumpTimeoutDelta -= Time.deltaTime;
				}
			}
			else
			{
				// reset the jump timeout timer
				_jumpTimeoutDelta = JumpTimeout;

				// fall timeout
				if (_fallTimeoutDelta >= 0.0f)
				{
					_fallTimeoutDelta -= Time.deltaTime;
				}

				// if we are not grounded, do not jump
				_input.jump = false;
			}

			// apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
			if (_verticalVelocity < _terminalVelocity)
			{
				_verticalVelocity += Gravity * Time.deltaTime;
			}
		}

		private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
		{
			if (lfAngle < -360f) lfAngle += 360f;
			if (lfAngle > 360f) lfAngle -= 360f;
			return Mathf.Clamp(lfAngle, lfMin, lfMax);
		}

		private void OnDrawGizmosSelected()
		{
			Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
			Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

			if (Grounded) Gizmos.color = transparentGreen;
			else Gizmos.color = transparentRed;

			// when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
			Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z), GroundedRadius);
		}
	}
}