namespace diplom_back.Models.Identity
{
    public class SignUpDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
    }
}
