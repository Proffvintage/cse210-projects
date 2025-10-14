using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Behavior behavior = new Behavior();

        Video video1 = new Video("C# Basics", "Alice", 600);
        Video video2 = new Video("How many hamburguer's can I eat?", "Steph", 1100);
        Video video3 = new Video("Bethoven Piano's Cover", "Carol", 900);

        behavior.AddComment(video1, new Comment("Zendaya", "Great explanation!"));
        behavior.AddComment(video1, new Comment("Mary", "Very helpful."));
        behavior.AddComment(video1, new Comment("Tim", "Thanks for sharing!"));

        behavior.AddComment(video2, new Comment("Joan", "There is no reason for eating 12 hamburguers!"));
        behavior.AddComment(video2, new Comment("Daniel", "Hahaha, awesome."));
        behavior.AddComment(video2, new Comment("Stella", "Crazy, man!"));
        behavior.AddComment(video2, new Comment("John", "I've did it before. But I get fine after use anti-acid !"));

        behavior.AddComment(video3, new Comment("Carrol", "You did great!"));
        behavior.AddComment(video3, new Comment("Stephen", "That's awesome, i love it."));
        behavior.AddComment(video3, new Comment("Tony", "How many times did you play piano?"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        behavior.ShowAllVideos(videos);
    }
}
