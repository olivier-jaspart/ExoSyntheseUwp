using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciceSynthese.Dal;
using ExerciceSynthese.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExerciceSynthese
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAjouter : ContentPage
    {
        public PageAjouter()
        {
            InitializeComponent();
        }

        void OnButtonRetourClicked(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        
        }

        void OnButtonValiderClicked(object sender, EventArgs args)
        {
            Tache nouvelleTache = new Tache();
            nouvelleTache.Title = entTitre.Text;
            nouvelleTache.Description = entDescription.Text;
            nouvelleTache.Etat = false;
            nouvelleTache.Date = dtpDate.Date;
            new TacheDal().Sauvegarder(nouvelleTache);

            Navigation.PopModalAsync();

        }


    }
}