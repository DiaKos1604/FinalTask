public static class LoginDataProvider
{
    public static IEnumerable<object[]> GetLoginTestData()
    {
        yield return new object[] { "", "", "Username is required" };
        yield return new object[] { "standard_user", "", "Password is required" };
        yield return new object[] { "standard_user", "secret_sauce", "" };
    }
}