using UnityEngine;

public class Inventory : MonoBehaviour
{
    private KeyCode toucheInventaire = KeyCode.I;
    private int nombreDeColonnes = 8;
    private int nombreDeLignes = 5;
    public float poidsMaxInventory = 100; // Correctif : poidsMaxInventory au lieu de poidMaxInventory
    public float poidsInventory = 0; // Correctif : poidsInventory au lieu de poidInventory

    public GameObject slotPrefab;
    public Transform parentSlots;
    public Canvas canvas;
    

    private Item[,] inventory;

    private void Start()
    {
        inventory = new Item[nombreDeLignes,nombreDeColonnes];
        CreerSlotsUI();
        Debug.Log($"Dimensions de inventory : {inventory.GetLength(0)} x {inventory.GetLength(1)}");
        

    }

    void Update()
    {
        if (Input.GetKeyDown(toucheInventaire))
        {
            if (canvas.enabled == true) canvas.enabled = false;
            else canvas.enabled = true;
        }
    }

    public bool AjouterObjet(Item objet)
    {
        if (EstTropLourd(objet)) { return false; }

        // Parcourez chaque ligne
        for (int i = 0; i < nombreDeLignes; i++)
        {
            // Parcourez chaque colonne
            for (int j = 0; j < nombreDeColonnes; j++)
            {
                Debug.Log($"i: {i}, j: {j}");

                // Vérifiez si la case est vide
                if (inventory[i, j] == null)
                {
                    inventory[i, j] = objet;
                    poidsInventory += objet.itemPoids;

                    UpdateSlotImage(i, j, objet);
                    return true;  // Sortez de la méthode après avoir ajouté l'objet
                }
            }
        }

        return false;  // Si l'inventaire est plein, retournez false
    }


    public bool EstTropLourd(Item objet) // Correctif : EstTropLourd au lieu de estTropLourd
    {
        if (poidsInventory + objet.itemPoids <= poidsMaxInventory)
        {
            return false;
        }
        return true;
    }

    private void UpdateSlotImage(int i, int j, Item item)
    {
        if (i >= 0 && i < nombreDeLignes && j >= 0 && j < nombreDeColonnes)
        {
            // Calculez l'indice total du slot dans le parent
            int index = i * nombreDeColonnes + j;

            // Obtenez le slot à l'index spécifié
            GameObject slot = parentSlots.GetChild(index).gameObject;

            UnityEngine.UI.Image imageDuSlot = slot.GetComponent<UnityEngine.UI.Image>();

            imageDuSlot.sprite = item.imageItem;
        }
        else Debug.LogError("Erreur Index slot ");
    }

    private void CreerSlotsUI()
    {
        for (int i = 0; i < nombreDeLignes; i++)
        {
            for (int j = 0; j < nombreDeColonnes; j++)
            {
                GameObject nouveauSlot = Instantiate(slotPrefab, parentSlots);
                // Personnalisez le nouveauSlot si nécessaire (position, taille, etc.)
            }
        }
    }
}
