using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace projetBDD
{
    class Produits
    {
        /// on va ajouter des produits dans la table 
        /// 

        public static void InsererProduit(string nom_produits, string categorie, float stock_actuel, float stock_mini, float stock_maxi, string reference_du_fournisseur, string date_utilisation)
        {

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
           "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            command.Parameters.AddWithValue("@nom", nom_produits);
            command.Parameters.AddWithValue("@cat", categorie);
            command.Parameters.AddWithValue("@sactu", stock_actuel);
            command.Parameters.AddWithValue("@smax", stock_maxi);

            command.Parameters.AddWithValue("@smini", stock_mini);
            command.Parameters.AddWithValue("@ref", reference_du_fournisseur);
            command.Parameters.AddWithValue("@date", date_utilisation);

            command.CommandText = "insert into produits (nom_produits,categorie,stock_actuel,stock_mini,stock_max,reference_du_fournisseur,date_utilisation) " +
                "VALUES(@nom,@cat,@sactu,@smini,@smax,@ref,@date);";




            command.ExecuteNonQuery();

            connection.Close();






        }







    }
}
