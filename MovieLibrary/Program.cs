﻿using System;
using System.Collections.Generic;
using NLog;

namespace MovieLibrary
{
    class MainClass
    {
        // create a class level instance of logger (can be used in methods other than Main)
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            string file = "../../movies.csv";
            logger.Info("Program started");

            MovieFile movieFile = new MovieFile(file);
            string choice = "";
            do
            {
                // display choices to user
                Console.WriteLine("1) Add Movie");
                Console.WriteLine("2) Display All Movies");
                Console.WriteLine("Enter to quit");
                // input selection
                choice = Console.ReadLine();
                logger.Info("User choice: {Choice}", choice);
                if (choice == "1")
                {
                    // Add movie
                    Movie movie = new Movie();
                    // ask user to input movie title
                    Console.WriteLine("Enter movie title");
                    // input title
                    movie.title = Console.ReadLine();
                    // verify title is unique
                    if (movieFile.isUniqueTitle(movie.title)){
                        Console.WriteLine("Movie title is unique\n");
                    }
                    else
                    {
                        Console.WriteLine("Movie title already exists\n");
                    }

                } else if (choice == "2")
                {
                    // Display All Movies
                    foreach(Movie m in movieFile.Movies)
                    {
                        Console.WriteLine(m.Display());
                    }
                }
            } while (choice == "1" || choice == "2");

            logger.Info("Program ended");
        }
    }
}
