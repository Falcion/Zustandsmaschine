/**
 * THIS FILE CREATED FOR REPOSITORY AND SPECIAL PURPOSES ONLY.
 * DO NOT TREAT THIS FILE AS PART OF PROJECT'S CODEBASE, TREAT IT AS PART OF DOCUMENTATION.
 */

import * as fs from 'fs-extra';
import * as dotenv from 'dotenv';

(async () => {
    if(!fs.pathExists('.dotenv')) {
        await fs.createFile('.dotenv');

        console.log('Created .env file!');

        await fs.writeFile('.dotenv', 'NUGET_API_KEY=');
    }

    dotenv.config({
        path: './.dotenv'
    });
})();