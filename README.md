# Use quicktype to make statically typed GraphQL queries

The samples in this repository demonstrate how to use
[quicktype](https://quicktype.io/) to do statically typed
[GraphQL](http://graphql.org/) queries to the
[GitHub API](https://developer.github.com/v4/).

With traditional REST APIs, you have to make multiple queries to collect the data needed by your app. For example, to get the followers for all of a user’s GitHub repos, you’d first query for a list of the user’s repos, then perform a query for each repo to get the followers. For a user with *n* repos, that’s *n+1* queries, which means your app will be slow and will need a cumbersome UI (e.g. loading spinners, lazy lists).

With GraphQL, on the other hand, you specify exactly what information you want up front, so you get all the data your app needs in a *single* query.  Given a bunch of those queries, quicktype can generate the exact static types for the responses from the server.

## Folders

* `schema` contains all the input files for quicktype.  Most importantly, there's the GraphQL query.  The setup script will also download the GraphQL schema into this folder.  The file `request.schema` contains a [JSON Schema](http://json-schema.org) definition of the very simple JSON that's used to send the GraphQL query to the server.

* `csharp` and `typescript` contain the code and project files for the C# and TypeScript samples, respectively.  The setup script will also invoke quicktype to generate code into those folders.

## MacOS and Linux

### Install quicktype

First, make sure you have quicktype installed.  On MacOS you can
install it via [Homebrew](https://brew.sh/) like this:

    brew install quicktype

If you're on Linux, or you prefer [NPM](https://www.npmjs.com/):

    npm install -g quicktype

### Get an authentication token

[Follow these steps](https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line/)
to generate an authentication token and write it into the file `auth-token`:

    echo TOKEN >auth-token

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
