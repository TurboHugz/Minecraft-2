using UnityEngine;

public class Inventory : MonoBehaviour{

    public KeyCode toucheInventaire = KeyCode.I;
    public int nombreDeColonnes = 2;
    public int nombreDeLignes = 2;

    private GameObject[,] inventory;


    private void Start()
    {
        inventory = new GameObject[nombreDeColonnes, nombreDeLignes];
    }

    void Update()
    {
        if (Input.GetKeyDown(toucheInventaire))
        {
            DisplayInventory();
        }
    }

    public bool ajouteObject(GameObject objet){

        for(int i = 0; i < nombreDeLignes; i++){
            for(int j = 0; j < nombreDeColonnes ; j++){
                if (inventory[i, j] == null) {
                    inventory[i, j] = objet;
                    return true;
                }
            }
        }
        return false;
    }

    private void DisplayInventory(){

        Debug.Log("Contenu de l'inventaire :");

        for (int i = 0; i < nombreDeLignes; i++){
            for (int j = 0; j < nombreDeColonnes; j++){

                GameObject objetDansCase = inventory[i, j];

                if (objetDansCase != null)
                {
                    Debug.Log($"Case [{i},{j}] : {objetDansCase.name}");
                }
                else
                {
                    Debug.Log($"Case [{i},{j}] : Vide");
                }

            }
        }

    }
}
