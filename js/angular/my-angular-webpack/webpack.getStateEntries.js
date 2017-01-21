const fs = require('fs');
const glob = require('glob');
const path = require('path');

/**
 * 通过查找
 */


function dirToState(dir) {
    let state = dir                         // => "src/app/pages/aaa/"
            .replace("src/app/", "")        // => "pages/aaa/"
            .replace(/\/$/, "")             // => "pages/aaa"
            .replace(/^pages/, "main")      // => "main/aaa"
            .replace(path.sep, ".")         // => "main.aaa"
        ;
    return state;
}


function dirToEntryPath(dir) {
    let entryPath = dir                     // => "src/app/pages/aaa/"
            .replace(/^/, "./")             // => "./src/app/pages/aaa/"
            .replace(/\/$/, "")             // => "./src/app/pages/aaa"
        ;
    return entryPath;
}

function getStateEntries() {
    let stateEntry = {};

    glob.sync("src/app/pages/**/").forEach((dir) => {

        // 检查目录是否存在 index.js
        try {
            // 存在，但不是文件
            if (!fs.statSync(path.resolve(dir, "index.js")).isFile()) {
                return;
            }
        } catch (err) {
            // 不存在 index.js
            return;
        }

        let state = dirToState(dir);
        let entryPath = dirToEntryPath(dir);

        stateEntry[state] = [entryPath];
    });
    console.log(stateEntry);
    return stateEntry
}
//console.log(getStateEntries());
module.exports = exports = getStateEntries;
