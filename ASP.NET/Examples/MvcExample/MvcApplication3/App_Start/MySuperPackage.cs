using System;

[assembly: WebActivator.PreApplicationStartMethod(
    typeof(MvcApplication3.App_Start.MySuperPackage), "PreStart")]

namespace MvcApplication3.App_Start {
    public static class MySuperPackage {
        public static void PreStart() {
            MVCControlsToolkit.Core.Extensions.Register();
        }
    }
}