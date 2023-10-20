using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NAOUFEL_PENDU
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        //variable binaire de conditions
        bool Lettre_dedans = false;


        //chaines de caractere
        string mot_devine = "";
        string mot_affiche = "";
        string[] ListMot = { "PATATE", "OLIVE", "MUR", "VILLE", "ECRAN", "BOULE", "VOITURE", "CAMION", "PASTORALE", "LOURD", "INSTRUIT", "POLLEN", "GYMNASTE", "CAGES", "RAPIDE", "MOTEUR", };
        string mot_affiche_sans_espace = "";

        //definitions de random + valeur de depart de nb de vie
        Random random = new Random();
        int NB_Vie = 7;

        //def des variables pour le Launch
        int indexAleatoire;
        string MotAleatoire;
        string MotEtoile;

        public void Launch()
        {


            foreach (Button tout_bouton in Lettres.Children.OfType<Button>())
            {
                tout_bouton.IsEnabled = true;
            }
            mot_affiche = "";
            NB_Vie = 7;
            Random var = new Random();
            mot_devine = ListMot[var.Next(ListMot.Length)];
            for (int i = 0; i < mot_devine.Length; i++)
            {
                mot_affiche += "*";
            }
            TB_Display.Text = mot_affiche;
            TB_Life.Text = NB_Vie.ToString();
            progressBar.Value = NB_Vie;
        }


            public void Btn_CLICK(object sender, RoutedEventArgs e)
            {
            Button btn = sender as Button;
            string btnContent = btn.Content.ToString();
            StringBuilder newMotAffiche = new StringBuilder(mot_affiche);

            for (int i = 0; i < mot_devine.Length; i++)
                {
                    if (btnContent == mot_devine[i].ToString())
                        {
                            Lettre_dedans = true;
                            if (Char.IsLetter(mot_devine[i]))
                                {
                                    newMotAffiche[i] = btnContent[0];
                                }
                        }
                }

            mot_affiche = newMotAffiche.ToString();
            TB_Display.Text = mot_affiche;

            if (Lettre_dedans == false)
            {
                NB_Vie -= 1;
                progressBar.Value = NB_Vie;
                TB_Life.Text = NB_Vie.ToString();

                if (NB_Vie == 0)
                {
                    TB_Display.Text = "PERDU , LE MOT ETAIT :" + "\n" + mot_devine;
                }

            }

            else if (mot_devine == mot_affiche)
            {
                TB_Display.Text = "BIEN JOUER VOUS AVEZ GAGNER";
            }

            Uri resourceUri = new Uri("/PICTURE/"+ NB_Vie + "_vie.png", UriKind.Relative);
            Image_pendu.Source = new BitmapImage(resourceUri);


            
            Lettre_dedans = false;
            btn.IsEnabled = false;

            }

        public MainWindow()
        {
            InitializeComponent();

            Launch();

        }

        private void TB_RESTART_Click(object sender, RoutedEventArgs e)
        {
            Launch();

        }

        private void TB_STOP_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

    }

    }
