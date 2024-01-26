using UnityEngine;

public class MineraiCollectible : MonoBehaviour
{
    public KeyCode toucheCollecte = KeyCode.E;
    private float rayonDetection = 0.1f; // Rayon de détection autour du rocher
    private Inventory inventory;
    public Minerai minerai;

    private void Start(){

        // Récupérer le script d'inventaire du joueur au démarrage pour ajouter les minerais
        GameObject inventaire = GameObject.FindGameObjectWithTag("Inventory");

        if (inventaire != null){
            inventory = inventaire.GetComponent<Inventory>();

            if (inventory == null) Debug.LogError("Le joueur n'a pas de script Inventory attaché.");
            else Debug.Log("Iventaire recuperais");

        }
        else Debug.LogError("Aucun objet avec le tag 'Inventory' trouvé.");
        
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
                Debug.Log("minerai collecté !");
            }
            else Debug.Log("PLus de place dans l'inventaire !");
        }
        else Debug.Log("minerai trop lourd !");
        
    }

    private void OnDrawGizmosSelected()
    {
        // Dessine un cercle de détection autour du rocher dans l'éditeur
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rayonDetection);
    }
}
