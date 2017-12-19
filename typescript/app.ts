#!/usr/bin/env ts-node

import * as WebRequest from "web-request";
import * as fs from "fs";

import { Convert } from "./schema";

async function main() {
    // Read the authentication token
    const authToken = fs.readFileSync("../auth-token").toString().trim();

    // Read the GraphQL query
    const query = fs.readFileSync("../schema/query.graphql").toString();
    
    // Wrap the query into JSON
    const requestContent = Convert.requestToJson({ query });

    const headers = {
        "User-Agent": "quicktype demo app",
        "Authorization": `bearer ${authToken}` // the authentication token
    };

    // Send the POST request
    const result = await WebRequest.post("https://api.github.com/graphql", { headers }, requestContent);

    // FIXME: Check error
    const viewer = Convert.toQuery(result.content).data.viewer;
    
    console.log(`Login: ${viewer.login}\nName: ${viewer.name}`);
}

main();
