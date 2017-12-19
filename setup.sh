#!/bin/bash

TOKEN_FILENAME="auth-token"
SCHEMA_DIR="./schema"
GQLSCHEMA_FILENAME="$SCHEMA_DIR/github.gqlschema"

if [ ! -f "$GQLSCHEMA_FILENAME" ] ; then
    if [ ! -f "$TOKEN_FILENAME" ] ; then
        echo "Error: No authentication token file found.  Please follow these instructions"
        echo "to get a token:"
        echo
        echo "  https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line/"
        echo
        echo "Then write the token to the file \"$TOKEN_FILENAME\" in this directory and run"
        echo "this script again."
        exit 1
    fi

    TOKEN=`cat "$TOKEN_FILENAME"`

    quicktype --graphql-server-header "Authorization: bearer $TOKEN" \
        --graphql-introspect "https://api.github.com/graphql" \
        --graphql-schema "$GQLSCHEMA_FILENAME"
fi

quicktype --lang "csharp" --namespace "QuickTypeDemo" -o "csharp/Schema.cs" "$SCHEMA_DIR"
