using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace projetBDD
{
    class Modulevalidation
    {

        public static void Nombre_de_client()
        {



            
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();


            command.CommandText = "select count(*) from client;";



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

        public static void Nombre_cdr()

        {




            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();


            command.CommandText = "select count(numero_de_telephone) from cdr;";





           

            MySqlDataReader reader = command.ExecuteReader();

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




        public static void Noms_cdr_et_commande()

        {




            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();


            command.CommandText = "SELECT nom,nombre_de_commande FROM cdr NATURAL JOIN recette; ";







            MySqlDataReader reader = command.ExecuteReader();

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


        public static void Nombre_recettes()
        {




            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();


            command.CommandText = "SELECT count(*) from recette; ";







            MySqlDataReader reader = command.ExecuteReader();

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


        public static void ListeProduits()
        {



            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();


            command.CommandText = "select nom_produits from produits where stock_mini <= 2; ";


            MySqlDataReader reader = command.ExecuteReader();

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



        public static void ListeRecette(string nom_produits)
        {






            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            command.Parameters.AddWithValue("@nom", nom_produits);

            command.CommandText = "  select nom_recette,quantite from utilise where nom_produits = @nom; ";


            MySqlDataReader reader = command.ExecuteReader();

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


        
     
     
        
        public static int Nombre_commande_total(string numero_de_telephone)
        {


            int a = 0;
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();



            command.Parameters.AddWithValue("@nom", numero_de_telephone);

            command.CommandText = "select sum(nombre_de_commande) from recette where numero_de_telephone = @nom;";



            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string nombre;
            while (reader.Read())// parcours ligne par ligne
            {
                // prix = Convert.ToInt32(Console.ReadLine());
                nombre = reader.GetString(0);  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
                
                a = Convert.ToInt32(nombre);
            }

            reader.Close();
            command.Dispose();

            return a;






         } // fonction qui donne le nombre de commande total de commande faite pour un cdr identifié par son numero de telephone

        // fonction qui retourne la liste cdr avec leur numero de telephone

        public static void Liste_cdr_et_commande_total()
        {

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();






            command.CommandText = "select nom,numero_de_telephone from cdr ; ";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            List<string> numero = new List<string>();
            List<string> name = new List<string>();

            
            while (reader.Read())// parcours ligne par ligne
            {
                // prix = Convert.ToInt32(Console.ReadLine());
                name.Add( reader.GetString(0));  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
                numero.Add(reader.GetString(1));
            }

            
            for(int i=0;i<name.Count();i++ )
            {   
                
                Console.WriteLine(name[i] + " " + numero[i]+ " "+ Nombre_commande_total(numero[i]) );
                Console.WriteLine();
            }






            reader.Close();
            command.Dispose();


        }





    }

}
