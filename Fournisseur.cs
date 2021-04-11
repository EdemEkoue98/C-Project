using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projetBDD
{
    class Fournisseur
    {

        public static void InsererFournisseur(string nom_fournisseur,string numero)

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



            command.Parameters.AddWithValue("@nom", nom_fournisseur);

            command.Parameters.AddWithValue("@num", numero);

           



            command.CommandText = "insert into fournisseur (nom_fournisseur,numero) VALUES(@nom,@num);";



            command.ExecuteNonQuery();

            maConnexion.Close();






        }
















    }
}
