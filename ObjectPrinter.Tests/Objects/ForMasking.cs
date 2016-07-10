namespace Siver.Jeff.ObjectPrinter.Tests.Objects
{
    public class ForMasking
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AnotherEmailAddress { get; set; }
        public string MailAddress { get; set; }

        public static ForMasking Build()
        {
            return new ForMasking
            {
                UserId = "user",
                Password = "password",
                Email = "email",
                FirstName = "first",
                LastName = "last",
                AnotherEmailAddress = "another email",
                MailAddress = "mailing"
            };
        }
    }
}
