/// <binding BeforeBuild='Run - Production, Run - Development' />
const environment = process.env.NODE_ENV || "development";
const webpack = require('webpack');

const _entry = {
    main: ['./scripts/editor-js.ts']
};

const _module = {
    rules: [
        {
            test: /\.tsx?$/,
            exclude: /node_modules/,
            use: ["ts-loader"]
        }]
};

const _output = {
    filename: 'editor-js-blazor.js',
    path: __dirname + '/wwwroot',
    pathinfo: true
};


if (environment == "production") {
    _output.filename = "editor-js-blazor.min.js";
    _output.pathinfo = false;
} else if (environment === "development") {
    _output.publicPath = "";
}

const _resolve = {
    extensions: [".ts", ".js"]
};

module.exports = {
    entry: _entry,
    output: _output,
    resolve: _resolve,
    module: _module
};
