using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class SoldierUserControl : MonoBehaviour
    {
        public float fireRate;
        public Transform shotSpawn;
        public GameObject shot;

        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private float nextFire;
        private new Rigidbody rigidbody;
        private Animator m_Animator;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            m_Animator = GetComponent<Animator>();

            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

        }


        private void Update()
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                m_Animator.SetBool("isShooting", true);
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GetComponent<AudioSource>().Play();
            }
            else
            {
                m_Animator.SetBool("isShooting", false);
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {


            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            Vector3 movement = new Vector3(h, 0.0f, v);
            var y_vel = rigidbody.velocity.y;
            rigidbody.velocity = movement * 5;
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, y_vel, rigidbody.velocity.z);

            if (v != 0 || h != 0)
            {
                m_Animator.SetBool("isRunning", true);
                if (Time.timeScale != 1.0f)
                {
                    Time.timeScale = 1.0f;
                    Time.fixedDeltaTime = 0.02F;
                }
            }
            else
            {
                m_Animator.SetBool("isRunning", false);
                if (Time.timeScale == 1.0f)
                {
                    Time.timeScale = 0.2f;
                    Time.fixedDeltaTime = 0.02F * Time.timeScale;
                }
            }

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward;// + h*Vector3.right;
            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            

        }
    }
}
