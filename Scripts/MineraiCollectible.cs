using UnityEngine;

public class MineraiCollectible : MonoBehaviour
{
    public KeyCode toucheCollecte = KeyCode.E;
    private float rayonDetection = 0.1f; // Rayon de d�tection autour du rocher
    private Inventory inventory;
    public Minerai minerai;

    private void Start(){

        // R�cup�rer le script d'inventaire du joueur au d�marrage pour ajouter les minerais
        GameObject inventaire = GameObject.FindGameObjectWithTag("Inventory");

        if (inventaire != null){
            inventory = inventaire.GetComponent<Inventory>();

            if (inventory == null) Debug.LogError("Le joueur n'a pas de script Inventory attach�.");
            else Debug.Log("Iventaire recuperais");

        }
        else Debug.LogError("Aucun objet avec le tag 'Inventory' trouv�.");
        
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
        if (!inventory.EstTropLourd(minerai)) {
            if (inventory.AjouterObjet(minerai)){
                Debug.Log("minerai collect� !");
            }
            else Debug.Log("PLus de place dans l'inventaire !");
        }
        else Debug.Log("minerai trop lourd !");
        
    }

    private void OnDrawGizmosSelected()
    {
        // Dessine un cercle de d�tection autour du rocher dans l'�diteur
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rayonDetection);
    }
}
