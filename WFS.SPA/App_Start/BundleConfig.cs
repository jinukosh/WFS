using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace WFS.SPA
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                         "~/Scripts/angular.js",
                         "~/Scripts/angular-route.js",
                         "~/Scripts/angular-local-storage.min.js",
                         "~/Scripts/angular-loading-bar.js",
                         "~/Content/assets/global/plugins/angularjs/angular-sanitize.min.js",
                         "~/Content/assets/global/plugins/angularjs/plugins/ui-bootstrap-tpls.min.js",
                         "~/Content/assets/global/plugins/angularjs/plugins/ui-select/select.min.js",
                         "~/Scripts/angular-checklist-module.js"));

            bundles.Add(new ScriptBundle("~/bundles/WFS").Include(
                "~/AngularJS/WFS.main.js", // must be first

                // Helpers
                "~/AngularJS/Helpers/authorizationInterceptor.js",
                "~/AngularJS/Helpers/config.js",

                // Services
                "~/AngularJS/Services/Authentication.service.js",
                "~/AngularJS/Services/User.service.js",
                "~/AngularJS/Services/Note.service.js",

                // Controllers
                "~/AngularJS/App/User/List/UserList.controller.js",
                "~/AngularJS/App/User/Add/UserAdd.controller.js",
                "~/AngularJS/App/User/Edit/UserEdit.controller.js",
                "~/AngularJS/App/User/ChangePassword/ChangePassword.controller.js",
                "~/AngularJS/App/User/Logout/Logout.controller.js",

                "~/AngularJS/App/User/Login/Login.controller.js",

                "~/AngularJS/App/Note/Add/NoteAdd.controller.js",
                "~/AngularJS/App/Note/Edit/NoteEdit.controller.js",
                "~/AngularJS/App/Note/List/NoteList.controller.js",

                "~/AngularJS/App/Dashboard/Default/DashboardDefault.controller.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                "~/AngularJS/login.main.js", // must be first

                // Helpers
                "~/AngularJS/Helpers/authorizationInterceptor.js",
                "~/AngularJS/Helpers/config.js",

                // Services
                "~/AngularJS/Services/Authentication.service.js",
                "~/AngularJS/Services/User.service.js",

                // Controllers
                "~/AngularJS/App/User/Login/Login.controller.js"
                ));
        }
    }
}
