using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace projetBDD
{
    class Client
    {
        



        public Client()
        {

        }


        public static void CreationClient(string nom, string prenom, string numero_de_telephone, string mot_de_passe) /// programme pour créer un client 
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

            

                 command.Parameters.AddWithValue("@nom", nom);

                     command.Parameters.AddWithValue("@num", numero_de_telephone);
                       command.Parameters.AddWithValue("@mot", mot_de_passe);
                     command.Parameters.AddWithValue("@prenom", prenom);



            

            

            command.CommandText = "insert into client (numero_de_telephone,nom,prenom,mot_de_passe)values(@num,@nom,@prenom,@mot);";



            command.ExecuteNonQuery();

            maConnexion.Close();


        }



        public static int Rechercheclient(string numero_de_telephone) 
        {
            int a = 0;
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            MySqlCommand command1 = connection.CreateCommand();


            command.Parameters.AddWithValue("@num", numero_de_telephone);
            
            command.CommandText = " select count(*) from client where numero_de_telephone= @num ; ";

           


            MySqlDataReader reader = command.ExecuteReader();

            string nombre;
            while (reader.Read())// parcours ligne par ligne
            {
                // prix = Convert.ToInt32(Console.ReadLine());
                nombre = reader.GetString(0);  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
                Console.WriteLine(nombre);
                a = Convert.ToInt32(nombre);
            }

            reader.Close();
            command.Dispose();

            return a;

            
        
        } // voir si un client se trouve dans la table il donne juste son numero de téléphone 



        public static void Identification()
        {

            string nom;
            string numero_de_telephone;
            string mot_de_passe;
            string prenom;

            Console.WriteLine("quelle est votre nom?");
            nom = Console.ReadLine();

            Console.WriteLine("quelle est votre prenom");
            prenom = Console.ReadLine();

            Console.WriteLine("quelle est votre numero_de_telephone?");
            numero_de_telephone = Console.ReadLine();

            if (Rechercheclient(numero_de_telephone) == 1)
            {

                Console.WriteLine("vous êtes déjà enregistré nous allons prendre votre commande");
                Console.WriteLine("Nous allons prendre votre commande voici la liste des recettes");
                Console.WriteLine();

                Choixcommande(numero_de_telephone);


            }
            else
            {

                Console.WriteLine("vous n'êtes pas encore enregistré,nous allons vous enregistrer");
                Console.WriteLine("saisir un mot de passe");

                mot_de_passe = Console.ReadLine();

                Console.WriteLine("vous venez d'être enregistré");
              

               

                CreationClient(nom,prenom,numero_de_telephone,mot_de_passe);

                Console.WriteLine("voulez vous commander ? true or false ?");

                bool res = Convert.ToBoolean(Console.ReadLine());

                if (res ==true)
                {

                    Choixcommande(numero_de_telephone);
                }


            }



        }



        public static void ListeCommande() // cette fonction affiche la liste des commandes possibles
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
           "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "select nom_recette,prix from recette;";

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

        }


        public static void AjoutCommande(string numero_de_telephone) // je suppose que le client ne choisira pas un nom qui ne se trouve pas dans la liste des recettes
        {

            string nom_de_commande;

            

            Console.WriteLine("quelle recette avez vous choisit?");

            nom_de_commande = Console.ReadLine();

            
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

            Increment_Commmande(nom_de_commande);

            UPDATEprix(nom_de_commande);


            if (Nombre_commande(nom_de_commande) < 50) // actualisation du nomnbre de commande 
            {

                Increment_Remuneration1(nom_de_commande);


            }
            else
            {
                Increment_Remuneration2(nom_de_commande);
            }

            Update_stock_produits_final(nom_de_commande, a); // actualisation du stock 


        }

        public static void Choixcommande(string numero_de_telephone) // c'est cette fonction qu'on va utiliser pour commander 
        {
            bool res = false;

            do
            {


                ListeCommande();



                AjoutCommande(numero_de_telephone);

                Console.WriteLine("voulez vous encore commander? true or false");

                bool decision = Convert.ToBoolean(Console.ReadLine());

                if (decision == true) { res = true; }

                else { res = false; }


            } while (res == true);



        }


        public static void Increment_Commmande(string nom_recette)
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



            command.Parameters.AddWithValue("@nom", nom_recette);

            

            command.CommandText = "update recette " +
                "set nombre_de_commande = nombre_de_commande+1" +
                " where nom_recette=@nom;";



            command.ExecuteNonQuery();

            maConnexion.Close();

        } //fonction qui actualise le nombre_de_commande

        public static void Increment_Remuneration1(string nom_recette)
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



            command.Parameters.AddWithValue("@nom", nom_recette);



            command.CommandText = "update recette " +
                "set remuneration = remuneration+2" +
                " where nom_recette=@nom;";



            command.ExecuteNonQuery();

            maConnexion.Close();






        } // une fonction qui actualise la remuneration lorque le nombre de commande <=50


        public static void Increment_Remuneration2(string nom_recette)
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



            command.Parameters.AddWithValue("@nom", nom_recette);



            command.CommandText = "update recette " +
                "set remuneration = remuneration+4" +
                " where nom_recette=@nom;";



            command.ExecuteNonQuery();

            maConnexion.Close();



        } // fonction qui incremente la rémuneration si 

        public static void UPDATEprix(string nom_recette) /// actualisation du prix et de la rémunération
        {

            if (Nombre_commande(nom_recette) == 10)
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



                command.Parameters.AddWithValue("@nom", nom_recette);



                command.CommandText = "update recette " +
                    "set prix = prix+2" +
                    " where nom_recette=@nom;";



                command.ExecuteNonQuery();

                maConnexion.Close();


            }

            if (Nombre_commande(nom_recette) == 50)
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

               


                command.Parameters.AddWithValue("@nom", nom_recette);

                

                command.CommandText = "update recette " +
                    "set prix = prix + 5" +
                    " where nom_recette=@nom;";


                command.ExecuteNonQuery();

                maConnexion.Close();



            }



            // une fonction qui récupère le prix de la commande et qui donne ce qu'il faut payer 

        } // fonction qui actualise le prix d'une recette

        public static int Nombre_commande(string nom_recette)
        {


            int a = 0;
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();



            command.Parameters.AddWithValue("@nom", nom_recette);

            command.CommandText = "select nombre_de_commande from recette where nom_recette=@nom;";



            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string nombre;
            while (reader.Read())// parcours ligne par ligne
            {
                // prix = Convert.ToInt32(Console.ReadLine());
                nombre = reader.GetString(0);  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
                Console.WriteLine(nombre);
                a = Convert.ToInt32(nombre);
            }

            reader.Close();
            command.Dispose();

            return a;






        } // fonction qui donne le nombre de commande

        // la fonction ci-dessous va update le stock des produits mais aussi la date de leur utilisation et leur stock actuel
        public static void Update_stock_produits_final(string nom_recette,DateTime a)
        {


            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
           "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();


            command.Parameters.AddWithValue("@nom", nom_recette);

           
            command.CommandText = "select nom_produits,quantite from utilise where nom_recette= @nom;";

            


            List<string> nom_produits = new List<string>();
            List<int> quantite = new List<int>();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())   
            {
                nom_produits.Add(reader.GetString(0)); 
                quantite.Add(reader.GetInt32(1)); 
                
            }

            List<int> s = new List<int>();

            List<int> new_stock = new List<int>();
            for (int i = 0; i < quantite.Count(); i++)
            {
                s.Add(Stock_actuel(nom_produits[i]));
                new_stock.Add(s[i] - quantite[i]);
                Console.WriteLine(nom_produits[i] + " " + quantite[i] + " " + s[i]+ " " + new_stock[i]);
                Update_Stock_1(nom_produits[i], new_stock[i]);




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


                MySqlCommand command1 = maConnexion.CreateCommand();



                command1.Parameters.AddWithValue("@date", a);
                command1.Parameters.AddWithValue("@nom",nom_produits[i]);


                command1.CommandText = "update produits " +
                    "set date_utilisation = @date" +
                    " where nom_produits = @nom;";



                command1.ExecuteNonQuery();

                maConnexion.Close();

            }


            reader.Close();
            command.Dispose();
            
        }

        public static int Stock_actuel(string nom_produits) // fonction qui va renvoyer le stock actuel du produit
        {
            int a = 0;

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
           "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            command.Parameters.AddWithValue("@nom", nom_produits);

            command.CommandText = "select stock_actuel from produits where nom_produits = @nom;";

            MySqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                
                a = reader.GetInt32(0);

            }

            return a;
        }

        public static void Update_Stock_1(string nom_produits,int stock_actuel)
        {

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
           "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            command.Parameters.AddWithValue("@nom", nom_produits);

            command.Parameters.AddWithValue("@stock", stock_actuel);

            command.CommandText = "update produits " +
                "set stock_actuel = @stock" +
                " where nom_produits = @nom;";



            command.ExecuteNonQuery();

           connection.Close();


        }  // une fonction qui va update et qui prend en paramètre le nom de l'aliment et son stock actuel

        public static int prix_recette(string nom_commande)
        {


            int a = 0;
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();



            command.Parameters.AddWithValue("@nom", nom_commande);

            command.CommandText = "select prix from recette where nom_recette=@nom;";



            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string nombre;
            while (reader.Read())// parcours ligne par ligne
            {
                // prix = Convert.ToInt32(Console.ReadLine());
                nombre = reader.GetString(0);  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
                Console.WriteLine(nombre);
                a = Convert.ToInt32(nombre);
            }

            reader.Close();
            command.Dispose();

            return a;




        }

        

    }
}
