using People.Models;
using Plugin.Fingerprint.Abstractions;
using System.Collections.Generic;

namespace People;

        public partial class MainPage : ContentPage
        {
        #if ANDROID
            private readonly IFingerprint fingerprint;
        #endif

            public MainPage(
        #if ANDROID
                IFingerprint fingerprint
        #endif
                )
            {

                InitializeComponent();

                /*this.fingerprint = fingerprint;*/
	        }

          public async void OnNewButtonClicked(object sender, EventArgs args)
          {
             statusMessage.Text = "";

             await App.PersonRepo.AddNewPerson(newPerson.Text);
             statusMessage.Text = App.PersonRepo.StatusMessage;
          }

          public async void OnGetButtonClicked(object sender, EventArgs args)
          {
             statusMessage.Text = "";

             List<Person> people = await App.PersonRepo.GetAllPeople();
             peopleList.ItemsSource = people;
          }

        }

