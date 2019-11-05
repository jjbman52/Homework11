using System;
using System.Diagnostics;
using Homework11.Models;
using Xamarin.Forms;

namespace Homework11.Views
{
    public partial class JokeListPage : ContentPage
    {
        public JokeListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JokeItemPage
            {
                BindingContext = new JokeItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new JokeItemPage
                {
                    BindingContext = e.SelectedItem as JokeItem
                });
            }
        }
    }
}