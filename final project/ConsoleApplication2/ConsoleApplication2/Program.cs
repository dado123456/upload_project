using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication2
{

    public class Program
    {
        public static void Main()
        {

            Console.ForegroundColor = ConsoleColor.Red;



            Console.SetCursorPosition((Console.WindowWidth - "Welcome to Gamer Social Media Platform!".Length) / 2, Console.CursorTop);
            Console.WriteLine("Welcome to Gamer Social Media Platform! \n \n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter your details:");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Gamertag: ");
            string gamertag = Console.ReadLine();


            GamerUser user = new GamerUser(username, email, password, gamertag);
            GamerSocialMediaPlatform.Instance.RegisterUser(user);

            Console.WriteLine("Registration successful! \n \n \n");
            bool shouldExit = false;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition((Console.WindowWidth - "==== Menu ====".Length) / 2, Console.CursorTop);
            while (!shouldExit)
            {
                Console.WriteLine("==== Menu ====");
                Console.WriteLine("1. Create a post");
                Console.WriteLine("2. View all posts");
                Console.WriteLine("3. Delete a post");
                Console.WriteLine("4. Update a post");
                Console.WriteLine("5. Add a game to a user");
                Console.WriteLine("6. Remove a game from a user");
                Console.WriteLine("7. Exit from this menu ");
                Console.WriteLine("8. Exit from program ");
                Console.WriteLine("==============");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition((Console.WindowWidth - "Enter your choice:".Length) / 2, Console.CursorTop);
                Console.WriteLine("Enter your choice:");
               
                string choice = Console.ReadLine();

                switch (choice)
                {    

                    case "1":
                       
                        Console.WriteLine("Enter your post content:");
                        string content = Console.ReadLine();
                        user.Post(content);
                        Console.WriteLine("Post created!");
                        break;
                    case "2":
                        List<IPost> posts = GamerSocialMediaPlatform.Instance.GetPosts();
                        Console.WriteLine("==== Posts ====");
                        foreach (IPost post in posts)
                        {
                            Console.WriteLine("Post ID: {0}", post.Id);
                            Console.WriteLine("Content: {0}", post.Content);
                            Console.WriteLine("Author: {0}", post.Author.Username);
                            Console.WriteLine("Created At: {0}", post.CreatedAt);
                            Console.WriteLine("==== Comments ====");
                            foreach (IComment comment in post.Comments)
                            {
                                Console.WriteLine("Comment ID: {0}", comment.Id);
                                Console.WriteLine("Content: {0}", comment.Content);
                                Console.WriteLine("Author: {0}", comment.Author.Username);
                                Console.WriteLine("Created At: {0}", comment.CreatedAt);
                            }
                            Console.WriteLine("================= \n \n");
                        }


                        break;
                    case "3":
                        Console.WriteLine("Enter the ID of the post you want to delete:");
                        string postIdToDelete = Console.ReadLine();
                        IPost postToDelete = GamerSocialMediaPlatform.Instance.GetPosts().FirstOrDefault(p => p.Id == postIdToDelete);
                        if (postToDelete != null)
                        {
                            GamerSocialMediaPlatform.Instance.DeletePost(postToDelete);
                            Console.WriteLine("Post deleted!");
                            Console.WriteLine("================= \n \n");
                        }
                        else
                        {
                            Console.WriteLine("Post not found!");
                            Console.WriteLine("================= \n \n");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter the ID of the post you want to update:");
                        string postIdToUpdate = Console.ReadLine();
                        IPost postToUpdate = GamerSocialMediaPlatform.Instance.GetPosts().FirstOrDefault(p => p.Id == postIdToUpdate);
                        if (postToUpdate != null)
                        {
                            Console.WriteLine("Enter the new content for the post:");
                            string newContent = Console.ReadLine();
                            GamerSocialMediaPlatform.Instance.UpdatePost(postToUpdate, newContent);
                            Console.WriteLine("Post updated!");
                            Console.WriteLine("================= \n \n");
                        }
                        else
                        {
                            Console.WriteLine("Post not found!");
                            Console.WriteLine("================= \n \n");
                        }
                        break;
                    
                    case "5":
                        Console.WriteLine("Enter the gamertag of the user:");
                        string gamertagToAddGame = Console.ReadLine();
                        GamerUser userToAddGame = GamerSocialMediaPlatform.Instance.GetUserByGamertag(gamertagToAddGame);
                        if (userToAddGame != null)
                        {
                          
                            Game newGame = new Game();
                            Console.WriteLine("enter the name of the game  ");
                            newGame.Name = Console.ReadLine();
                            Console.WriteLine("enter the details of the game ");
                            newGame.Genre = Console.ReadLine();
                            // Read other game properties...

                            GamerSocialMediaPlatform.Instance.AddGameToUser(userToAddGame, newGame);
                            Console.WriteLine("Game added to the user!");
                            Console.WriteLine("================= \n \n");
                        }
                        else
                        {
                            Console.WriteLine("User not found!");
                            Console.WriteLine("================= \n \n");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Enter the gamertag of the user:");
                        string gamertagToRemoveGame = Console.ReadLine();
                        GamerUser userToRemoveGame = GamerSocialMediaPlatform.Instance.GetUserByGamertag(gamertagToRemoveGame);
                        if (userToRemoveGame != null)
                        {
                            Console.WriteLine("Enter the name of the game to remove:");
                            string gameNameToRemove = Console.ReadLine();
                            Game gameToRemove = userToRemoveGame.Games.FirstOrDefault(g => g.Name == gameNameToRemove);
                            if (gameToRemove != null)
                            {
                                GamerSocialMediaPlatform.Instance.RemoveGameFromUser(userToRemoveGame, gameToRemove);
                                Console.WriteLine("Game removed from the user!");
                                Console.WriteLine("================= \n \n");
                            }
                            else
                            {
                                Console.WriteLine("Game not found!");
                                Console.WriteLine("================= \n \n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("User not found!");
                        }
                        break;
                    case "7":
                        Console.WriteLine("new menu");
                        //return;
                        break;
                    case "8":
                        shouldExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            //Console.ReadKey();
        }
    }
}