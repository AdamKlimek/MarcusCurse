using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    float MaxDistance = 20;
    public float speed = 5.0f;
    public float rotate_speed = 3.0f;
    private Transform Hero;
    float attackdistance = 10.0f;
    public GameObject Nose;
    GameObject NearestCandle;
    bool isWalking = false;
    float time = 0;
    float timetoplay = 0;
    GameObject Fog;
    Canvas description;
    public GameObject Key;
    static public ParticleSystem.EmissionModule ptr;
    Transform EnemySpawnPoint, EnemyTargetPoint;
    bool Stay = true;
    bool Spawn = true;
    float timeToWalk = 0.0f;
    // Use this for initialization
    void Start ()
    {
        Hero = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        description = gameObject.GetComponentInChildren<Canvas>();
        Fog = GameObject.FindGameObjectWithTag("Fog");
        EnemySpawnPoint = GameObject.Find("Spawn Point Enemy").GetComponent<Transform>();
        EnemyTargetPoint = GameObject.Find("Target Point Enemy").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        description.transform.LookAt(Hero);
        if (LightUpCandle.CandleLightUp > 0 && LightUpCandle.IsLit == false)
        {
            CheckCandle();
        }
        else
        {
            Move();
        }
    }

    void CheckCandle()
    {
        if (LightUpCandle.CandleLightUp == 4)
        {
            Instantiate(Key, transform.position, transform.rotation);
            LightUpCandle.IsLit = true;
            Hero.gameObject.SendMessage("AddLetter", "9");
           Fog.SendMessage("GhostIsDead");
        }
        else
        {
            LightUpCandle.CandleIsLit = LightUpCandle.CandleIsLit.OrderBy(
               candle => Vector3.Distance(transform.position, candle.transform.position)
            ).ToList();

            NearestCandle = LightUpCandle.CandleIsLit.First<GameObject>();
            // transform.LookAt(NearestCandle.transform);
            Vector3 dir = (NearestCandle.transform.position - transform.position);
            dir.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotate_speed);
            Vector3 move = transform.forward;
            move.y = 0;
            if (isWalking == false)
            {
                gameObject.SendMessage("PlayAnimation", "Walk");
                isWalking = true;
            }
            transform.Translate(move * speed * Time.deltaTime, Space.World);
            Vector2 posEnemy = new Vector2(transform.position.x, transform.position.z);
            Vector2 posCandle = new Vector2(NearestCandle.transform.position.x, NearestCandle.transform.position.z);
            if (Vector2.Distance(posEnemy , posCandle) <= 1)
            {
               // NearestCandle.GetComponentInChildren<ParticleSystem>().Stop();
                ptr = NearestCandle.GetComponentInChildren<ParticleSystem>().emission;
                ptr.enabled = false;
                LightUpCandle.CandleLightUp--;
                Debug.Log(LightUpCandle.CandleLightUp);
                LightUpCandle.CandleIsLit.Remove(NearestCandle);
                NearestCandle.GetComponentInChildren<Light>().enabled = false;
                NearestCandle = null;
            }
        }
    }

    void Move()
    {
        Vector2 posEnemy = new Vector2(transform.position.x, transform.position.z);
        Vector2 posHero = new Vector2(Hero.transform.position.x, Hero.transform.position.z);
        float Distance = Vector2.Distance(posEnemy, posHero);

        if (Distance <= attackdistance)
        {
            transform.LookAt(Hero);
            if (isWalking == true)
            {
                gameObject.SendMessage("PlayAnimation", "EndWalk");
                isWalking = false;
                time = Time.realtimeSinceStartup;
            }
            timetoplay = Time.realtimeSinceStartup;
            if(timetoplay >= time + 0.5)
            {
                if (isWalking == false)
                {
                    gameObject.SendMessage("PlayAnimation", "Attack");
                    Nose.SendMessage("EnemyShoot");
                }
            }
        }
        else if(Distance > attackdistance  && Distance <= MaxDistance)
        {
            Vector3 dir = (Hero.transform.position - transform.position);
            dir.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotate_speed);
            Vector3 move = transform.forward;
            move.y = 0;
            if (isWalking == false)
            {
                gameObject.SendMessage("PlayAnimation", "Walk");
                isWalking = true;
            }
            transform.Translate(move * speed * Time.deltaTime, Space.World);
        }
        else if (Distance > MaxDistance)
        {
            float Dist;
            if (Stay == false)
            {
                if(Spawn == true)
                {
                    Dist = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(EnemyTargetPoint.transform.position.x, EnemyTargetPoint.transform.position.z));
                    transform.LookAt(EnemyTargetPoint);
                }
                else
                {
                    Dist = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(EnemySpawnPoint.transform.position.x, EnemySpawnPoint.transform.position.z));
                    transform.LookAt(EnemySpawnPoint);
                }

                Vector3 move = transform.forward;
                move.y = 0;
                if (isWalking == false)
                {
                    gameObject.SendMessage("PlayAnimation", "Walk");
                    isWalking = true;
                }
                transform.Translate(move * speed * Time.deltaTime, Space.World);
                if (Dist <= 1)
                {
                    Spawn = !Spawn;
                    Stay = true;
                }
            }

            if(Stay == true)
            {
                transform.LookAt(Hero);
                if (isWalking == true)
                {
                    gameObject.SendMessage("PlayAnimation", "EndWalk");
                    isWalking = false;
                    time = Time.realtimeSinceStartup;
                }
                timetoplay = Time.realtimeSinceStartup;

                if (timetoplay >= time + 0.5)
                {
                   // Debug.Log(timeToWalk);
                    gameObject.SendMessage("PlayAnimation", "Default Take");
                    timeToWalk += Time.deltaTime;
                    if(timeToWalk  >= 20.0f)
                    {
                        Stay = false;
                        timeToWalk = 0.0f;
                    }
                }
            }
        }

    }
}
