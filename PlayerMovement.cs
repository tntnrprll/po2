using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace clienderPUN
{
    public class PlayerMovement:Photon.PunBehaviour
    {
        public float moveSpeedvalue = 12f;
        public float rotSpeed = 180f;
        private Rigidbody m_Rigidbody;
        private float m_MovementInputValue;
        private float m_TurnInputValue;

        public Camera cam;
        public Transform tr;
        public Transform player;
        float Zoom;

        /*Cube 와 Light 의 전환을 위한 변수 선언  [SerializeField] ==> Serialize할 변수*/

        private int toggle = 2;

        [SerializeField]public GameObject makeCube;
        [SerializeField]public GameObject makeLight;

        GameObject OptionMenu;
        

        private void Start()
        {

            Zoom = 10f;
            tr = cam.GetComponent<Transform>();

            OptionMenu = GameObject.Find("OptionMenu");
            

        }

        private void Awake()
        {
            m_Rigidbody = GetComponent<Rigidbody>();

            

            if(!photonView.isMine)//방금 입력된 것이 내꺼에서 일어난 입력이 아니면
            {

                enabled = false;//이 입력은 내꺼가 아니라는 신호
                cam.enabled = false;
            }
        }
        private void OnEnable()//입력이 내꺼야
        {

            m_Rigidbody.isKinematic = false;//내 리지드바디에 영향을 주겠어
            m_MovementInputValue = 0f;
            m_TurnInputValue = 0f;
        }
        private void OnDisable()//입력이 내꺼가 아니야
        {
            m_Rigidbody.isKinematic = true;//내 리지드바디에 영향을 주지 않겠어
        }
        void Update()
        {

            m_MovementInputValue = Input.GetAxis("Vertical");
            m_TurnInputValue = Input.GetAxis("Horizontal");
        }
        private void FixedUpdate()
        {
            Move();
            Turn();
            CameraZoom();
            InputTap();
        }
        private void Move()
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.Translate(Vector3.forward * moveSpeedvalue * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.Translate(Vector3.back * moveSpeedvalue * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Translate(Vector3.left * moveSpeedvalue * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(Vector3.right * moveSpeedvalue * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.E))
            {
                this.transform.Translate(Vector3.up * moveSpeedvalue * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.Q))
            {
                this.transform.Translate(Vector3.down * moveSpeedvalue * Time.deltaTime);

            }
            //Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

            //m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        }
        private void Turn()
        {
            if (Input.GetMouseButton(0))
            {

                float yRot = Input.GetAxis("Mouse X") * rotSpeed;
                float xRot = Input.GetAxis("Mouse Y") * rotSpeed;


                this.transform.localRotation *= Quaternion.Euler(0, yRot, 0);
                cam.transform.localRotation *= Quaternion.Euler(-xRot, 0, 0);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                float yRot = Input.GetAxis("Mouse X") * rotSpeed;
                float xRot = Input.GetAxis("Mouse Y") * rotSpeed;


                this.transform.localRotation *= Quaternion.Euler(0, yRot, 0);
                cam.transform.localRotation *= Quaternion.Euler(-xRot, 0, 0);
            }



            /*float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);*/
        }
        void CameraZoom()
        {
            Vector3 dist_position = (tr.position) - (player.position);
            dist_position = Vector3.Normalize(dist_position);

            tr.position-= (dist_position * Input.GetAxis("Mouse ScrollWheel") * Zoom);
            
        }

        void InputTap()
        {
            if(Input.GetKeyDown(KeyCode.Tab))//Cube와 Light의 전환을 위한 Tap 키가 눌렸을 때
            {
                if (toggle == 2)//Cube가 선택되어있는 상황에서 눌림
                {

                    OptionMenu.GetComponent<ChangeCubeAndLight>().ChangeOption2(false,true);
                    /* OptionMenu라는 GameObject에 담신 컴포넌트 중 ChangeCubeAndLight 컴포넌트에서 
                     changeOption2 라는 함수를 호출 */


                    makeCube.SetActive(false);//Cube를 생성하는 GameObject의 상태를 비활성으로 전환
                    makeLight.SetActive(true);//Light를 생성하는 GameObject의 상태를 활성으로 전환

                    toggle = 1;//현재 선택되어었는 것이 Light임을 나타냄
                }
                else if (toggle == 1)//Light가 선택되어있는 상황에서 눌림
                {
                    OptionMenu.GetComponent<ChangeCubeAndLight>().ChangeOption2(true, false);


                    makeCube.SetActive(true);
                    makeLight.SetActive(false);

                    toggle = 2;

                }
            }
        }

        /*Serialize 하기위한 메소드*/

        public void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info)
        {
            if (stream.isWriting)//쓸 때
            {
                stream.SendNext(toggle);
                stream.SendNext(makeCube.activeSelf);
                stream.SendNext(makeLight.activeSelf);
                /* toggle과 makeCube,makeLight의 상태를 stream을 통해 전달 */


            }
            else if (stream.isReading)//읽을 때
            {
                toggle = (int)stream.ReceiveNext();
                makeCube.SetActive((bool)stream.ReceiveNext());
                makeLight.SetActive((bool)stream.ReceiveNext());
                /* toggle과 makeCube,makeLight의 상태를 전달 받음 */


            }
        }
    }
    
}
