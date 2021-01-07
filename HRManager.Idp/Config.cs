// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace HRManager.Idp
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResource(name: "role", userClaims: new [] { JwtClaimTypes.Role }),
                new IdentityResource(name: "profile", userClaims: new [] { "profile_id" })
            };

        public static IEnumerable<ApiScope> GetApiScopes =>
            new ApiScope[]
            {
                new ApiScope("main.super_admin"),
                new ApiScope("main.admin"),
                new ApiScope("main.member"),
            };

        public static IEnumerable<Client> GetClients =>
            new Client[] 
            {
                new Client
                {
                    ClientName = "Blazor",
                    ClientId = "blazorclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireConsent = false,
                    AccessTokenLifetime = 1200,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:5004/signin-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        JwtClaimTypes.Role,
                        "profile",
                        "main.super_admin",
                        "main.admin",
                        "main.member",
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
    }
}