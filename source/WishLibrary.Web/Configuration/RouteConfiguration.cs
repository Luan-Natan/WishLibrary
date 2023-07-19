namespace WishLibrary.Web.Configuration
{
    public class RouteConfiguration
    {
        public static IEndpointRouteBuilder AddRoute(IEndpointRouteBuilder route)
        {
            route.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller}/{action}");

            route.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            return route;
        }
    }
}