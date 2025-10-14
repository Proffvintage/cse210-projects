using System;
using System.Collections.Generic;

class Behavior
{
    public void AddComment(Video video, Comment comment)
    {
        video.Comments.Add(comment);
    }

    public int GetCommentCount(Video video)
    {
        return video.Comments.Count;
    }

    public void ShowVideoInfo(Video video)
    {
        Console.WriteLine($"Title: {video.Title}");
        Console.WriteLine($"Author: {video.Author}");
        Console.WriteLine($"Length: {video.Length} seconds");
        Console.WriteLine($"Number of comments: {GetCommentCount(video)}");
        Console.WriteLine("Comments:");
        foreach (var comment in video.Comments)
        {
            Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
        }
        Console.WriteLine();
    }

    public void ShowAllVideos(List<Video> videos)
    {
        foreach (var video in videos)
        {
            ShowVideoInfo(video);
        }
    }
}
