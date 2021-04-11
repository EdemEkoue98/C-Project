using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projetBDD
{
    class ModCDR
    {
        public static void CreerCDR(string nom, int solde, string numero_de_telephone) // creer un cdr

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

            command.Parameters.AddWithValue("@solde", solde);

            command.Parameters.AddWithValue("@numero_de_telephone", numero_de_telephone);



            command.CommandText = "insert into cdr (nom,numero_de_telephone,solde_cook) VALUES(@nom,@numero_de_telephone,@solde);";



            command.ExecuteNonQuery();

            maConnexion.Close();

        }

        /// le programme si dessous me permet de verifier si le numero de télephone de la personne se trouve dans la table des cdr
        public static int VerifieCDR(string numero_de_telephone) // j'ai décidé de travailler sur les numéros de téléphones car il différencie vraiment les personnes
        {


            int a = 0;
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();



            command.Parameters.AddWithValue("@num", numero_de_telephone);

            command.CommandText = "select count(*) from cdr where numero_de_telephone=@num;";



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


            // Le programme retourne 1 si le numero de tel est présent dans la table et donc c'est un cdr
        }



        // le programme suivant va nous dire directement si une personne est un cdr ou pas en fonction de son numero de téléphone




        public static void Identification_cdr()
        {
            string s;


            Console.WriteLine("quelle est votre numero de téléphone?");

            s = Console.ReadLine();

            if (VerifieCDR(s) == 1)
            {
                Console.WriteLine("vous êtes un cdr ");

                Console.WriteLine("voulez vous creer une recette? ou Commander? true or false ? ");

                bool res = Convert.ToBoolean(Console.ReadLine());

                if (res==true )
                {
                    SaisieRecette2(s);
                }
                else
                {
                    Client.Choixcommande(s);
                }


            }

            else
            {
                Console.WriteLine("vous n'êtes pas un cdr");

                Console.WriteLine("voulez vous vous enregistrer? True or False?");


                bool res;

                res = Convert.ToBoolean(Console.ReadLine());

                if (res == true)
                {
                    string nom;
                    string prenom;

                    string mot_de_passe;


                    Console.WriteLine("quelle est votre nom?");
                    nom = Console.ReadLine();

                    Console.WriteLine("quelle est votre prenom?");
                    prenom = Console.ReadLine();



                    Console.WriteLine("quelle est votre mot_de_passe?");

                    mot_de_passe = Console.ReadLine();




                    Client.CreationClient(nom, prenom, s, mot_de_passe);

                    ModCDR.CreerCDR(nom, 0, s);

                    Console.WriteLine("vous êtes maintenant un cdr");
                }



            }





        }


        public static void SoldeCook()
        {


            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            Console.WriteLine("veuillez rentrer le numero_de_telephone du cdr dont vous voulez consulter le solde");

            string n = Console.ReadLine();

            command.Parameters.AddWithValue("@num", n);



            command.CommandText = "select solde_cook from cdr where numero_de_telephone=@num;";

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





        }  // nous donne le solde cook d'un cdr

        public static void Liste_cdr()
        {

            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();






            command.CommandText = "select * from cdr ; ";

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

        public static void ListeRecettes() // affiche la liste des recettes et leur nombre de commande
        {



            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();






            command.CommandText = "select nom_recette,nombre_de_commande from recette, cdr where recette.numero_de_telephone = cdr.numero_de_telephone; ";

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



        public static void ListeRecettes_du_cdr(string numero_de_telephone) // affiche la liste de ses recettes et leur nombre de commande
        {



            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();



            command.Parameters.AddWithValue("@num", numero_de_telephone);


            command.CommandText = "select nom_recette,nombre_de_commande from recette where numero_de_telephone = @num; ";

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


        // pour creer une recette il faut connaître le numero de telephone et le solde cook

        public static void InsererRecette(string nom_recette, string numero_de_telephone, int prix, string descriptif, string type, int solde_cook)
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
            command.Parameters.AddWithValue("@solde", solde_cook);
            command.Parameters.AddWithValue("@prix", prix);
            command.Parameters.AddWithValue("@descriptif", descriptif);
            command.Parameters.AddWithValue("@type", type);
            command.Parameters.AddWithValue("@num", numero_de_telephone);



            command.CommandText = "insert into recette (nom_recette,descriptif,nombre_de_commande,prix,remuneration,numero_de_telephone,solde_cook,type)" +
                                          " VALUES(@nom_recette,@descriptif,0,@prix,0,@num,@solde,@type);";





            command.ExecuteNonQuery();

            maConnexion.Close();



        }

        // creer un recette simplement en insérant les valeurs dans la table recette 

        // maintenant on va essayer de saisir une recette c'est à dire demander au cdr les ingrédients dont il a besoin
        // pour sa recette et les intégrer dans utilise avec la quantité nécéssaire




        public static void SaisieRecette1() // est la fonction qui permet de saisir une recette avec les ingrédients

        {


            Console.WriteLine("comment voulez vous appeller votre nouvelle recette?");

            string nom_de_recette = Console.ReadLine();

            Console.WriteLine("quelle est le prix de votre recette?");

            int prixdevente = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("veuillez ajouter un descriptif à votre recette");
            string descriptif = Console.ReadLine();


            Console.WriteLine("veuillez donner votre numero de telephone");
            string numero_de_telephone = Console.ReadLine();

            Console.WriteLine("quelle est le type de votre recette?");

            string type = Console.ReadLine();

            Console.WriteLine("quelle est votre solde cook actuelle?");

            int solde_cook =Convert.ToInt32( Console.ReadLine());

            InsererRecette(nom_de_recette, numero_de_telephone, prixdevente, descriptif, type, solde_cook);

            saisieIngrédient(nom_de_recette);

        }


        public static void SaisieRecette2(string numero_de_telephone) // est la fonction qui permet de saisir une recette avec les ingrédients

        {


            Console.WriteLine("comment voulez vous appeller votre nouvelle recette?");

            string nom_de_recette = Console.ReadLine();

            Console.WriteLine("quelle est le prix de votre recette?");

            int prixdevente = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("veuillez ajouter un descriptif à votre recette");
            string descriptif = Console.ReadLine();


        
            Console.WriteLine("quelle est le type de votre recette?");

            string type = Console.ReadLine();

            Console.WriteLine("quelle est votre solde cook actuelle?");

            int solde_cook = Convert.ToInt32(Console.ReadLine());

            InsererRecette(nom_de_recette, numero_de_telephone, prixdevente, descriptif, type, solde_cook);

            saisieIngrédient(nom_de_recette);

        }


        public static void saisieIngrédient(string nom_de_recette) // pour utiliser cette fonction il faudrait qu'il y'ait les ingrédients dans la table produit
        {


            List<string> ingredient = new List<string>();
            List<int> quantite = new List<int>();

            bool res = false;


            do
            {

                Console.WriteLine("quelles est l' ingrédient de votre recette que vous voulez ajouter veuilez saisir son nom");

                ingredient.Add(Console.ReadLine());

                Console.WriteLine("en quelle quantité en avez vous besoin");

                quantite.Add(Convert.ToInt32(Console.ReadLine()));

                Console.WriteLine("voulez vous ajouter d'autres ingrédients ? True or false?");

                bool decison = Convert.ToBoolean(Console.ReadLine());

                if (decison == true) { res = true; }
                else { res = false; }


            } while (res == true);


            /// affichage des produits utilisés le but c'est de les rentrer dans utilise

            for (int i = 0; i < ingredient.Count; i++)
            {
                Console.Write("ingrédient  " + i + "   " + "quantité");
                Console.WriteLine();
                Console.Write(ingredient[i] + "           " + quantite[i]);

                Console.WriteLine();
            }


            //// avec cette fonction je vais recupérer les élements qu'il faut pour creer une recette dans la table 
            ///recette 
            ///ensuite j'aurais dans la table utilise le nom de la recette et la quantité utilisé
            ///avec cela on aura créer une recette et tous les produits qu'il nous faut 


            /// ouverture du canal de connexion a la bdd
            /// 


            for (int i = 0; i < ingredient.Count; i++)
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

                //avec cette fonction je peux avoir la liste des ingrédients et leur quantité

                MySqlCommand command = maConnexion.CreateCommand();


                command.Parameters.AddWithValue("@nom", nom_de_recette);
                command.Parameters.AddWithValue("@quantite", quantite[i]);
                command.Parameters.AddWithValue("@nom_produits", ingredient[i]);



                command.CommandText = "insert into utilise (nom_produits,nom_recette,quantite)values(@nom_produits,@nom,@quantite);";



                command.ExecuteNonQuery();

                maConnexion.Close();



            }

            // il faut une fonction que lorsqu'on commande actualise le solde cook 
            // et lorsqu'on commande 



        }


        //public static void Update_solde_cook(string numero_de_telephone,double solde)
        //{



        //    string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
        //   "UID=root;PASSWORD=root";

        //    MySqlConnection connection = new MySqlConnection(connectionString);
        //    connection.Open();

        //    MySqlCommand command = connection.CreateCommand();
        //    MySqlCommand command1 = connection.CreateCommand();

        //    command.Parameters.AddWithValue("@num", numero_de_telephone);
        //    command.Parameters.AddWithValue("@solde", solde);
        //    command1.Parameters.AddWithValue("@num",numero_de_telephone );
        //    command1.Parameters.AddWithValue("@solde", solde);
           
            
        //    command.CommandText = "update cdr " +
        //        "set solde_cook = @solde" +
        //        " where numero_de_telephone = @num;";




        //    command1.CommandText = "update recette " +
        //        "set solde_cook = @solde" +
        //        " where numero_de_telephone = @num;";



        //    command.ExecuteNonQuery();
        //    command1.ExecuteNonQuery();
        //    connection.Close();




        //}

            // ça ne marche pas  // ça ne marche pas

        public static int Solde_Cook(string numero_de_telephone)
        {

            int a = 0;
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=cooking;" +
                "UID=root;PASSWORD=root";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();


            command.Parameters.AddWithValue("@num", numero_de_telephone);



            command.CommandText = "select solde_cook from cdr where numero_de_telephone=@num;";

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
