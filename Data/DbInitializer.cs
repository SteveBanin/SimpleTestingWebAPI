using TestingWebAPI.Models;

namespace TestingWebAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MovieContext movieContext)
        {
            if (movieContext.Movies.Any() && movieContext.Producers.Any() && movieContext.ProducersAddress.Any())
            {
                return;   // DB has been seeded
            }


            // Populate the Producer Addresses to the DB 

            var producerAddress1 = new ProducerAddress
            {
                Address1 = "Mannstr. 1",
                City = "´Mannheim",
                Zipcode = 68160,
                State = "Bade-Württemberg",
                Country = "Deutschland",
            };

            var producerAddress2 = new ProducerAddress
            {
                Address1 = "Mannstr. 2",
                City = "´Mannheim",
                Zipcode = 68161,
                State = "Bade-Württemberg",
                Country = "Deutschland"
            };

            var producerAddress3 = new ProducerAddress
            {
                Address1 = "Mannstr. 3",
                City = "´Mannheim",
                Zipcode = 68162,
                State = "Bade-Württemberg",
                Country = "Deutschland"
            };

            var producerAddress4 = new ProducerAddress
            {
                Address1 = "Mannstr. 4",
                City = "´Mannheim",
                Zipcode = 68163,
                State = "Bade-Württemberg",
                Country = "Deutschland"
            };

            var producerAddress5 = new ProducerAddress
            {
                Address1 = "Mannstr. 5",
                City = "´Mannheim",
                Zipcode = 68164,
                State = "Bade-Württemberg",
                Country = "Deutschland"
            };


            // Populate the Movies to the DB 

            var movie1 = new Movie
            {
                MovieTitle = "The Dark Man",
                MovieCategory = "Action",
                MovieDuration = new TimeSpan(02, 05, 30),
                MovieRelaesedDate = new DateTime(2018, 10, 10),
            };


            var movie2 = new Movie
            {
                MovieTitle = "Hull Mark",
                MovieCategory = "Adventure",
                MovieDuration = new TimeSpan(01, 45, 30),
                MovieRelaesedDate = new DateTime(2019, 06, 10),
            };


            var movie3 = new Movie
            {
                MovieTitle = "Ghost House",
                MovieCategory = "Horror",
                MovieDuration = new TimeSpan(01, 35, 50),
                MovieRelaesedDate = new DateTime(2020, 04, 11),
            };


            var movie4 = new Movie
            {
                MovieTitle = "Hard Way",
                MovieCategory = "Action",
                MovieDuration = new TimeSpan(01, 45, 30),
                MovieRelaesedDate = new DateTime(2021, 02, 10),
            };


            var movie5 = new Movie
            {
                MovieTitle = "Brave Driver",
                MovieCategory = "Action",
                MovieDuration = new TimeSpan(02, 25, 30),
                MovieRelaesedDate = new DateTime(2022, 09, 10),
            };


            // Populate the Producers to the DB 

            var p1 = new Producer
            {
                FirstName = " Thomas ",
                LastName = "Lechmann ",
                Category = "Action",
                Adress = producerAddress1,
                Movies = new List<Movie>
                    {
                        movie1
                    }
            };

            var producers = new List<Producer>
            {
                new Producer
                {
                    FirstName =" Thomas ",
                    LastName ="Lechmann ",
                    Category = "Action",
                    Adress = producerAddress1,
                    Movies = new List<Movie>
                    {
                        movie1
                    }
                },

                new Producer 
                { 
                    FirstName = " Jones ",
                    LastName = "Woods",
                    Category = "Romance",
                    Adress = producerAddress2,
                    Movies = new List<Movie>
                    {
                      movie5
                    }
                },


                new Producer
                {

                    FirstName = "Steve",
                    LastName = "Bans",
                    Category = "Horror",
                    Adress = producerAddress3,
                    Movies = new List<Movie>
                    {
                        movie3
                    }

                },


                new Producer 
                {
                    FirstName = "Markus",
                    LastName = "Buch",
                    Category = "Action",
                    Adress = producerAddress4,
                    Movies = new List<Movie>
                    {
                         movie1, movie4, movie5
                    }
                },


                new Producer 
                {

                    FirstName = "Larry",
                    LastName = "Stones",
                    Category = "Adventure",
                    Adress = producerAddress5,
                    Movies = new List<Movie>
                    {
                        movie2
                    }
                }
            };

            movieContext.Producers.AddRange(producers);
            movieContext.SaveChanges();
        }
    }
}
