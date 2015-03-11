﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;

namespace ApplicationModelWebSite
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseServices(services =>
            {
                services.AddMvc();

                services.Configure<MvcOptions>(options =>
                {
                    options.Conventions.Add(new ApplicationDescription("Common Application Description"));
                    options.Conventions.Add(new ControllerLicenseConvention());
                    options.Conventions.Add(new FromHeaderConvention());
                });
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
        }
    }
}
