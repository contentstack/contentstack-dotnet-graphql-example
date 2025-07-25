> **Note:** This app is no longer maintained. It remains available for reference. If you have questions regarding this, please reach out to our [support team](mailto:support@contentstack.com) and we will do our best to help!

![.NET Core](https://github.com/contentstack/contentstack-dotnet-graphql-example/workflows/.NET%20Core/badge.svg)

[![Contentstack](https://www.contentstack.com/docs/static/images/contentstack.png)](https://www.contentstack.com/)

## About this Example

We have created a sample product catalog app that is built using [GraphQL Client](https://www.nuget.org/packages/GraphQL.Client/) SDK. The content of this app is powered by Contentstack GraphQL APIs,  and the app uses [GraphQL Client](https://github.com/github/graphql-client) on the client side to consume GraphQL APIs.

This document covers the steps to get this app up and running. Try out the steps mentioned in the guide before building large scale applications.

![Homepage Screenshot](./Screenshots/product-catelog-image.png?raw=true "Homepage screenshot")

## About Contentstack

Contentstack is a headless CMS with an API-first approach that puts content at the centre. It is designed to simplify the process of publication by separating code from content.

## Get Started

 - To get your app up and running quickly, we have created a sample .NET Product Catalog for this project. You will need to download the code and change the configuration. Download the code using the command given below:
```
$ git clone https://github.com/contentstack/contentstack-dotnet-graphql-example.git
```
  
 - Once you have downloaded the project, add your Contentstack API Key, Delivery Token, and Environment name to the application settings. If you're new to Contentstack, follow these links to learn how to find your Stack's [API Key](https://www.contentstack.com/docs/guide/stack#edit-a-stack) and [Delivery Token](https://www.contentstack.com/docs/guide/tokens#create-a-delivery-token). Read more about [Environments](https://www.contentstack.com/docs/guide/environments).

 - Open ```ContentstackGraphQLExample/appsettings.json``` and inject your credentials as shown below:
```json
 {
  ....
  "ContentstackOptions": {
    "Host": "<HOST_NAME>",
    "ApiKey": "<API_KEY>",
    "DeliveryToken": "<DELIVERY_TOKEN>",
    "Environment": "<ENVIRONMENT_NAME>"
  },
  ...
}
```
> Note: You should set the `Host` value to one of the base [GraphQL URLs](https://www.contentstack.com/docs/developers/apis/graphql-content-delivery-api/#base-url) for Contentstack. For example, the North American URL is https://graphql.contentstack.com and the European URL is https://graphql-eu.contentstack.com.

 - Now that we have a working project ready, you can build and run it.

# Tutorial

We've also created a guide that further explains this project. [Click here](https://www.contentstack.com/docs/developers/sample-apps/build-a-product-catalog-app-using-graphql-client-and-net/)

## Additional Documentation
 - [Visit the Contentstack Documentation](https://www.contentstack.com/docs/)
 - [Visit the Contentstack .NET SDK Documentation](https://github.com/contentstack/contentstack-dotnet)
