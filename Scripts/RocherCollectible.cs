using UnityEngine;

public class RocherCollectible : MonoBehaviour
{
    public KeyCode toucheCollecte = KeyCode.E;
    public float rayonDetection = 0.1f; // Rayon de détection autour du rocher
    public Inventory inventory;

    private void Start(){

        // Récupérer le script d'inventaire du joueur au démarrage
        GameObject joueur = GameObject.FindGameObjectWithTag("Inventory");

        if (joueur != null){
            inventory = joueur.GetComponent<Inventory>();

            if (inventory == null) Debug.LogError("Le joueur n'a pas de script Inventory attaché.");
            else Debug.Log("Iventaire recuperais");

        }
        else Debug.LogError("Aucun objet avec le tag 'Player' trouvé.");
        
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
            Debug.Log("Rocher collecté !");
            Destroy(gameObject);
        }  
        else Debug.Log("PLus de place dans l'inventaire !");

    }

    private void OnDrawGizmosSelected()
    {
        // Dessine un cercle de détection autour du rocher dans l'éditeur
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rayonDetection);
    }
}
