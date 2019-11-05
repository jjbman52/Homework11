using System;
using System.IO;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Todo;
using Homework11.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Homework11
{
    public class App : Application
    {
        static JokeItemDatabase database;

        public App()
        {
            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("000000"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            var nav = new NavigationPage(new JokeListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        public static JokeItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new JokeItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }

        protected override void OnStart()
        {
            //Debug.WriteLine("OnStart");

            //// always re-set when the app starts
            //// users expect this (usually)
            ////			Properties ["ResumeAtTodoId"] = "";
            //if (Properties.ContainsKey("ResumeAtTodoId"))
            //{
            //	var rati = Properties["ResumeAtTodoId"].ToString();
            //	Debug.WriteLine("   rati=" + rati);
            //	if (!String.IsNullOrEmpty(rati))
            //	{
            //		Debug.WriteLine("   rati=" + rati);
            //		ResumeAtTodoId = int.Parse(rati);

            //		if (ResumeAtTodoId >= 0)
            //		{
            //			var todoPage = new TodoItemPage();
            //			todoPage.BindingContext = await Database.GetItemAsync(ResumeAtTodoId);
            //			await MainPage.Navigation.PushAsync(todoPage, false); // no animation
            //		}
            //	}
            //}
        }

        protected override void OnSleep()
        {
            //Debug.WriteLine("OnSleep saving ResumeAtTodoId = " + ResumeAtTodoId);
            //// the app should keep updating this value, to
            //// keep the "state" in case of a sleep/resume
            //Properties["ResumeAtTodoId"] = ResumeAtTodoId;
        }

        protected override void OnResume()
        {
            //Debug.WriteLine("OnResume");
            //if (Properties.ContainsKey("ResumeAtTodoId"))
            //{
            //	var rati = Properties["ResumeAtTodoId"].ToString();
            //	Debug.WriteLine("   rati=" + rati);
            //	if (!String.IsNullOrEmpty(rati))
            //	{
            //		Debug.WriteLine("   rati=" + rati);
            //		ResumeAtTodoId = int.Parse(rati);

            //		if (ResumeAtTodoId >= 0)
            //		{
            //			var todoPage = new TodoItemPage();
            //			todoPage.BindingContext = await Database.GetItemAsync(ResumeAtTodoId);
            //			await MainPage.Navigation.PushAsync(todoPage, false); // no animation
            //		}
            //	}
            //}
        }
    }
}