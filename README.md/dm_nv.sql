#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------


#------------------------------------------------------------
# Table: client
#------------------------------------------------------------
CREATE DATABASE Cooking;

use Cooking;

set sql_safe_updates=0;

CREATE TABLE client(
        nom                 Varchar (50) NOT NULL ,
        prenom              Varchar (50) NOT NULL ,
        numero_de_telephone Varchar (50) NOT NULL ,
        mot_de_passe        Varchar (50) NOT NULL
	,CONSTRAINT client_PK PRIMARY KEY (nom)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: CDR
#------------------------------------------------------------

CREATE TABLE CDR(
        nom                 Varchar (50) NOT NULL ,
        solde_cook          Int NOT NULL ,
        nombre_de_recettes  Int NOT NULL ,
        prenom              Varchar (50) NOT NULL ,
        numero_de_telephone Varchar (50) NOT NULL ,
        mot_de_passe        Varchar (50) NOT NULL
	,CONSTRAINT CDR_PK PRIMARY KEY (nom,solde_cook)

	,CONSTRAINT CDR_client_FK FOREIGN KEY (nom) REFERENCES client(nom)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Recette
#------------------------------------------------------------

CREATE TABLE Recette(
        nom                Varchar (256) NOT NULL ,
        type               Varchar (256) NOT NULL ,
        descriptif         Text NOT NULL ,
        nombre_de_commande Int NOT NULL ,
        prix               Int NOT NULL ,
        remuneration       Int NOT NULL ,
        nom_CDR            Varchar (50) NOT NULL ,
        solde_cook_CDR     Int NOT NULL
	,CONSTRAINT Recette_PK PRIMARY KEY (nom)

	,CONSTRAINT Recette_CDR_FK FOREIGN KEY (nom_CDR,solde_cook_CDR) REFERENCES CDR(nom,solde_cook)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Produits
#------------------------------------------------------------

CREATE TABLE Produits(
        nom                      Varchar (256) NOT NULL ,
        categorie                Char (5) NOT NULL ,
        stock_actuel             Varchar (256) NOT NULL ,
        stock_mini               Float NOT NULL ,
        stock_max                Float NOT NULL ,
        date_utilisation         Date NOT NULL ,
        nom_du_fournisseur       Varchar (256) NOT NULL ,
        reference_du_fournisseur Varchar (256) NOT NULL
	,CONSTRAINT Produits_PK PRIMARY KEY (nom)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: fournisseur 
#------------------------------------------------------------

CREATE TABLE fournisseur(
        nom                 Varchar (256) NOT NULL ,
        numero_de_telephone Int NOT NULL
	,CONSTRAINT fournisseur_PK PRIMARY KEY (nom)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: utilise
#------------------------------------------------------------

CREATE TABLE utilise(
        nom         Varchar (256) NOT NULL ,
        nom_Recette Varchar (256) NOT NULL ,
        quantite    Int NOT NULL
	,CONSTRAINT utilise_PK PRIMARY KEY (nom,nom_Recette)

	,CONSTRAINT utilise_Produits_FK FOREIGN KEY (nom) REFERENCES Produits(nom)
	,CONSTRAINT utilise_Recette0_FK FOREIGN KEY (nom_Recette) REFERENCES Recette(nom)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: fournit
#------------------------------------------------------------

CREATE TABLE fournit(
        nom              Varchar (256) NOT NULL ,
        nom_fournisseur  Varchar (256) NOT NULL ,
        date_recu        Date NOT NULL
	,CONSTRAINT fournit_PK PRIMARY KEY (nom,nom_fournisseur)

	,CONSTRAINT fournit_Produits_FK FOREIGN KEY (nom) REFERENCES Produits(nom)
	,CONSTRAINT fournit_fournisseur0_FK FOREIGN KEY (nom_fournisseur) REFERENCES fournisseur(nom)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: commande
#------------------------------------------------------------

CREATE TABLE commande(
        nom              Varchar (256) NOT NULL ,
        nom_client       Varchar (50) NOT NULL ,
        date_de_commande Date NOT NULL
	,CONSTRAINT commande_PK PRIMARY KEY (nom,nom_client)

	,CONSTRAINT commande_Recette_FK FOREIGN KEY (nom) REFERENCES Recette(nom)
	,CONSTRAINT commande_client0_FK FOREIGN KEY (nom_client) REFERENCES client(nom)
)ENGINE=InnoDB;

select * from client;

select nombre_de_recettes from cdr;

select nom from cdr;

select * from cdr;

ALTER TABLE cdr DROP prenom;

