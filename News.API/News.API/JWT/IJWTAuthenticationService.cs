namespace News.API.JWT
{
    public interface IJWTAuthenticationService
    {
        public string Authenticate(string userId);
    }
}
