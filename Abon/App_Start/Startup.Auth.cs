using Owin;

namespace Abon
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseApplicationSignInCookie();
            
            // Enable the application to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie();

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "000000004C106958",
            //    clientSecret: "EEHKA7aTQqQD3PFXrKghHgpOHNmaZRZi");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            app.UseFacebookAuthentication(
               appId: "157356027785034",
               appSecret: "e6773d7781ba17a2d8333a972cdb77d0");

            app.UseGoogleAuthentication();
        }
    }
}