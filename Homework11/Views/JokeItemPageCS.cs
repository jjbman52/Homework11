using System;
using Homework11.Models;
using Xamarin.Forms;

namespace Homework11.Views
{
    public class JokeItemPageCS : ContentPage
    {
        public JokeItemPageCS()
        {
                Title = "Joke Item";

                var nameEntry = new Entry();
                nameEntry.SetBinding(Entry.TextProperty, "Name");

                var jokeEntry = new Editor();
                jokeEntry.SetBinding(Entry.TextProperty, "Joke");

                var doneSwitch = new Switch();
                doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");

                var saveButton = new Button { Text = "Save" };
                saveButton.Clicked += async (sender, e) =>
                {
                    var jokeItem = (JokeItem)BindingContext;
                    await App.Database.SaveItemAsync(jokeItem);
                    await Navigation.PopAsync();
                };

                var deleteButton = new Button { Text = "Delete" };
                deleteButton.Clicked += async (sender, e) =>
                {
                    var jokeItem = (JokeItem)BindingContext;
                    await App.Database.DeleteItemAsync(jokeItem);
                    await Navigation.PopAsync();
                };

                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    Children =
                {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Joke" },
                    jokeEntry,
                    new Label { Text = "Done" },
                    doneSwitch,
                    saveButton,
                    deleteButton
                }
                };
            }
        }
    }