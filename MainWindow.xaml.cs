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

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Joueur joueur_1;
        private Joueur joueur_2;
        private Joueur joueur_actif;
        public MainWindow()
        {
            InitializeComponent();

            this.joueur_1 = new Joueur("joueur_1", "J1Score");
            this.joueur_2 = new Joueur("joueur_2", "J2Score");
            this.joueur_actif = joueur_1;
                        
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            button.Background = Brushes.Red;
            button.IsEnabled = false;

            joueur_actif.addToScore(int.Parse($"{button.Content}"));

            if("joueur_2" == joueur_actif.Nom)
            {
                J2Score.Content = joueur_actif.Score;
                Check_Score();
                this.joueur_actif = joueur_1;
            }
            else
            {
                J1Score.Content = joueur_actif.Score;
                Check_Score();
                this.joueur_actif = joueur_2;
            }

            //label_
            //MessageBox.Show($"{joueur_actif.Nom}+{ joueur_actif.Score}");
        }

        private void Check_Score()
        {
            int score = joueur_actif.Score;
            if(15 == score)
            {
                MessageBox.Show($"{joueur_actif.Nom} remporte la manche");
                Stop();
            } else if (15 < score)
            {
                MessageBox.Show($"{joueur_actif.Nom} perd la manche, score : {joueur_actif.Score}");
                Stop();
            }
        }

        private void Stop()
        {
            Application app = Application.Current;
            app.Shutdown();
        }


    }

    public class Joueur
    {
        private int score;
        private string nom;
        private string labelScore;

        public Joueur(string nom, string label)
        {
            Nom = nom;
            Score = 0;
            LabelScore = label;
        }

        public int Score
        {
            get{ return score; }
            set{ score = value; }
        }
        public string Nom
        {
            get{ return nom; }
            set{ nom = value; }
        }
        public string LabelScore
        {
            get { return labelScore; }
            set { labelScore = value; }
        }

        public void addToScore(int add)
        {
            Score += add;
        }
    }
}
