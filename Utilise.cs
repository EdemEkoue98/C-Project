using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projetBDD
{
    class Utilise
    {
        public static void Inserer_utilise(string nom_produits,string nom_recette,double quantite)


        {

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=cooking;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }


            MySqlCommand command = maConnexion.CreateCommand();



            command.Parameters.AddWithValue("@nom_recette", nom_recette);
            
            command.Parameters.AddWithValue("@quantite", quantite);
            command.Parameters.AddWithValue("@nom", nom_produits);
           


            command.CommandText = "insert into utilise (nom_produits,nom_recette,quantite)" +
                                          " VALUES(@nom,@nom_recette,@quantite);";





            command.ExecuteNonQuery();

            maConnexion.Close();








        }



    }
}
