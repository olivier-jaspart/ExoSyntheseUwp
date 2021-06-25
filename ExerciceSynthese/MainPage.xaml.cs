using ExerciceSynthese.Dal;
using ExerciceSynthese.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExerciceSynthese
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
	
			
		}
	
		void OnButtonProfilClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new PageProfil());
		}

		void OnButtonAjouterClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new PageAjouter());
		}

		private void lstTache_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			//  DisplayAlert("Item Selected", e.SelectedItemIndex.ToString(), "ok");
		}

		private void lstTache_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			DisplayAlert("Tache sélectionnée", e.ItemIndex.ToString(), "ok");
			// Navigation.PushModalAsync(new ListeInscrit((Course)e.Item));

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
			lstTache.ItemsSource = new TacheDal().SelectAll();
			DateDuJour.Text = DateTime.Now.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"));
		}

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {

			Tache tache = (Tache)((Switch)sender).BindingContext;
			if (tache != null)
			{

				tache.Etat = e.Value;
				new TacheDal().Sauvegarder(tache);

			}

		}
    }
}
