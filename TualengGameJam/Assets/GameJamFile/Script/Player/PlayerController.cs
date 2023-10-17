using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int PlayerIndex = 0;
    [SerializeField] CharacterProperties[] PlayerModels;
	[SerializeField] int speed;

	[Header("Player Properties")]
	[SerializeField] int playerhealth;
	[SerializeField] int playermana;
	[SerializeField] int playerStamina;
	[SerializeField] float playerAttackSpeed;
	[SerializeField] int playerAttackDamage;
	[SerializeField] PlayerType playerType;

	[Header("Check")]
	public bool AllPlayerDead;
	//private player properties
	private Vector3 StartPlayerposition;
	private Vector3 SelectPlayerposition;

	//private mousepos
	private Vector3 mousePosition;
	private float angle;

	//private bool Check
	[SerializeField] private bool[] check; //0 : SwapPlayerCoolDown //1 : BasicAttackCoolDown // 
    private void Start()
    {
		check = new bool[2];
		SetupPlayerTeam();
    }

    private void Update()
    {
		FixedCameraPos();
		RotateGroup();
		Movement();
		SwapPlayer();
		BasicAttack();
		CheckDead();
	}

	void SetupPlayerTeam()
    {
		StartPlayerposition = SelectPlayerposition = PlayerModels[0].gameObject.transform.localPosition;
		playermana = PlayerModels[0].CurrentMana;
		playerhealth = PlayerModels[0].CurrentHealth;
		playerStamina = PlayerModels[0].CurrentStamina;
		playerAttackSpeed = PlayerModels[0].player.AttackSpeedDelay;
		playerAttackDamage = PlayerModels[0].player.AttackDamage;
		playerType = PlayerModels[0].CharacterType;
		PlayerModels[0].is_Active = true;
	}

    #region Movement
    void FixedCameraPos()
    {
		Camera.main.transform.position = new Vector3(transform.position.x, 15, transform.position.z);
	}

    void RotateGroup()
    {
		mousePosition = Input.mousePosition;

		angle = Mathf.Atan2(mousePosition.x - (Screen.width * 0.5f), mousePosition.y - (Screen.height * 0.5f)) * Mathf.Rad2Deg;
		if (angle < 0) angle += 360;
		transform.localEulerAngles = new Vector3(0, angle, 0);
		//transform.eulerAngles = new Vector3(0, Input.GetAxis("Mouse X") + transform.eulerAngles.y, 0);
	}
    void Movement()
    {
		if (Input.GetKey(KeyCode.D))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.position += Vector3.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.position += Vector3.back * speed * Time.deltaTime;
		}
	}
    #endregion

    void SwapPlayer()
    {
		if (!check[0])
		{
			if (Input.GetKey(KeyCode.Alpha1))
			{
				StartCoroutine(DelayTime(0, 2f));
				SetSwapPlayer(0);
			}
			if (Input.GetKey(KeyCode.Alpha2))
			{
				StartCoroutine(DelayTime(0, 2f));
				SetSwapPlayer(1);
			}
			if (Input.GetKey(KeyCode.Alpha3))
			{
				StartCoroutine(DelayTime(0, 2f));
				SetSwapPlayer(2);
			}
			if (Input.GetKey(KeyCode.Alpha4))
			{
				StartCoroutine(DelayTime(0, 2f));
				SetSwapPlayer(3);
			}
		}
	}

	void SetSwapPlayer(int characterIndex)
    {
		//saved current 
		PlayerModels[PlayerIndex].is_Active = false;
		PlayerModels[PlayerIndex].CurrentMana = playermana;
		PlayerModels[PlayerIndex].CurrentHealth = playerhealth;
		PlayerModels[PlayerIndex].CurrentStamina = playerStamina;

		//switch main to select character
		SelectPlayerposition = PlayerModels[characterIndex].gameObject.transform.localPosition;
		PlayerModels[PlayerIndex].gameObject.transform.localPosition = SelectPlayerposition;

		//switch select character to main
		PlayerIndex = characterIndex;
		PlayerModels[PlayerIndex].gameObject.transform.localPosition = StartPlayerposition;

		//Setup
		PlayerModels[PlayerIndex].is_Active = true;
		playermana = PlayerModels[characterIndex].CurrentMana;
		playerhealth = PlayerModels[characterIndex].CurrentHealth;
		playerStamina = PlayerModels[characterIndex].CurrentStamina;
		playerAttackSpeed = PlayerModels[characterIndex].player.AttackSpeedDelay;
		playerAttackDamage = PlayerModels[characterIndex].player.AttackDamage;
		playerType = PlayerModels[characterIndex].CharacterType;
	}


    #region Damage

    void ReceiveDamage(int damage)
    {
		playerhealth -= damage;
		PlayerModels[PlayerIndex].CurrentHealth = playerhealth;
	}

	#endregion

	#region Attack

	void BasicAttack()
    {
		if (!check[1])
		{
			if (playerStamina > 0)
			{
				if (Input.GetMouseButton(0))
				{
					StartCoroutine(DelayTime(1, playerAttackSpeed));
					playerStamina--;
					PlayerModels[PlayerIndex].CurrentStamina = playerStamina;
					if (playerType == PlayerType.Tank || playerType == PlayerType.Mage)
					{
						PlayerModels[PlayerIndex].transform.GetChild(0).gameObject.SetActive(true);
						StartCoroutine(TurnoffGameObject(PlayerModels[PlayerIndex].transform.GetChild(0).gameObject, 0.3f));
					}
					else if (playerType == PlayerType.Archer)
					{
						GameObject bullet = BulletPool.instance.GetBulletFromPool();
						bullet.transform.position = PlayerModels[PlayerIndex].transform.GetChild(0).gameObject.transform.position;
						bullet.transform.rotation = PlayerModels[PlayerIndex].transform.GetChild(0).gameObject.transform.rotation;
						bullet.GetComponent<Bullet>().Damage = playerAttackDamage;
						bullet.GetComponent<Bullet>().ActiveTime = 1f;
						bullet.SetActive(true);
					}
					else if (playerType == PlayerType.Healer)
					{
						GameObject bullet = BulletPool.instance.GetBulletFromPool();
						bullet.transform.position = PlayerModels[PlayerIndex].transform.GetChild(0).gameObject.transform.position;
						bullet.transform.rotation = PlayerModels[PlayerIndex].transform.GetChild(0).gameObject.transform.rotation;
						bullet.GetComponent<Bullet>().Damage = playerAttackDamage;
						bullet.GetComponent<Bullet>().ActiveTime = 0.3f;
						bullet.SetActive(true);
					}
				}
			}
            else
            {
				playerStamina = 0;
            }
		}
    }

	IEnumerator TurnoffGameObject(GameObject col,float time)
    {
		yield return new WaitForSeconds(time);
		col.SetActive(false);
    }
	void PlayerSkill()
    {

    }

	void Ultimate()
    {

    }
    #endregion

    #region Checking

	void CheckDead()
    {
        if (playerhealth <= 0)
        {
			PlayerModels[PlayerIndex].is_Active = false;
			PlayerModels[PlayerIndex].is_Dead = true;
			for(int i = 0; i < PlayerModels.Length; i++)
            {
                if (!PlayerModels[i].is_Dead)
                {
					SetSwapPlayer(i);
					break;
				}
            }
			CheckAllCharacterDie();
		}
	}
	void CheckAllCharacterDie()
    {
		int deadcount = 0;
		foreach (CharacterProperties player in PlayerModels)
        {	
            if (!player.is_Dead)
            {
				break;
            }
            else
            {
				deadcount++;
			}
        }
		if(deadcount == PlayerModels.Length)
        {
			AllPlayerDead = true;
        }

    }

    #endregion

	IEnumerator DelayTime(int boolIndex, float time)
    {
        check[boolIndex] = true;
		yield return new WaitForSeconds(time);
		check[boolIndex] = false;
    }
}
