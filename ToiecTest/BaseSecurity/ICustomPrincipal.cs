using System.Security.Principal;

namespace ToiecTest.BaseSecurity
{
    public interface ICustomPrincipal: IPrincipal
    {
        int ID { get; set; }
        string Username { get; set; }
        string FullName { get; set; }
        string Email { get; set; }
    }
}