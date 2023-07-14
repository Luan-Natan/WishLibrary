namespace WishLibrary.Configuration
{
    public class RouteConfiguration
    {
        public static IEndpointRouteBuilder AddRoute(IEndpointRouteBuilder route)
        {
            route.MapControllerRoute(
                name: "default",
                pattern: "{controller=Menu}/{action=Index}");

            return route;
        }
    }
}
