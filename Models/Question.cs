using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Question
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Text { get; set; }

    [Required]
    public string CorrectAnswer { get; set; }

    public string Option1 { get; set; }
    public string Option2 { get; set; }
    public string Option3 { get; set; }

    [ForeignKey("Quiz")]
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }
}
