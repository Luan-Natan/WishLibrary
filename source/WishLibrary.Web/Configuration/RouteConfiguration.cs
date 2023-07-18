namespace WishLibrary.Web.Configuration
{
    public class RouteConfiguration
    {
        public static IEndpointRouteBuilder AddRoute(IEndpointRouteBuilder route)
        {
            route.MapControllerRoute(
                name: "AdminArea",
                pattern: "{area:exists}/{controller}/{action}");

            route.MapControllerRoute(
                name: "default",
                pattern: "{controller=Menu}/{action=Index}");

            return route;
        }
    }
}