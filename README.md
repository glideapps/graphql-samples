# quicktype GraphQL Samples

The samples in this repository demonstrate how to use
[quicktype](https://quicktype.io/) to do statically typed
[GraphQL](http://graphql.org/) queries to the
[GitHub API](https://developer.github.com/v4/).

## MacOS and Linux

### Install quicktype

First, make sure you have quicktype installed.  On MacOS you can
install it via [Homebrew](https://brew.sh/) like this:

    brew install quicktype

If you're on Linux, or you prefer [NPM](https://www.npmjs.com/):

    npm install -g quicktype

### Run the setup script

    ./setup.sh

You should see it downloading the GraphQL schema and then generating
code.

### Try the samples

To run the C# sample with
[.NET Core](https://www.microsoft.com/net/learn/get-started/macos), do

    cd csharp
	dotnet run

For the TypeScript sample, do

    cd typescript
	npm install
	npm start
