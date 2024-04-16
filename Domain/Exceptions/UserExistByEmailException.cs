namespace Domain.Exceptions 
{
    public class UserExistsByEmailException : Exception
    {
        public UserExistsByEmailException() : base("User with same email exists.") {}
    }
}