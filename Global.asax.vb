' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults

        routes.Add("ImagesRoute", New Route("graphics/{uploadtype}/{filename}", New ShikshaSankalp.ImageRouteHandler()))
        routes.MapRoute( _
            "Default", _
            "{controller}/{action}/{id}", _
            New With {.controller = "Home", .action = "Index", .id = ""} _
        )


        routes.MapRoute( _
                "ArtistSearch", _
                "Family/Search/{searchTerm}", _
                New With {.controller = "Family", .action = "Search", .searchTerm = ""} _
        )

       

        routes.MapRoute( _
                "ArtistAjaxSearch", _
                "Family/getAjaxResult/", _
                New With {.controller = "Family", .action = "getAjaxResult"} _
            )
        routes.IgnoreRoute("favicon.ico")
    End Sub

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        RegisterRoutes(RouteTable.Routes)
    End Sub

End Class
