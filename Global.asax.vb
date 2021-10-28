Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Fires when the application is started
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub
    Sub Session_Start()
        Session("conString") = "Server =.;Database=TCFdb;Trusted_Connection=True;"

        Session("AccountNumber") = "2104242488"
        Session("userName") = "amr"

    End Sub
    Sub Session_end()

    End Sub
End Class