using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projetBDD
{
    class Commande
    {

        public static void Inserer_Commande(string nom_de_commande,string numero_de_telephone) // je suppose que le client ne choisira pas un nom qui ne se trouve pas dans la liste des recettes
        {

            

            // prendre plutôt le numero du client comme clé primaire car il différencie tous les clients

            DateTime a = DateTime.Now;

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
           "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();


            MySqlCommand command1 = connection.CreateCommand();

            command.Parameters.AddWithValue("@nom_de_commande", nom_de_commande);
            command.Parameters.AddWithValue("@num", numero_de_telephone);
            command.Parameters.AddWithValue("@date", a);



            command.CommandText = "insert into commande (nom_recette,numero_de_telephone,date_de_commande) VALUES(@nom_de_commande,@num,@date);";


            command.ExecuteNonQuery();

            connection.Close();

            // dans cette fonction on va actualiser automatiquement le nombre de commande

           Client.Increment_Commmande(nom_de_commande);

           Client.UPDATEprix(nom_de_commande);


            if (Client.Nombre_commande(nom_de_commande) < 50) // actualisation du nomnbre de commande 
            {

               Client.Increment_Remuneration1(nom_de_commande);


            }
            else
            {
               Client.Increment_Remuneration2(nom_de_commande);
            }

            Client.Update_stock_produits_final(nom_de_commande, a); // actualisation du stock 


        }
    }
}
