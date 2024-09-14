// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"}},//Yetkilendirme
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },//Yetkilendirme
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"} },//Yetkilendirme
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[] { 
        
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[] 
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),//Yetki
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"), //Yetki
            new ApiScope("DiscountFullPermission","Reading authority for discount operations"),//Yetki
            new ApiScope("OrderFullPermission","Reading authority for order operations") //Yetki
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId="MultiShopVisitorId",//Yetkilendirme
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission" }

            },
            new Client
            {
                ClientId="MultiShopManagerId",//Yetkilendirme
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission" }

            },
            new Client
            {
                ClientId="MultiShopAdminId",//Yetkilendirme
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "OrderFullPermission", "DiscountFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },

                AccessTokenLifetime=600

             
                


            },
        };
    }
}