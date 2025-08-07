using Firebase.Database;
using Firebase.Database.Query;
using Lungisa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lungisa.Services
{
    public class FirebaseService
    {
        private readonly FirebaseClient firebase;

        public FirebaseService()
        {
            firebase = new FirebaseClient("https://lungisa-2179e-default-rtdb.firebaseio.com/");
        }


        public async Task<List<FirebaseProject>> GetAllProjectsWithKeys()
        {
            var firebaseProjects = await firebase
                .Child("Projects")
                .OnceAsync<ProjectModel>();

            if (!firebaseProjects.Any())
            {
                Console.WriteLine("No projects found in Firebase."); // or log this
            }

            return firebaseProjects.Select(p => new FirebaseProject
            {
                Key = p.Key,
                Project = p.Object
            }).ToList();
        }


        public async Task SaveProject(ProjectModel Project)
        {
            await firebase.Child("Projects").PostAsync(Project);
        }

        public async Task DeleteProject(string key)
        {
            await firebase.Child("Projects").Child(key).DeleteAsync();
        }





        public async Task<List<FirebaseEvent>> GetAllEventsWithKeys()
        {
            var firebaseEvents = await firebase
                .Child("Events")
                .OnceAsync<EventModel>();

            return firebaseEvents.Select(e => new FirebaseEvent
            {
                Key = e.Key,
                Event = e.Object
            }).ToList();
        }

        public async Task SaveEvent(EventModel eventModel)
        {
            await firebase.Child("Events").PostAsync(eventModel);
        }

        public async Task DeleteEvent(string key)
        {
            await firebase.Child("Events").Child(key).DeleteAsync();
        }

        public class FirebaseEvent
        {
            public string Key { get; set; }
            public EventModel Event { get; set; }
        }

    }

}


/* // Save Volunteer Data
 public async Task SaveVolunteer(string fullName, string email, string skills)
 {
     await firebase.Child("volunteers").PostAsync(new
     {
         name = fullName,
         email = email,
         skills = skills,
         timestamp = DateTime.UtcNow.ToString("o")
     });
 }

 // Save Donation
 public async Task SaveDonation(string donorName, string donorEmail, decimal amount)
 {
     await firebase.Child("donations").PostAsync(new
     {
         donorName = donorName,
         donorEmail = donorEmail,
         amount = amount,
         timestamp = DateTime.UtcNow.ToString("o")
     });
 }

 // Save Contact Message
 public async Task SaveMessage(string name, string email, string subject, string message)
 {
     await firebase.Child("messages").PostAsync(new
     {
         name = name,
         email = email,
         subject = subject,
         message = message,
         timestamp = DateTime.UtcNow.ToString("o")
     });
 }*/

// You can add more: SaveEvent, SaveProject, SaveSubscriber, etc.
