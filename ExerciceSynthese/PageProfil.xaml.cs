using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciceSynthese.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExerciceSynthese.Dal;

namespace ExerciceSynthese
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageProfil : ContentPage
    {
        public Profil nouveauProfil = new Profil();
        public PageProfil()
        {
            InitializeComponent();

            nouveauProfil = new ProfilDal().Select(1);
            if(nouveauProfil != null)
            {
                entNom.Text = nouveauProfil.Nom;
                entPrenom.Text = nouveauProfil.Prenom;
                entAge.Text = Convert.ToString(nouveauProfil.Age);
            }
            
        }

        void OnButtonRetourClicked(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();

        }

        void OnButtonValiderClicked(object sender, EventArgs args)
        {
            if (nouveauProfil == null)
                nouveauProfil = new Profil();
                     
            nouveauProfil.Nom = entNom.Text;
            nouveauProfil.Prenom = entPrenom.Text;
            nouveauProfil.Age = Convert.ToInt16(entAge.Text);

            new ProfilDal().Sauvegarder(nouveauProfil);

            Navigation.PopModalAsync();

        }


    }
}