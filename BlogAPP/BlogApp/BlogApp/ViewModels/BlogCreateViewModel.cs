﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlogApp.ViewModels;

public class BlogCreateViewModel
{
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string Content { get; set; } = null!;
    [Required]
    public string[] Tags { get; set; } = null!;
 
    public Guid UserId { get; set; }
}