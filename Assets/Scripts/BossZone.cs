using UnityEngine;
using UnityEngine.UI;

public class BossZone : MonoBehaviour
{
    [SerializeField] private GameObject bossZone;
    [SerializeField] private GameObject bossCharacterPrefab;
    
    private GameObject positionForSpawnBoss;
    private GameObject boss;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            positionForSpawnBoss = GameObject.Find("SpawnBossPoint");
            if (boss == null) boss = Instantiate(bossCharacterPrefab, positionForSpawnBoss.transform.localPosition,Quaternion.identity);
            
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>().InBossZone();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("BossHealthBar").GetComponent<Image>().enabled = false;
            Destroy(boss);
            
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>().BeyondBossZone();
        }
    }
}
