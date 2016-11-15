using UnityEngine;
using UnityEngine.UI;
using Systems.Collections;

public class AbilityCoolDown : MonoBehaviour
{
	public string AbilityButtonAxisName = "Fire1";
	public Image darkMask;
	public Text coolDownTextDisplay;
	
	[SerializeField] private Ability ability; //can set a private field in  sinpector or change if needed
	[SerializeField] private GameObject weaponHolder;
	public Image myButtonImage;
	private AudioSource abilitySource;
	private float coolDownDuration;
	private float nextReadyTime;
	private float coolDownTimeLeft;
	
	
	
	void Start()
	{
		Initialize(ability, weaponHolder);
	}
	
	public void Initialize(Ability selectedAbility, GameObject weaponHolder)
	{
		ability = selectedAbility;
		myButtonImage = GetComponent<Image>();
		abilitySource = GetComponent<AudioSource>();
		myButtonImage.sprite = ability.aSprite;
		darkMask.sprite = ability.aBaseCoolDown;
		ability.Initialize(weaponHolder);
		AbilityReady();
	}
	
	
	void Update()
	{
		bool coolDownComplete = (Time.time > nextReadyTime);
		if(coolDownComplete)
		{
			AbilityReady();
			if(Input.GetButtonDown(abilityButtonAxisName))
			{
				ButtonTriggered();
			}
		
		}
		else
		{
			CoolDown();
		}
	}
	
	private void AbilityReady()
	{
		coolDownTextDisplay.enabled = false;
		darkMask.enabled = false;
	}
	
	private void CoolDown()
	{
		coolDownTimeLeft -= Time.deltaTime;
		float roundedCD = Mathf.Round(coolDownTimeLeft);
		coolDownTextDisplay.text = roundedCD.ToString();
		darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
	}
	
	
	private void ButtonTriggered()
	{
		nextReadyTime = coolDownDuration + Time.time;
		coolDownTimeLeft = coolDownDuration;
		darkMask.enabled = true;
		coolDownTextDisplay.enabled = true;
		
		abilitySource.clip = ability.aSound;
		abilitySource.Play();
		ability.TriggerAbility();
	}
	
	
	
}