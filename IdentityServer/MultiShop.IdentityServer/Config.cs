﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
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
            new ApiResource("ResourceOrder"){Scopes={ "OrderFullPermisson"}},//Yetkilendirme
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"} },//Yetkilendirme
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"} },//Yetkilendirme
            new ApiResource("ResourceOcelot"){Scopes={ "OcelotFullPermission" }},//Yetkilendirme
            new ApiResource("ResourceComment"){Scopes={ "CommentFullPermission" }},//Yetkilendirme
            new ApiResource("ResourcePayment"){Scopes={ "PaymentFullPermission" }},//Yetkilendirme
            new ApiResource("ResourceImage"){Scopes={ "ImageFullPermission" }},//Yetkilendirme
            new ApiResource("ResourceMessage"){Scopes={ "MessageFullPermission" }},//Yetkilendirme

            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
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
            new ApiScope("OrderFullPermisson","Reading authority for order operations"),//Yetki
            new ApiScope("CargoFullPermission","Full authority for cargo operations"),//Yetki
            new ApiScope("BasketFullPermission","Full authority for basket operations"),//Yetki
            new ApiScope("PaymentFullPermission","Full authority for payment operations"),//Yetki
            new ApiScope("ImageFullPermission","Full authority for image operations"),//Yetki
            new ApiScope("CommentFullPermission","Full authority for comment operations"),//Yetki
            new ApiScope("OcelotFullPermission","Full authority for ocelot operations"),//Yetki
            new ApiScope("MessageFullPermission","Full authority for message operations"),//Yetki
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId="MultiShopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={"CatalogReadPermission","CatalogFullPermission","OcelotFullPermission","CommentFullPermission","ImageFullPermission", "CommentFullPermission",  IdentityServerConstants.LocalApi.ScopeName },
                AllowAccessTokensViaBrowser=true
            },

            //Manager
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256()) },
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "BasketFullPermission", "OcelotFullPermission", "CommentFullPermission", "PaymentFullPermission", "ImageFullPermission","DiscountFullPermission","OrderFullPermisson","MessageFullPermission","CargoFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile }
            },

            //Admin
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256()) },
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermisson","CargoFullPermission","BasketFullPermission","OcelotFullPermission","CommentFullPermission","PaymentFullPermission","ImageFullPermission","CargoFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=600
            }

        };
    }
}