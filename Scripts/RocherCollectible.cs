using UnityEngine;

public class RocherCollectible : MonoBehaviour
{
    public KeyCode toucheCollecte = KeyCode.E;
    public float rayonDetection = 0.1f; // Rayon de d�tection autour du rocher
    public Inventory inventory;

    private void Start(){

        // R�cup�rer le script d'inventaire du joueur au d�marrage
        GameObject joueur = GameObject.FindGameObjectWithTag("Inventory");

        if (joueur != null){
            inventory = joueur.GetComponent<Inventory>();

            if (inventory == null) Debug.LogError("Le joueur n'a pas de script Inventory attach�.");
            else Debug.Log("Iventaire recuperais");

        }
        else Debug.LogError("Aucun objet avec le tag 'Player' trouv�.");
        
 }
    

    private void Update()
    {
        Collider2D joueurCollider = Physics2D.OverlapCircle(transform.position, rayonDetection, LayerMask.GetMask("Player"));

        if (joueurCollider != null && Input.GetKeyDown(toucheCollecte))
        {
            CollecterRocher();
        }
    }

    private void CollecterRocher()
    {
        // Code pour collecter le rocher
        if (inventory.ajouteObject(gameObject)){
            Debug.Log("Rocher collect� !");
            Destroy(gameObject);
        }  
        else Debug.Log("PLus de place dans l'inventaire !");

    }

    private void OnDrawGizmosSelected()
    {
        // Dessine un cercle de d�tection autour du rocher dans l'�diteur
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rayonDetection);
    }
}
