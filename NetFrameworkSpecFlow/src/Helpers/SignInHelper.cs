using DotNetCore.Page;
using System;

namespace NetFrameworkSpecFlow
{
    public class SignInHelper
    {
        public SignInHelper()
        {
        }

        internal static void SignInAndOpenEAndB(string userName, string password)
        {
            SearchForAuthorization createNewPage = new SearchForAuthorization();
            createNewPage.GoTo();
            SignIn signIn = new SignIn();
            signIn.WaitUntilIsLoaded();
            signIn.EnterCredentials(userName, password);
            createNewPage.WaitUntilIsLoaded();
            createNewPage.CreateNewAuthorization();
        }
    }
}