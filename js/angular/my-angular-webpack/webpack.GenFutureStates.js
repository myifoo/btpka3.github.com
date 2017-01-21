const fs = require('fs');
const glob = require('glob');
const path = require('path');
const process = require('process');
const states = require("./webpack.states");
const assert = require('assert');

/**
 * 生成预定义好的futureStates的数组。
 * 示例如下：
 * [
 *   // [状态名称， 状态URL，状态打包文件]
 *   ["main",     "",     "main.90ba1d50c154614dd6d9.js"],
 *   ["main.aaa", "/",    "main.aaa.cdbee811327d854d9e24.js"],
 *   ["main.bbb", "/bbb", "main.bbb.309e31daab8f6c412668.js"],
 *   ["main.ccc", "/ccc", "main.ccc.b31716d65ab745c9f590.js"]
 * ]
 */

// 为了后续查找方便，先转换为对象。
const statesObj = states.reduce((preVal, curVal, curIdx) => {
    preVal[curVal[0]] = curVal;
    return preVal
}, {});

class GenFutureStates {
    constructor(options) {
        console.log('--------new GenFutureStates')
    }

    findoutPath(compilation) {
        console.log("------------ compilation.options.output.path :" + compilation.options.output.path)
        console.log("------------ compilation.options.output.publicPath :" + compilation.options.output.publicPath)
        var self = this;
        var webpackStatsJson = compilation.getStats().toJson();

        // Use the configured public path or build a relative path
        var publicPath = typeof compilation.options.output.publicPath !== 'undefined'
            // If a hard coded public path exists use it
            ? compilation.mainTemplate.getPublicPath({hash: webpackStatsJson.hash})
            // If no public path was set get a relative url path
            : path.relative(compilation.options.output.path, compilation.options.output.path)
                .split(path.sep).join('/');

        if (publicPath.length && publicPath.substr(-1, 1) !== '/') {
            publicPath += '/';
        }
        return publicPath
    }
}

function isState(chunk) {


}

GenFutureStates.prototype.apply = function (compiler) {
    const self = this;

    compiler.plugin('emit', function (compilation, callback) {

        let tmpStates = {};

        // Explore each chunk (build output):
        compilation.chunks.forEach(function (chunk) {
            // // Explore each module within the chunk (built inputs):
            // chunk.modules.forEach(function (module) {
            //     // Explore each source file path that was included into the module:
            //
            //     module.fileDependencies && module.fileDependencies.forEach(function (filepath) {
            //         // we've learned a lot about the source structure now...
            //         let p =path.relative(process.cwd(), filepath);
            //         console.log(`--------GenFutureStates: [${chunk.id}]-[${module.id}]-[${p}]`)
            //     });
            // });
            //
            // // Explore each asset filename generated by the chunk:
            // chunk.files.forEach(function (filename) {
            //     // Get the asset source for each file generated by the chunk:
            //     //var source = compilation.assets[filename].source();
            //     console.log(`--------======= GenFutureStates: [${chunk.id}]-[${filename}]`)
            // });


            console.log(`--------======= GenFutureStates: chunk :
                findoutPath=${self.findoutPath(compilation)}
                id=${chunk.id}, 
                name=${chunk.name},
                files=${chunk.files}`);


            // 判断当前 chunk 是否是一个 ui-router 状态
            let curState = statesObj[chunk.name];
            if (!curState) {
                return;
            }
            let stateName = curState[0];

            let jsFile = chunk.files.find((file) => {
                file.startWith(stateName)
            });
            assert(jsFile, `状态 [${stateName}] 没有找到相应主入口 js 文件。候选有：${chunk.files}`);

            let jsFileUrl = path.relative(
                    compilation.options.output.path,
                    compilation.options.output.path
                ).split(path.sep).join('/') + jsFile;

            tmpStates[stateName] = [
                curState[0],    // ui-router 中 匹配的 状态名称
                curState[1],    // ui-router 中 匹配的 url
                jsFileUrl,      // 相对于 index.html 要加载的 JS 文件的路径
            ];
        });
        callback();


    });
};

module.exports = exports = GenFutureStates;
