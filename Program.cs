using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projetBDD
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////////première partie remplissage des tables ///////////////////////


            /////////// ///////////////////REMPLISSAGE TABLE CLIENT/////////////////////////////////////////////////////////

            //Client.CreationClient("Belmont", "jean", "0769191629", "tusaisqui2"); //ça marche

            //Client.CreationClient("Bentello", "afli", "0983892893", "lksdnlkn"); //ça marche

            //Client.CreationClient("Ball", "bic", "0635357150", "zero6");

            //Client.CreationClient("Simpson", "bart", "0712345678", "zero1");

            //Client.CreationClient("Saiyen", "goku", "0612345678", "kameha");

            //Client.CreationClient("Uzumaki", "naruto", "0912345678", "rasengan");

            //Client.CreationClient("Monkey", "luffy", "0112233445", "gomugomuno");

            ////////////////// ////////////REMPLISSAGE TABLE CDR////////////////////////////////////////////////////////////////

            //ModCDR.CreerCDR("Belmont", 2, "0769191629");

            //ModCDR.CreerCDR("Monkey", 4, "0112233445");

            //ModCDR.CreerCDR("Uzumaki", 6, "0912345678");

            ///////////////////// /////////REMPLIR TABLE FOURNISSEUR////////////////////////////////////////////////

            //Fournisseur.InsererFournisseur("pates", "0990988990");

            //Fournisseur.InsererFournisseur("Sanji", "0283982984");


            ////////////////////////////REMPLIR TABLE PRODUIT//////////////////////////////////////////////

            //Produits.InsererProduit("tomate", "aucun", 5000, 300, 6000, null, null);
            //Produits.InsererProduit("salade", "aucun", 500, 100, 2000, null, null);
            //Produits.InsererProduit("oignon", "aucun", 500, 200, 1500, null, null);
            //Produits.InsererProduit("poivron", "aucun", 400, 100, 1000, null, null);
            //Produits.InsererProduit("orange", "aucun", 600, 200, 1000, null, null);
            //Produits.InsererProduit("café", "aucun", 400, 50, 800, null, null);
            //Produits.InsererProduit("farine", "aucun", 4000, 500, 8000, null, null);

            //Produits.InsererProduit("pâtes", "aucun", 500, 150, 6000, null, null);
            //Produits.InsererProduit("bolognaise", "aucun", 500, 100, 2000, null, null);
            //Produits.InsererProduit("patate", "aucun", 500, 200, 1500, null, null);
            //Produits.InsererProduit("pomme_de_terre", "aucun", 400, 100, 1000, null, null);
            //Produits.InsererProduit("glace", "aucun", 600, 200, 1000, null, null);
            //Produits.InsererProduit("chocolat", "aucun", 4000, 500, 8000, null, null);
            //Produits.InsererProduit("ketchup", "aucun", 4000, 500, 8000, null, null);

            //Produits.InsererProduit("pain", "aucun", 500, 150, 6000, null, null);
            //Produits.InsererProduit("steak_p", "aucun", 500, 100, 2000, null, null);
            //Produits.InsererProduit("entrecôte_p", "aucun", 500, 200, 1500, null, null);
            //Produits.InsererProduit("sel", null, 400, 100, 1000, null, null);
            //Produits.InsererProduit("saucisses", null, 600, 200, 1000, null, null);
            //Produits.InsererProduit("fromage", null, 4000, 500, 8000, null, null);
            //Produits.InsererProduit("huile", null, 4000, 500, 8000, null, null);

            //Produits.InsererProduit("magret", null, 500, 150, 6000, null, null);
            //Produits.InsererProduit("beurre", null, 500, 100, 2000, null, null);
            //Produits.InsererProduit("haricot_vert", null, 500, 200, 1500, null, null);
            //Produits.InsererProduit("pomme", null, 400, 100, 1000, null, null);
            //Produits.InsererProduit("pâte", null, 600, 200, 1000, null, null);
            //Produits.InsererProduit("fraise", null, 4000, 500, 8000, null, null);
            //Produits.InsererProduit("melon", null, 4000, 500, 8000, null, null);


            //Produits.InsererProduit("pastèque", null, 500, 150, 6000, null, null);
            //Produits.InsererProduit("mangue", null, 500, 100, 2000, null, null);
            //Produits.InsererProduit("cola", null, 500, 200, 1500, null, null);
            //Produits.InsererProduit("thé", null, 400, 100, 1000, null, null);
            //Produits.InsererProduit("feuilles_bissap", null, 600, 200, 1000, null, null);
            //Produits.InsererProduit("moutarde", null, 4000, 500, 8000, null, null);
            //Produits.InsererProduit("sauce_algérienne", null, 4000, 500, 8000, null, null);

            //////////////////////////// REMPLIR TABLE RECETTE///////////////////////////////////////////////////


            //ModCDR.InsererRecette("pasta", "0769191629", 12, "aucun", "aucun", 2);
            //ModCDR.InsererRecette("kebab", "0112233445", 6, "aucun", "aucun", 4);
            //ModCDR.InsererRecette("wrap", "0912345678", 8, "aucun", "aucun", 6);


            //ModCDR.InsererRecette("hamburger", "0769191629", 15, "aucun", "aucun", 2);
            //ModCDR.InsererRecette("potatoes", "0112233445", 3, "aucun", "aucun", 4);
            //ModCDR.InsererRecette("frites", "0912345678", 4, "aucun", "aucun", 6);




            //ModCDR.InsererRecette("saucisses_grillées", "0769191629", 19, "aucun", "aucun", 2);
            //ModCDR.InsererRecette("entrecôte", "0112233445", 23, "aucun", "aucun", 4);
            //ModCDR.InsererRecette("magret_de_canard", "0912345678", 25, "aucun", "aucun", 6);



            //ModCDR.InsererRecette("tiramisu", "0769191629", 5, "aucun", "aucun", 2);
            //ModCDR.InsererRecette("glace_au_chocolat", "0112233445", 5, "aucun", "aucun", 4);
            //ModCDR.InsererRecette("salade_de_fruit", "0912345678", 8, "aucun", "aucun", 6);



            //ModCDR.InsererRecette("cola", "0769191629", 1, "aucun", "aucun", 2);
            //ModCDR.InsererRecette("ice_tea", "0112233445", 3, "aucun", "aucun", 4);
            //ModCDR.InsererRecette("bissap", "0912345678", 5, "aucun", "aucun", 6);


            ///////////////////////REMPLIR TABLE UTILISE//////////////////////////

            //Utilise.Inserer_utilise("tomate", "pasta", 2);
            //Utilise.Inserer_utilise("pâtes", "pasta", 1);
            //Utilise.Inserer_utilise("huile", "pasta", 1);
            //Utilise.Inserer_utilise("bolognaise", "pasta", 1);


            //Utilise.Inserer_utilise("salade", "kebab", 1);
            //Utilise.Inserer_utilise("tomate", "kebab", 1);
            //Utilise.Inserer_utilise("oignon", "kebab", 1);
            //Utilise.Inserer_utilise("pain", "kebab", 1);

            //Utilise.Inserer_utilise("pâte", "wrap", 1);
            //Utilise.Inserer_utilise("salade", "wrap", 2);
            //Utilise.Inserer_utilise("tomate", "wrap", 1);
            //Utilise.Inserer_utilise("oignon", "wrap", 1);


            //Utilise.Inserer_utilise("pain", "hamburger", 2);
            //Utilise.Inserer_utilise("fromage", "hamburger", 1);
            //Utilise.Inserer_utilise("steak_p", "hamburger", 2);
            //Utilise.Inserer_utilise("salade", "hamburger", 2);

            //Utilise.Inserer_utilise("huile", "potatoes", 1);
            //Utilise.Inserer_utilise("pomme_de_terre", "potatoes", 6);
            //Utilise.Inserer_utilise("sel", "potatoes", 1);
            //Utilise.Inserer_utilise("ketchup", "potatoes", 1);

            //Utilise.Inserer_utilise("pomme_de_terre", "frites", 6);
            //Utilise.Inserer_utilise("huile", "frites", 1);
            //Utilise.Inserer_utilise("sel", "frites", 1);
            //Utilise.Inserer_utilise("ketchup", "frites", 1);

            //Utilise.Inserer_utilise("saucisses", "saucisses_grillées", 6);
            //Utilise.Inserer_utilise("huile", "saucisses_grillées", 1);
            //Utilise.Inserer_utilise("moutarde", "saucisses_grillées", 1);
            //Utilise.Inserer_utilise("ketchup", "saucisses_grillées", 2);

            //Utilise.Inserer_utilise("entrecôte_p", "entrecôte", 1);
            //Utilise.Inserer_utilise("huile", "entrecôte", 1);
            //Utilise.Inserer_utilise("salade", "entrecôte", 3);
            //Utilise.Inserer_utilise("sel", "entrecôte", 1);

            //Utilise.Inserer_utilise("magret", "magret_de_canard", 3);
            //Utilise.Inserer_utilise("huile", "magret_de_canard", 1);
            //Utilise.Inserer_utilise("salade", "magret_de_canard", 2);
            //Utilise.Inserer_utilise("haricot_vert", "magret_de_canard", 4);

            //Utilise.Inserer_utilise("chocolat", "tiramisu", 2);
            //Utilise.Inserer_utilise("glace", "tiramisu", 1);


            //Utilise.Inserer_utilise("chocolat", "glace_au_chocolat", 6);
            //Utilise.Inserer_utilise("glace", "glace_au_chocolat", 4);


            //Utilise.Inserer_utilise("fraise", "salade_de_fruit", 1);
            //Utilise.Inserer_utilise("mangue", "salade_de_fruit", 1);
            //Utilise.Inserer_utilise("pastèque", "salade_de_fruit", 1);
            //Utilise.Inserer_utilise("melon", "salade_de_fruit", 1);



            //Utilise.Inserer_utilise("cola", "cola", 6);
            //Utilise.Inserer_utilise("glace", "cola", 3);


            //Utilise.Inserer_utilise("thé", "ice_tea", 3);
            //Utilise.Inserer_utilise("glace", "ice_tea", 2);


            //Utilise.Inserer_utilise("feuilles_bissap", "bissap", 6);
            //Utilise.Inserer_utilise("glace", "bissap", 6);


            //////////////////remplir COMMANDE//////////////////////

            //Commande.Inserer_Commande("pasta", "0983892893");
            //Commande.Inserer_Commande("frites", "0983892893");
            //Commande.Inserer_Commande("potatoes", "0983892893");
            //Commande.Inserer_Commande("hamburger", "0983892893");
            //Commande.Inserer_Commande("cola", "0983892893");
            //Commande.Inserer_Commande("tiramisu", "0983892893");
            //Commande.Inserer_Commande("salade_de_fruit", "0983892893");

            //Commande.Inserer_Commande("pasta", "0635357150");
            //Commande.Inserer_Commande("pasta", "0635357150");
            //Commande.Inserer_Commande("pasta", "0635357150");
            //Commande.Inserer_Commande("pasta", "0635357150");
            //Commande.Inserer_Commande("frites", "0635357150");
            //Commande.Inserer_Commande("frites", "0635357150");
            //Commande.Inserer_Commande("cola", "0635357150");
            //Commande.Inserer_Commande("bissap", "0635357150");
            //Commande.Inserer_Commande("bissap", "0635357150");
            //Commande.Inserer_Commande("magret_de_canard", "0635357150");


            //Commande.Inserer_Commande("pasta", "0712345678");
            //Commande.Inserer_Commande("pasta", "0712345678");
            //Commande.Inserer_Commande("pasta", "0712345678");
            //Commande.Inserer_Commande("pasta", "0712345678");
            //Commande.Inserer_Commande("kebab", "0712345678");
            //Commande.Inserer_Commande("kebab", "0712345678");
            //Commande.Inserer_Commande("kebab", "0712345678");
            //Commande.Inserer_Commande("kebab", "0712345678");
            //Commande.Inserer_Commande("kebab", "0712345678");
            //Commande.Inserer_Commande("magret_de_canard", "0712345678");




            //Commande.Inserer_Commande("pasta", "0612345678");
            //Commande.Inserer_Commande("pasta", "0612345678");
            //Commande.Inserer_Commande("pasta", "0612345678");
            //Commande.Inserer_Commande("pasta", "0612345678");
            //Commande.Inserer_Commande("wrap", "0612345678");
            //Commande.Inserer_Commande("wrap", "0612345678");
            //Commande.Inserer_Commande("wrap", "0612345678");
            //Commande.Inserer_Commande("wrap", "0612345678");
            //Commande.Inserer_Commande("bissap", "0612345678");
            //Commande.Inserer_Commande("magret_de_canard", "0612345678");

            //Commande.Inserer_Commande("pasta", "0769191629");
            //Commande.Inserer_Commande("pasta", "0769191629");
            //Commande.Inserer_Commande("pasta", "0769191629");
            //Commande.Inserer_Commande("entrecôte", "0769191629");
            //Commande.Inserer_Commande("entrecôte", "0769191629");
            //Commande.Inserer_Commande("frites", "0769191629");
            //Commande.Inserer_Commande("cola", "0769191629");
            //Commande.Inserer_Commande("bissap", "0769191629");
            //Commande.Inserer_Commande("bissap", "0769191629");
            //Commande.Inserer_Commande("magret_de_canard", "0769191629");


            ////////////////MODULE CLIENT////////////////////////

            //1- identification 
            //Client.Identification();

            //2 - commande
            //Client.Choixcommande("0769191629"); // fonction qui permet de commander en prenant en paramètre le numero de telephone


            ////////////////MODULE CDR///////////////////////////////////////

            //1- identication et accès aux fonctionnalités de cdr un cdr est un cuisinier par définition

            //ModCDR.Identification_cdr();

            // 2- solde cook du cdr 

            //ModCDR.SoldeCook();

            // 3- affichage de la liste de recettes du cdr

            //ModCDR.ListeRecettes_du_cdr("0769191629");


            ///////////MODULE GESTIONNAIRE/////////////////

            // 1 - le cdr de la semaine 

            //Modulegestionnaire.cdr_semaine();

            //2 - les 5 recettes le splus commandées 

            // Modulegestionnaire.Top_5_Recettes();

            //3- cdr d'or 

            //Modulegestionnaire.CDR_or();

            //4- Supprimer un cdr 

            //Modulegestionnaire.Supprimer_cdr();

            //5- supprimer une recette


            //Modulegestionnaire.Supprimer_Recette();

            /////////////MODULE VALIDATION PAR L'EVALUATEUR//////////////////////

            // 1- nombre de cdr 
            //Modulevalidation.Nombre_cdr(); 

            //2- affichage des recettes utilisant "tomate" comme produit et la quantité utilisée
            //Modulevalidation.ListeRecette("tomate"); 

            //3-// donne le nombre de client
            //Modulevalidation.Nombre_de_client(); 

            //4-nombre de recette
            //Modulevalidation.Nombre_recettes(); 

            //5-// liste des produits dont la quantité <=2
            //Modulevalidation.ListeProduits();   

            //6-// liste des cdr avec le nombre de total de commande de leur recette

            //Modulevalidation.Liste_cdr_et_commande_total(); 
            Console.ReadKey();
        }
    }
}
