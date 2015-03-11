﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Reflection;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.Mvc.Razor;
using Microsoft.Framework.DependencyInjection;

namespace RazorEmbeddedViewsWebSite
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseServices(services =>
            {
                services.AddMvc();

                services.Configure<RazorViewEngineOptions>(options =>
                {
                    options.FileProvider = new EmbeddedFileProvider(GetType().GetTypeInfo().Assembly, "EmbeddedResources");
                });
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{controller}/{action}");
                routes.MapRoute("default",
                                "{controller}/{action}/{id?}",
                                new { controller = "Home", action = "Index" });
            });
        }
    }
}