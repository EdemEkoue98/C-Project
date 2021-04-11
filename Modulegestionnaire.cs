using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projetBDD
{
    class Modulegestionnaire
    {
        public static void cdr_semaine()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
               "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();



            

            command.CommandText = "select nom from recette, cdr" +
                " where recette.numero_de_telephone = cdr.numero_de_telephone" +
                " order by nombre_de_commande desc limit 1;";



            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string nombre;
            while (reader.Read())// parcours ligne par ligne
            {
                // prix = Convert.ToInt32(Console.ReadLine());
                nombre = reader.GetString(0);  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
                Console.WriteLine(nombre);
                
            }

            reader.Close();
            command.Dispose();

         }

        public static void Top_5_Recettes()
        {

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
               "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();


            command.CommandText = "select distinct nom_recette,nombre_de_commande,nom,type,descriptif " +
                "from recette,cdr " +
                "where recette.numero_de_telephone = cdr.numero_de_telephone " +
                "order by nombre_de_commande desc limit 5;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string[] valueString = new string[reader.FieldCount];
            while (reader.Read())
            {


                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }

            reader.Close();
            command.Dispose();

        }

         
        
        public static string numero_cdr_or()
        {
            
            string numero_de_telephone = "";

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
               "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();


            command.CommandText = " select numero_de_telephone from recette order by nombre_de_commande desc limit 1;   ";


            
            

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                
                numero_de_telephone =reader.GetString(0);

                Console.WriteLine("le numero de telephone du cdr d'or est " + numero_de_telephone);

            }

            reader.Close();
            command.Dispose();

            return numero_de_telephone;
        }
        public static void Meilleur_Recettes(string numero_de_telephone)   //fonction qui affiche les 5 meilleures recettes du mec avec le numeros de telephone 

        {

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
               "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            command.Parameters.AddWithValue("@num", numero_de_telephone);

            command.CommandText = "select nom_recette " +
                "from recette" +
                " where numero_de_telephone = @num " +
                "order by nombre_de_commande desc limit 5;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string[] valueString = new string[reader.FieldCount];
            while (reader.Read())
            {


                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }

            reader.Close();
            command.Dispose();




        }


        public static void CDR_or()
        {



            string numero = numero_cdr_or();

            Console.WriteLine(numero);



            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
               "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            command.Parameters.AddWithValue("@num", numero);

            command.CommandText = "select nom,prenom from client where numero_de_telephone =@num ;";

            MySqlDataReader reader = command.ExecuteReader();

            

            string nom;
            string prenom;

            while (reader.Read())
            {

                nom = reader.GetString(0);
                prenom = reader.GetString(1);
                Console.WriteLine("le cdr d'or s'appelle "+nom + " " +prenom);



            }

            reader.Close();
            command.Dispose();
            Console.WriteLine("Ces recettes les plus commandées sont:");
            Meilleur_Recettes(numero);
        }

        public static void Supprimer_Recette()
        {
            Console.WriteLine("voici la liste des recettes et leurs prix ");

            Client.ListeCommande();

            Console.WriteLine("Laquelle voulez vous supprimer ?");


            string nom_recette = Console.ReadLine();

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



            command.Parameters.AddWithValue("@nom", nom_recette);

           



            command.CommandText = "delete from recette where nom_recette = @nom;";



            command.ExecuteNonQuery();

            maConnexion.Close();



        }

        public static void Supprimer_cdr()
        {
            ModCDR.Liste_cdr();
            Console.WriteLine("voici la liste des cdr lequel voulez vous supprimer?");
            Console.WriteLine();
            Console.WriteLine("pour supprimer un cdr veuillez rentrer son numero de telephone");
            string numero = Console.ReadLine();

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
            MySqlCommand command1 = maConnexion.CreateCommand();
            MySqlCommand command2 = maConnexion.CreateCommand();
            command.Parameters.AddWithValue("@num", numero);
            command1.Parameters.AddWithValue("@num", numero);
            command2.Parameters.AddWithValue("@num", numero);

           

            command.CommandText = "delete from cdr where numero_de_telephone = @num;";

            command1.CommandText = "delete from recette where numero_de_telephone = @num;";

            command1.ExecuteNonQuery();
            command.ExecuteNonQuery();
            
            maConnexion.Close();




        }

    }
}
