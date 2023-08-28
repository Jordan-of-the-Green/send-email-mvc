using System.ComponentModel.DataAnnotations;

public class Ticket
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter your name.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter the module code.")]
    public string ModuleCode { get; set; }

    [Required(ErrorMessage = "Please enter a description.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Please enter your email address.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; }
}