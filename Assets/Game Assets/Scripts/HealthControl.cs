using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthControl : MonoBehaviour {


   public float HealthPoints;
    public Image HealthBar;
    float Damage = 10.0f;
    float PlayersDamage = 0.0f;
    Transform Heroes;
    Transform Enemy;
    GameObject Fog;
    GameObject Display;
    Image Eq;
    public AudioClip hurt;
    public AudioClip heal;
    // Use this for initialization
    void Start ()
    {
        HealthPoints = 100;
        Fog = GameObject.FindGameObjectWithTag("Fog");
        Display = GameObject.Find("HealthDisplay");
        Eq = GameObject.FindGameObjectWithTag("Equipment").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        PlayersDamage = Hero.ActuallyForce / 100;
        CheckHealth();
        if(gameObject.tag == "Player")
        {
            Display.GetComponent<Text>().text = HealthPoints + "/100";
        }
    }

    void Attack(float dmg)
    {
        if (HealthPoints > 0)
        {
            HealthPoints -= dmg;
            if(gameObject.tag == "Player")
            {
                GetComponent<AudioSource>().PlayOneShot(hurt);
            }

            if(HealthPoints <= 0)
            {
                if(gameObject.tag == "Enemy")
                {
                    Fog.SendMessage("GhostIsDead");
                }
                else
                {
                    gameObject.SendMessage("Dead");
                }
            }
        }

    }

    void Heal(float AmountOfHeal)
    {
        if (HealthPoints > 0)
        {
            GetComponent<AudioSource>().PlayOneShot(heal);
            HealthPoints += AmountOfHeal;
            if(HealthPoints > 100)
            {
                HealthPoints = 100;
            }

        }
    }

    void OnCollisionEnter(Collision bullet)
    {
        if (gameObject.CompareTag("Player") && bullet.collider.CompareTag("Bullet"))
        {
            Debug.Log("duch strzela");
            Attack(Damage);
        }
        else if (gameObject.CompareTag("Enemy") && bullet.collider.CompareTag("Coal") && Eq.transform.FindChild("Holy water"))
        {
            Attack(PlayersDamage);
        }
    }
    void CheckHealth()
    {
        HealthBar.rectTransform.localScale = new Vector3(HealthPoints / 100, HealthBar.rectTransform.localScale.y, HealthBar.rectTransform.localScale.z);
    }
}
